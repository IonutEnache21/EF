namespace Personal_IE.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Job", Schema = "HR")]
    public class Job
    {
        [Key]
        public long JobId { get; set; }
        [Required]
        public string JobCode { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
    }
}
