using AutoMapper;
using HS2231A1.Data;
using HS2231A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

                // Map from CustomerBaseViewModel to CustomerEditContactFormViewModel class
                cfg.CreateMap<CustomerBaseViewModel, CustomerEditContactFormViewModel>();

                // Map from Venue Design model to VenueBaseViewModel
                cfg.CreateMap<Venue, VenueBaseViewModel>();

                // Map from VenueAddViewModel to Venue Design Model
                cfg.CreateMap<VenueAddViewModel, Venue>();

                // Map from VenueBaseViewModel to VenueEditFormViewModel class
                cfg.CreateMap<VenueBaseViewModel,VenueEditFormViewModel>();


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
            return mapper.Map<IEnumerable<Customer>,IEnumerable<CustomerBaseViewModel>>(ds.Customers);
            }

        // Get one customer
        public CustomerBaseViewModel CustomerGetById(int id)
            {
            // Attempt to fetch the object
            var obj = ds.Customers.Find(id);

            // Return the result (or null if not Found)
            return obj == null ? null : mapper.Map<Customer,CustomerBaseViewModel>(obj);
            }

        // Add a new Customer
        public CustomerBaseViewModel CustomerAdd(CustomerAddViewModel newCustomer)
            {
            // Attempt to add a new Item
            var addedItem=ds.Customers.Add(mapper.Map<CustomerAddViewModel,Customer>(newCustomer));
            ds.SaveChanges();

            // If successful, return the added item (mapped to a view model class)
            return addedItem==null?null:mapper.Map<Customer,CustomerBaseViewModel>(addedItem);
            }

        // Edit existing Customer
        // Update an existing Customer object and save the changes to the data store
        public CustomerBaseViewModel CustomerEditContactInfo(CustomerEditContactViewModel customer)
            {
            // Attempt to fetch the object
            var obj = ds.Customers.Find(customer.CustomerId);

            if (obj == null)
                {
                // customer not found, return null
                return null;
                }
            else
                {
                // customer was found. Update the entity object
                // with the incoming values then save the changes
                ds.Entry(obj).CurrentValues.SetValues(customer);
                ds.SaveChanges();

                // Prepare and return the object
                return mapper.Map<Customer,CustomerBaseViewModel>(obj);
                }
            }
        // delete existing Customer
        public bool CustomerDelete(int id)
            {
            // Attempt to find the Customer to be deleted
            var customerToBeDelete = ds.Customers.Find(id);

            if (customerToBeDelete == null)
                return false;
            else
                {
                // Remove the customer
                ds.Customers.Remove(customerToBeDelete);
                ds.SaveChanges();

                return true;
                }
            }

        // Get all Venues

        public IEnumerable<VenueBaseViewModel> VenueGetAll()
            {



            var venues = ds.Venues.OrderBy(v => v.Company);
            var newCollection = new List<VenueBaseViewModel>();

            return mapper.Map<IEnumerable<Venue>, IEnumerable<VenueBaseViewModel>>(venues);



            }


        // Get one Venue
        public VenueBaseViewModel VenueGetOneById(int id)
            {
            // Attempt to fetch the object
            var obj = ds.Venues.Find(id);

            return obj==null?null:mapper.Map<Venue,VenueBaseViewModel>(obj);
            }

        // Add new Venue
        // Add a new Customer
        public VenueBaseViewModel VenueAdd(VenueAddViewModel newVenue)
            {
            // Attempt to add the new item
            var addedItem=ds.Venues.Add(mapper.Map<VenueAddViewModel,Venue>(newVenue));
            ds.SaveChanges();

            // mapping from VenueAddViewModel to Venue Class
            return addedItem == null ? null : mapper.Map<Venue, VenueBaseViewModel>(addedItem);
            }


        // edit existing Venue
        // Update an existing Venue object and save it to the data store
        public VenueBaseViewModel VenueEdit(VenueEditViewModel venue)
            {
            // Attempt to fetch the object
            var obj = ds.Venues.Find(venue.VenueId);

            if(obj==null )
                {
                return null;
                }
            else
                {
                ds.Entry(obj).CurrentValues.SetValues(venue);
                ds.SaveChanges();

                // Prepare and return the updated object
                return mapper.Map<Venue, VenueBaseViewModel>(obj);
                }
            }

        // delete existing Venue
        public bool VenueDelete(int id)
            {
                // Attempt to fetch the object to be deleted
                var venueToDelete=ds.Venues.Find(id);

                if(venueToDelete==null)
                {
                return false;
                }
            else
                {
                // Remove the object
                ds.Venues.Remove(venueToDelete); 
                ds.SaveChanges();
                return true;
                }
            }

        }
    }