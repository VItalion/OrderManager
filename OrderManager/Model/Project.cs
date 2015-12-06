using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManager.Model
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public double PlannedBudget { get; set; }
        public double RealBudget { get; set; }
        public string Executor { get; set; }
        public string Status { get; set; }
        
        public ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        public Project() { DateOfCompletion = DateTime.Now; }
    }
}
