namespace Domain.Models
{
    public class PeopleModel
    {
        public int? Id { get; set; } 
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int PositionId { get; set; }
    }
}
