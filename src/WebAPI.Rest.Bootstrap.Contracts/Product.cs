﻿namespace WebAPI.Rest.Bootstrap.Contracts
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public decimal ListPrice { get; set; }
    }
}