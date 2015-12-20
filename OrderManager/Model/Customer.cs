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
        
        public Customer()
        {
            Projects = new List<Project>();
        }
        public Customer(Customer customer)
        {
            if (customer != null)
            {
                Id = customer.Id;
                FullName = customer.FullName;
                Country = customer.Country;
                City = customer.City;
                Street = customer.Street;
                if (customer.Projects != null)
                    Projects = new List<Project>(customer.Projects);
                else
                    Projects = new List<Project>();
                if (customer.Photo != null)
                {
                    Photo = new byte[customer.Photo.Length];
                    customer.Photo.CopyTo(Photo, 0);
                }
            }
        }
    }
}
