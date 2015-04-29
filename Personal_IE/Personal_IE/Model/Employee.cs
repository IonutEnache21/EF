namespace Personal_IE.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee", Schema = "HR")]
    public class Employee
    {
        [Key]
        public long EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public decimal? CommisionPercent { get; set; }
        [Required]
        public DateTime HireDate { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }


        [Required]
        public long JobId { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }

        public long? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; }

        public long? DepartamentId { get; set; }
        [ForeignKey("DepartamentId")]
        public Department Department { get; set; }
    }
}
