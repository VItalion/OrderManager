using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OrderManager.ViewModel
{
    class DataContext : DbContext
    {
        public DataContext(string connectionName = "OrdersDbConnection") : base(connectionName) { }
        
        public DbSet<Model.Customer> Customers { get; set; }
        public DbSet<Model.Project> Projects { get; set; }
        public DbSet<Model.Task> Tasks { get; set; }
        public DbSet<Model.Executor> Executors { get; set; }
    }
}