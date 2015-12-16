using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //[InverseProperty("Tasks")]
        public virtual Project Project { get; set; }        
    }
}
