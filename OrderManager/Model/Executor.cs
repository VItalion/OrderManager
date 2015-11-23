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

        [Column("Photo", TypeName = "image")]
        public byte[] Photo { get; set; }

        public string FullName { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
