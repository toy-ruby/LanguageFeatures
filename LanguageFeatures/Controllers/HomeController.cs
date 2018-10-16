using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();

            //foreach (Product p in Product.GetProducts())
            //{
            //    string name = p?.Name ?? "<No name>";
            //    decimal? price = p?.Price ?? 0;
            //    string relatedName = p?.Related?.Name ?? "<None>";
            //    results.Add($"Name: {name}, Price: {price}, Related item: {relatedName}");
            //}

            //return View(results);
            bool FilterByPrice(Product p)
            {
                return (p?.Price ?? 0) >= 20;
            }

            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M },
                new Product {Name = "Soccer Ball", Price = 19.50M },
                new Product {Name = "Corner Flag", Price = 34.95M },
            };

            //decimal cartTotal = cart.TotalPrices();
            //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();

            decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

            return View("Index", new string[]
            {
                $"Price Total: {priceFilterTotal:C2}",
                $"Name Total: {nameFilterTotal:C2}"
            });
        }
    }
}
