﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Models;    // Added
using System.Web.Caching;   // Added for caching of db

namespace HelloWorld
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }

    public class ProductRepository : IProductRepository
    {
        private static IEnumerable<Product> products;

        // Data Hardcoded in until linked to db
        public IEnumerable<Product> Products
        {
            get
            {
                if(HttpContext.Current.Cache["MyProducts"] == null) // if statement for caching
                {
                    var items = new[]
                    {
                    new Product{ ProductId=101, Name = "Baseball", Description="ball", Price=14.20m, ProductCount = 0},
                    new Product{ ProductId=102, Name="Football", Description="nfl", Price=9.24m, ProductCount = 1},
                    new Product{ ProductId=103, Name="Tennis ball", Description="ball", Price=5.00m, ProductCount = 15} ,
                    new Product{ ProductId=104, Name="Golf ball", Description="ball", Price=40.99m, ProductCount = 10},
                    };

                    // stores caching for 30 sec
                    HttpContext.Current.Cache.Insert("MyProducts",
                                             items,
                                             null,
                                             DateTime.Now.AddSeconds(30),
                                             Cache.NoSlidingExpiration);
                }

                return (IEnumerable<Product>)HttpContext.Current.Cache["MyProducts"];
            }
        }
    }
}