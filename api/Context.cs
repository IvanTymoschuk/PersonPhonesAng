namespace api
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        // Your context has been configured to use a 'Context' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'api.Context' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Context' 
        // connection string in the application configuration file.
        public Context()
            : base("name=Context")
        {
            Database.SetInitializer<Context>(new CustomInit<Context>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<PersonPhone> Phones { get; set; }
    }

    internal class CustomInit<T> : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);
            context.Phones.Add(
                new PersonPhone()
                {
                    FirstName = "Andriy",
                    LastName = "Shevchenko",
                    AvaPath = "https://replyua.net/uploads/posts/2015-03/1427211970_andrey-shevchenko.jpg",
                    BirthDate = new DateTime(1974, 8, 5),
                    Phone = "380937733737"
                }
            );
            context.Phones.Add(
                new PersonPhone()
                {
                    FirstName = "Donald",
                    LastName = "Trump",
                    AvaPath = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Donald_Trump_official_portrait_%28cropped%29.jpg/742px-Donald_Trump_official_portrait_%28cropped%29.jpg",
                    BirthDate = new DateTime(1950, 1, 1),
                    Phone = "999999999900"
                }
            );
            context.Phones.Add(
                new PersonPhone()
                {
                    FirstName = "Andriy",
                    LastName = "Yarmolenko",
                    AvaPath = "https://s.ill.in.ua/i/news/630x373/369/369135.jpg",
                    BirthDate = new DateTime(1989, 5, 4),
                    Phone = "3809900000001"
                }
            );
        }
    }

    public class PersonPhone
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string AvaPath { get; set; }
        public string Phone { get; set; }
    }
}