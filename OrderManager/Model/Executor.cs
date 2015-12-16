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
    }
}
