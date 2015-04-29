namespace Personal_IE.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Location", Schema = "HR")]
    public class Location
    {
        [Key]
        public long LocationId { get; set; }
        public string StreetAddress { get; set; }
        [StringLength(6)]
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
    }
}
