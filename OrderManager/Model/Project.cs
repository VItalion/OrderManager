using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManager.Model
{
    public class Project
    {
        [Key]
        [ForeignKey("Tasks")]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public double PlannedBudget { get; set; }
        public double RealBudget { get; set; }
        public string Executor { get; set; }
        public string Status { get; set; }

        //[InverseProperty("Project")]
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        public Project() { DateOfCompletion = DateTime.Now; }
    }
}
