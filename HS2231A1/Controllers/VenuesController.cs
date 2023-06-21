using HS2231A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HS2231A1.Controllers
{
    public class VenuesController : Controller
    {
        // reference to Manager controller
        private Manager m = new Manager();

        // GET: Venues
        public ActionResult Index()
            {
            return View(m.VenueGetAll());
            }

        // GET: Venues/Details/5
        public ActionResult Details(int? id)
            {
            // Attempt to get the matching object
            var obj = m.VenueGetOneById(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
            }


        // GET: Venues/Create
        public ActionResult Create()
        {
            // object with initial data
            var obj = new VenueAddViewModel();
            return View(obj);
        }

        // POST: Venues/Create
        [HttpPost]
        public ActionResult Create(VenueAddViewModel newItem)
            {
            // Validate the input
            if (!ModelState.IsValid)
                return View(newItem);
            try
                {
                // TODO: Add insert logic here
                // Process the input
                var addedItem = m.VenueAdd(newItem);

                if (addedItem == null)
                    return View(newItem);
                else
                    return RedirectToAction("Details", new { id = addedItem.VenueId });
                }
            catch
                {
                return View(newItem);
                }
            }

        // GET: Venues/Edit/5
        public ActionResult Edit(int? id)
        {
            // Attempt to fetch the matching object
            var obj = m.VenueGetOneById(id.GetValueOrDefault());

            if (obj == null)
                {
                return HttpNotFound();
                }
            else
                {
                var formObj = m.mapper.Map<VenueBaseViewModel, VenueEditFormViewModel>(obj);
                return View(formObj);
                }

        }

        // POST: Venues/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, VenueEditViewModel model)
        {
           // Valida the input
           if(!ModelState.IsValid)
                {
                return RedirectToAction("Edit", new { id = model.VenueId });
                }

            if (id.GetValueOrDefault() != model.VenueId)
                {
                // This appears to be a case of data tampering
                return RedirectToAction("Index");
                }
            // Attempt to do the update
            var editedItem = m.VenueEdit(model);

            if (editedItem == null)
                {
                // There was a problem updating the data
                return RedirectToAction("Edit", new { id = model.VenueId });
                }
            else
                {
                // show the details View, which will show the updated data
                return RedirectToAction("Details", new { id = model.VenueId });
                }
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.VenueGetOneById(id.GetValueOrDefault());
            if (itemToDelete == null)
                {
                // Don't leak info about the delete attempt
                // Simply redirect
                return RedirectToAction("Index");
                }
            else
                return View(itemToDelete);
            
        }

        // POST: Venues/Delete/5
        [HttpPost]
    public ActionResult Delete(int? id, FormCollection collection)
        {
        var result = m.VenueDelete(id.GetValueOrDefault());

        return RedirectToAction("Index");
        }
    }
}
