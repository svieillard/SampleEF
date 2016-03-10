using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Data.Domain
{
    public class Invoice : BaseModel
    {
        public Invoice()
        {
            Lines = new HashSet<InvoiceLine>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AdministrationId { get; set; }
        [ForeignKey("AdministrationId")]
        public virtual Administration Administration { get; set; }
        public string Number { get; set; }
        public virtual ICollection<InvoiceLine> Lines { get; set; }
        [NotMapped]
        public State State { get; set; }
    }
}
