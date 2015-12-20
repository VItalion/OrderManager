using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model
{
    public class Executor
    {
        [Key]
        public int Id { get; set; }

        [MaxLength]
        [Column("Photo", TypeName = "image")]
        public byte[] Photo { get; set; }

        public string FullName { get; set; }
        
        public string Email { get; set; }
        public string Skype { get; set; }
        public string PhoneNumber { get; set; }        

        public virtual ICollection<Task> Tasks { get; set; }

        public Executor(Executor executor)
        {
            if(executor != null)
            {
                Id = executor.Id;
                FullName = executor.FullName;
                Email = executor.Email;
                PhoneNumber = executor.PhoneNumber;
                Skype = executor.Skype;
                if (executor.Tasks != null)
                    Tasks = new List<Task>(executor.Tasks);
                else
                    Tasks = new List<Task>();
                if (executor.Photo != null)
                {
                    Photo = new byte[executor.Photo.Length];
                    executor.Photo.CopyTo(Photo, 0);
                }
            }                
        }
        public Executor()
        {
            this.Tasks = new List<Task>();
        }
    }
}
