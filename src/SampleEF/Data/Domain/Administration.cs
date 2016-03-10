using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Data.Domain
{
    public class Administration : BaseModel
    {
        public Administration()
        {
            Invoices = new HashSet<Invoice>();
            Items = new HashSet<Item>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        [NotMapped]
        public State State { get; set; }
    }
}
