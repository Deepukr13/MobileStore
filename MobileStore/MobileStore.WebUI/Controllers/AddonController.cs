using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System.Web.Mvc;
using MobileStore.WebUI.Models;

namespace MobileStore.WebUI.Controllers
{
    [AllowAnonymous]
    public class AddonController : Controller
    {
        private IAddonRepository objcontext;
        public AddonController(IAddonRepository addonRepository) 
        {
            this.objcontext = addonRepository;
        
        }

        public ActionResult Index()
        {
            return View(objcontext.Addons);
        }

    }
}
