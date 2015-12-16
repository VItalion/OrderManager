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

        [MaxLength]
        [Column("Photo", TypeName = "image")]
        public byte[] Photo { get; set; }

        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
