using MobileStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.WebUI.Controllers
{
    [AllowAnonymous] 
    public class NavController : Controller
    {
        private IProductRepository repository;

           public NavController(IProductRepository repo)
           { 
                repository = repo;
           }

    public PartialViewResult Menu(string category = null)
    {
          ViewBag.SelectedCategory = category; 
          IEnumerable<string> categories = repository.Products 
          .Select(x => x.ProductType) 
          .Distinct() 
          .OrderBy(x => x); 
          return PartialView(categories); 
        }
    public PartialViewResult Menu1(string categorys = null)
    {
        ViewBag.SelectedCategorys = categorys;
        IEnumerable<string> categories = repository.Products
        .Select(y => y.BrandName)
        .Distinct()
        .OrderBy(y => y);
        return PartialView(categories);
    }

    public PartialViewResult Menu2(string categorys = null)
    {
        ViewBag.SelectedCategorys = categorys;
        IEnumerable<string> categories = repository.Products
        .Select(y => y.Category)
        .Distinct()
        .OrderBy(y => y);
        return PartialView(categories);
    }
    }
} 