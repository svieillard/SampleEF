# SampleEF
I've run into the situation where I hoped EF would be smarter than me

Giving the following object:

    var invoice = new Invoice
    {
        State = State.Added,
        Number = "SALE-001",
        Lines =
        {
            new InvoiceLine
            {
                State = State.Added,
                Price = 10,
                Quantity = 1,
                Item = new Item { Id = 1, Description = "Product" }
            },
            new InvoiceLine
            {
                State = State.Added,
                Price = 10,
                Quantity = 1,
                DiscountPercentage = 50,
                Item = new Item { Id = 1, Description = "Product" }
            },
        }
    }
    
Using the pattern to track state locally (e.g. with a BaseModel interface that implements a State property) as described in Programming Entity Framework: DbContext, Chapter 4.

I got stuck when setting the Entries EntityState to align with the local State. Because instantiating the items like you see in the example above, results in two entries for Item in the ChancheTracker with the same Primary Key.

When I try to update the State:

> Saving or accepting changes failed because more than one entity of type 'AutomapperWithEF.Data.Domain.Item' have the same primary key value. Ensure that explicitly set primary key values are unique. Ensure that database-generated primary keys are configured correctly in the database and in the Entity Framework model. Use the Entity Designer for Database First/Model First configuration. Use the 'HasDatabaseGeneratedOption" fluent API or 'DatabaseGeneratedAttribute' for Code First configuration.

Question is: why does EF allows these two entities (actually one entity) but with a different place in memory to exists as seperate in the ChangeTracker? Shouldn't the objects be merged somehow?
