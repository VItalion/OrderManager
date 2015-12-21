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
                
        public virtual Project Project { get; set; }     
        
        public Task()
        {
            DateOfCompletion = DateTime.Now;
            Executor = new Executor();
            Project = new Project();
        }   
        public Task(Task task)
        {
            if (task != null)
            {
                Id = task.Id;
                Name = task.Name;
                DateOfCompletion = task.DateOfCompletion;
                Status = task.Status;
                if (Executor != null)
                    Executor = new Executor(task.Executor);
                else
                    Executor = new Executor();
                if (Project != null)
                    Project = new Project(task.Project);
                else
                    Project = new Project();
            }
        }
    }
}
