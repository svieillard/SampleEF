using System.ComponentModel.DataAnnotations.Schema;

namespace SampleEF.Data.Domain
{
    public class Item : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AdministrationId { get; set; }
        [ForeignKey("AdministrationId")]
        public virtual Administration Administration { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public State State { get; set; }
    }
}
