﻿using Microsoft.AspNetCore.Mvc;

using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers;

public class HomeController(IStoreRepository repo) : Controller
{
    private readonly IStoreRepository repository = repo;
    public int PageSize = 4;

    public ViewResult Index(int productPage = 1)
    {
        return View(new ProductsListViewModel
        {
            Products = repository.Products
            .OrderBy(p => p.ProductID)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count()
            }
        });
    }
}
