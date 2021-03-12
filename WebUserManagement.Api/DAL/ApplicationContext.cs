using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebUserManagement.Api.DAL.Models;

namespace WebUserManagement.Api.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionString) : base(connectionString)
        {

        }

        public ApplicationContext() : base("DbConnection")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}