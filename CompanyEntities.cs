using PATHETIKKKKK.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace PATHETIKKKKK
{
    public class CompanyEntities : DbContext
    {
        // Your context has been configured to use a 'CompanyEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PATHETIKKKKK.CompanyEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CompanyEntities' 
        // connection string in the application configuration file.
        public CompanyEntities()
            : base("name=CompanyEntities")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}