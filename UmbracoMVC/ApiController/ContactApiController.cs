using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Umbraco.Web.WebApi;
using Umbraco.Web.Mvc;
using UmbracoMVC.Models;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using System.Web.Mvc;
using Umbraco.Web;

namespace UmbracoMVC.ApiController
{
    public class ContactApiController : UmbracoApiController
    {
        [HttpGet]
        public List<ContactFormViewModel> GetAll()
        {
            var _umbracoContentService = Services.ContentService;
            var root = _umbracoContentService.GetRootContent().FirstOrDefault();

            List<ContactFormViewModel> rs = new List<ContactFormViewModel>();
            rs = Umbraco.Content(1071).Children.Select(p=> new ContactFormViewModel
            {
                Name= p.Value<string>("contactName"),
                Email= p.Value<string>("contactEmail"),
                Subject= p.Value<string>("contactSubject"),
                Message= p.Value<string>("contactMessage")
            }).ToList();
            return rs;
        } 
    }
}
