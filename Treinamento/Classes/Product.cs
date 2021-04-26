using Bogus;
using System;
using System.Collections.Generic;
using Treinamento.Enum;

namespace Treinamento.Classes
{
    public class Product
    {
        public int Code { get; protected set; }
        public string Name { get; protected set; }
        public string BrandName { get; protected set; }
        public TypeProduct TypeProduct { get; protected set; }
        public int UnitsPerBox { get; protected set; }
        public decimal UnitPrice { get; protected set; }
        public decimal BoxPrice => UnitPrice * UnitsPerBox;

        public Product(int code, string name, string brandName, TypeProduct typeProduct, int unitsPerBox, decimal unitPrice)
        {
            Code = code;
            Name = name;
            BrandName = brandName;
            TypeProduct = typeProduct;
            UnitsPerBox = unitsPerBox;
            UnitPrice = unitPrice;
        }

        public override string ToString()
        {
            return $"Product: {Name}, Unit Price: {UnitPrice}, Box Price: {BoxPrice}";
        }

        public static IEnumerable<Product> GenerateNewProducts()
        {
            return new Faker<Product>()
                .CustomInstantiator(x => new Product(x.Random.Int(min: 1, max: 10000),
                                                     x.Commerce.ProductName(),
                                                     x.Commerce.ProductMaterial(),
                                                     x.PickRandom<TypeProduct>(),
                                                     x.Random.Int(1, 24),
                                                     Convert.ToDecimal(x.Commerce.Price()))
                                                     ).Generate(50);
        }
    }
}
