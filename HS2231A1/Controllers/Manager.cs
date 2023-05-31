using AutoMapper;
using HS2231A1.Data;
using HS2231A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// ************************************************************************************
// WEB524 Project Template V1 == 2231-bfcb4ae1-fb31-4c0c-bb71-416cff7e6418
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace HS2231A1.Controllers
    {
    public class Manager
        {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
            {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();

                // Map from customer Desgin model to CustomerBaseViewModel
                cfg.CreateMap<Customer, CustomerBaseViewModel>();

                // Map from CustomerAddViewModel to Customer Design model.
                cfg.CreateMap<CustomerAddViewModel, Customer>();

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
            }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        // Get all customers
        public IEnumerable<CustomerBaseViewModel> CustomerGetAll()
            {
            // syntax: mapper.Map<<source object Type>,<target object Type>>(source-object);
            return mapper.Map<IEnumerable<Customer>,IEnumerable<CustomerBaseViewModel>>(ds.Customers);
            }

        // Get one customer
        public CustomerBaseViewModel CustomerGetById(int id)
            {
            // Attempt to fetch the object
            var obj = ds.Customers.Find(id);

            // Return the result (or null if not found)
            return obj == null ? null : mapper.Map<Customer,CustomerBaseViewModel>(obj);
            }

        // Add a new Customer
        public CustomerBaseViewModel CustomerAdd(CustomerAddViewModel newCustomer)
            {
            // Attempt to add the new item
            // mapping from CustomerAddViewModel to Customer Class
            var addedItem = ds.Customers.Add(mapper.Map<CustomerAddViewModel,Customer>(newCustomer));
            ds.SaveChanges();

            // If successful, return the addedItem (mapped to CustomerBaseViewModel class)
            return addedItem == null ? null : mapper.Map<Customer, CustomerBaseViewModel>(addedItem);
            }

        }
    }