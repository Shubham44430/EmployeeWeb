using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrmsApi.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("emp_id")]
        public int EmpId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("salary")]
        public double Salary { get; set; }
    }
}