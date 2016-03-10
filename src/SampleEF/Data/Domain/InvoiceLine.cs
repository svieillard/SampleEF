using System.ComponentModel.DataAnnotations.Schema;

namespace SampleEF.Data.Domain
{
    public class InvoiceLine : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        [NotMapped]
        public State State { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
