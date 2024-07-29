using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PeopleEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int PositionId {  get; set; }
        [ForeignKey("PositionId")]
        public virtual PositionsEntity PositionsEntity { get; set; }

    }
}
