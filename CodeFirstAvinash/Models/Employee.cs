using System.ComponentModel.DataAnnotations;

namespace CodeFirstAvinash.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        public string ?Name { get; set; }
        public int Age { get; set; }
        public string ?MobileNo { get; set; }
        public string ?City { get; set; }
        public decimal Salary { get; set; }
        public bool is_Del { get; set; }

    }
}
