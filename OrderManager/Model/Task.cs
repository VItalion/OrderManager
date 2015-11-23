using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManager.Model
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime DateOfCompletion { get; set; }        
        public string Status { get; set; }

        public virtual Executor Executor { get; set; }
        public virtual Project Project { get; set; }

        public Task() { DateOfCompletion = DateTime.Now; }
    }
}
