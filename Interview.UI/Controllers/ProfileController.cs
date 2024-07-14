using Interview.Model;
using Interview.Service.Interfaces;
using Microsoft.Build.Utilities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Logger = NLog.Logger;

namespace Interview.UI.Controllers
{

    //[MyHandleError]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        // GET: Profile
        public ActionResult Index()
        {
            try
            {
                var ProfileList = _profileService.GetAll();
                return View(ProfileList);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred : {ex.Message}", ex);
            }

        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profile/Create
        public ActionResult Create()
        {             
             return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(ProfileModel model)
        {
           try
            {
                bool isInserted = false;
                if (ModelState.IsValid)
                {
                    isInserted = _profileService.InsertProfile(model);
                    if (isInserted)
                    {
                        @TempData["InfoMessage"] = "Saved successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        @TempData["InfoMessage"] = "Unsuccessful";
                    }
                }
                Response.Write("<script>alert('Enter details in all fields');</script>");
                return View(model);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred : {ex.Message}", ex);
            }

        }       

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var _profile = _profileService.getProfileByID(id);
                if (_profile == null)
                {
                    TempData["InfoMessage"] = "Profile Not Found";
                    return RedirectToAction("Index");
                }
                return View(_profile);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred : {ex.Message}", ex);
            }

        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(ProfileModel model)
        {
            try
            {
                bool isUpdated = false;
                if (ModelState.IsValid)
                {
                    isUpdated = _profileService.UpdateProfile(model);
                    if (isUpdated)
                    {
                        @TempData["InfoMessage"] = "Saved successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        @TempData["InfoMessage"] = "Unsuccessful";
                    }
                }
                Response.Write("<script>alert('Enter details in all fields');</script>");
               
                return View(model);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred : {ex.Message}", ex);
            }
        }  
                // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var _profile = _profileService.getProfileByID(id);
                if (_profile == null)
                {
                    TempData["InfoMessage"] = "Product Not Available";
                    return RedirectToAction("Index");
                }
                return View(_profile);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred : {ex.Message}", ex);
            }
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                _profileService.DeleteProfile(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred : {ex.Message}", ex);
            }
           }
        
    }
}
