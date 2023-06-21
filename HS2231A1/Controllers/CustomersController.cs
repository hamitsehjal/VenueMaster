using AutoMapper;
using HS2231A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HS2231A1.Controllers
{
    public class CustomersController : Controller
    {
        // Reference to manager object
        private Manager m = new Manager();

        // GET: Customers
        public ActionResult Index()
        {
            return View(m.CustomerGetAll());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var obj=m.CustomerGetById(id.GetValueOrDefault());

            if(obj==null)
                {
                return HttpNotFound();
                }
            else
                return View(obj);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(CustomerAddViewModel newItem)
        {
            // Validate the input
            if(!ModelState.IsValid)
                {
                return View(newItem);
                }

            try
                {
                // Process the input
                var addedItem = m.CustomerAdd(newItem);

                // If the item was not added, return the usere to the create Page
                // otherwise redirect them to Details Page
                if (addedItem == null)
                    {
                    return View(newItem);
                    }
                else
                    {
                    return RedirectToAction("Details", new { id=addedItem.CustomerId });
                    }

                }
            catch
                {
                return View(newItem);
                }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            // Attempt to fetch the matching object
            var obj = m.CustomerGetById(id.GetValueOrDefault());

            if(obj==null)
                {
                return HttpNotFound();
                }
            else
                {
                // Create and configure an edit form
                var formObj = m.mapper.Map<CustomerBaseViewModel,CustomerEditContactFormViewModel>(obj);
                return View(formObj);
                }
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, CustomerEditContactViewModel model)
            {

                // 1. DataBinding and Validation
                // 2. Data tampering

            if(!ModelState.IsValid)
                {
                    return RedirectToAction("Edit",new {id=model.CustomerId });
                }

            if(id.GetValueOrDefault()!=model.CustomerId)
                {
                // This appears to be data tampering, so redirect the user away
                return RedirectToAction("Index");
                }

            // Attempt to do the Update
            var editedItem = m.CustomerEditContactInfo(model);

            if(editedItem==null)
                {
                // There was a problem updating the Object
                return RedirectToAction("Edit", new { id = model.CustomerId });
                }
            else
                {
                // show the details view
                return RedirectToAction("Details", new { id = model.CustomerId });
                }
          
            }   
        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.CustomerGetById(id.GetValueOrDefault());
            if (itemToDelete == null)
                {
                // Don't leak info about the delete attempt
                // Simply redirect
                return RedirectToAction("Index");
                }
            else
                return View(itemToDelete);
            }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.CustomerDelete(id.GetValueOrDefault());

            return RedirectToAction("Index");
        }
    }
}
