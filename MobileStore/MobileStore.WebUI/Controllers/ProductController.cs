using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Domain.Entities;
using MobileStore.Domain.Abstract;
using MobileStore.WebUI.Models;

namespace MobileStore.WebUI.Controllers
{
    [AllowAnonymous] 
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.ProductType == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.ProductType == category).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);  
        }

        public ViewResult Blist(string categorys, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => categorys == null || p.BrandName == categorys)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = categorys == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.BrandName == categorys).Count()
                },
                CurrentCategory = categorys
            };
            return View(model);
        }

        public ViewResult Index1(string categorys, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => categorys == null || p.Category == categorys)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = categorys == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category == categorys).Count()
                },
                CurrentCategory = categorys
            };
            return View(model);
        }
        public ViewResult Product(int id)
        {
            Product product = repository.Products.Where(p => p.ProductID == id).SingleOrDefault();
            return View(product);
        }
        public ViewResult Details(int productID)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productID);

            return View(product);
        }
    } 
} 