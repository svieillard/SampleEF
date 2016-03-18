using Newtonsoft.Json;
using SampleEF.Data;
using SampleEF.Data.Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SampleEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = @"{
'state': 2,
'number': 'SALE-001',
'lines': [
    {'state': 2, 'price': 10, 'quantity': 1, 'item': { 'id': 1, 'description': 'product' } } ,
    {'state': 2, 'price': 10, 'quantity': 1, 'item': { 'id': 1, 'description': 'product' }, 'discountPecentage': 50}
]
}";

            var invoice = JsonConvert.DeserializeObject<Invoice>(json);

            // var item = new Item { Id = 1, Description = "Product" };

            // Invoice is added
            //var invoice = new Invoice
            //{
            //    State = State.Added,
            //    Number = "SALE-001",
            //    Lines =
            //    {
            //        new InvoiceLine
            //        {
            //            State = State.Added,
            //            Price = 10,
            //            Quantity = 1,
            //            Item = new Item { Id = 1, Description = "Product" }
            //            // Item = item
            //        },
            //        new InvoiceLine
            //        {
            //            State = State.Added,
            //            Price = 10,
            //            Quantity = 1,
            //            DiscountPercentage = 50,
            //            Item = new Item { Id = 1, Description = "Product" }
            //            // Item = item
            //        },
            //    }
            //};

            using (var db = new AppContext())
            {
                // Retrieve Administration from DB
                var administration = db.Administrations.Find(1);
                
                // Add detached invoice to administration                
                administration.Invoices.Add(invoice);

                try
                {
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
