using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PositionsEntity
    {
        [Key]
        public int IdPosition { get; set; }
        public string Name { get; set; }

    }
}
