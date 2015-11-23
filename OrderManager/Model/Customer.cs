using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManager.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column("Photo", TypeName = "image")]
        public byte[] Photo { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
