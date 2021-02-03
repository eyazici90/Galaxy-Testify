using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApp
{

    public static class Sample
    {
        public class Fake
        {
            readonly IDependency1 _dependency1;
            readonly IDependency2 _dependency2;
            readonly IDependency3 _dependency3;
            readonly IDependency4 _dependency4;

            public Fake(IDependency1 dependency1,
                IDependency2 dependency2,
                IDependency3 dependency3,
                IDependency4 dependency4)
            {
                _dependency1 = dependency1;
                _dependency2 = dependency2;
                _dependency3 = dependency3;
                _dependency4 = dependency4;
            }

            public async Task<string> Handle(Message msg)
            {
                _ = await _dependency1.DoSomething();
                _ = await _dependency2.DoSomething();
                _ = await _dependency3.DoSomething();
                _ = await _dependency4.DoSomething();

                return msg.Name.ToUpper();
            }
        }
        public class Message
        {
            public string Name { get; set; }
        }

        public interface IDependency1
        {
            Task<string> DoSomething();
        }
        public interface IDependency2
        {
            Task<string> DoSomething();
        }
        public interface IDependency3
        {
            Task<string> DoSomething();
        }
        public interface IDependency4
        {
            Task<string> DoSomething();
        }

        public class Customer
        {
            public string Name { get; set; }
            public string AccountNumber { get; set; }
            public int LocationId { get; set; }
        }
        public class Order
        {
            public DateTime Created { get; set; }
            public string Status { get; set; }
            public Customer Customer { get; set; }
            public IEnumerable<Product> Products { get; set; }
        }

        public class Product
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        public class OrderService
        {
            public async Task Add(Order order)
            {
                //do somethings
            }
        }
    }

}
