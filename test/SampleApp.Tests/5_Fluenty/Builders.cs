using Galaxy.Testify;
using System;
using System.Collections.Generic;
using System.Linq;
using static SampleApp.Sample;

namespace SampleApp.Tests._5_Fluenty
{
    public static class Builders
    {
        public class OrderBuilder : IFluentBuilder<OrderBuilder>
        {
            private Order _order = new Order();

            public OrderBuilder CreatedAt(DateTime dateTime)
            {
                _order.Created = dateTime;
                return this;
            }

            public OrderBuilder StatedAs(string status)
            {
                _order.Status = status;
                return this;
            }
            public OrderBuilder Customer()
            {
                _order.Customer = new Customer();
                return this;
            }

            public OrderBuilder Named(string name)
            {
                _order.Customer.Name = name;
                return this;
            }

            public OrderBuilder LocatedAt(int locationId)
            {
                _order.Customer.LocationId = locationId;
                return this;
            }
            public OrderBuilder AccountNumber(string accountNumber)
            {
                _order.Customer.AccountNumber = accountNumber;
                return this;
            }
            public OrderBuilder Product(Product product)
            {
                _order.Products ??= new List<Product>();
                _order.Products.ToList().Add(product);
                return this;
            }

            public OrderBuilder By => this;

            public Order Build() => _order;

        }

        public class ProductBuilder : IFluentBuilder<ProductBuilder>
        {
            private Product _product = new Product();
            public ProductBuilder Code(string code)
            {
                _product.Code = code;
                return this;
            }

            public ProductBuilder Named(string name)
            {
                _product.Name = name;
                return this;
            }
            public Product Build() => _product;
        }

    }
}
