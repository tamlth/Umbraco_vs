using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoMVC.Models;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace UmbracoMVC.Controllers
{
    public class ContactController : SurfaceController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(ContactFormViewModel model, int parentId=0)
        {
            if (ModelState.IsValid && parentId != 0) 
            {
                var _umbracoContentService = Services.ContentService;
                var _umbracoContentTypeService = Services.ContentTypeService;
                
                var parentContent = _umbracoContentService.GetById(parentId);


                var contactContentType = _umbracoContentTypeService
                    .Get(parentContent.ContentTypeId)
                    .AllowedContentTypes
                    .FirstOrDefault();

                var contactContent = _umbracoContentService.Create(
                    "Contact " + DateTime.Now.ToString()
                    , parentId
                    , contactContentType.Alias);

                contactContent.SetValue("contactName", model.Name);
                contactContent.SetValue("contactEmail", model.Email);
                contactContent.SetValue("contactSubject", model.Subject);
                contactContent.SetValue("contactMessage", model.Message);

                var rs = _umbracoContentService.SaveAndPublish(contactContent);
                
                TempData.Add("Success", rs.Result.ToString());

                return RedirectToCurrentUmbracoPage();
            }
            else
            {
                return CurrentUmbracoPage();
            }
        }
    }
}