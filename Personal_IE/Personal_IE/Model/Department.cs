namespace Personal_IE.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Department", Schema = "HR")]
    public class Department
    {
        //[Key]
        //[Column(Order = 1)]
        //public int DepartmentKey1 { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //public int DepartmentKey2 { get; set; }

        [Key]
        public long DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        public long? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
