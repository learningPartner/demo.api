using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.api.Models
{
    public class Employee
    {
        public int empId { get; set; }
        public string empName { get; set; } = string.Empty;
        public string projectName { get; set; } = string.Empty;
    }


    [Table("empBasicTbl")]
    public class EmployeeBasic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empId { get; set; }
        public string empName { get; set; } = string.Empty;
        public string empEmail { get; set; } = string.Empty;
        public string empMobile { get; set; } = string.Empty;
    }

    [Table("empBankTbl")]
    public class EmployeeBank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empBankId { get; set; }
        public int empId { get; set; }
        public string bankName { get; set; } = string.Empty;
        public string accNo { get; set; } = string.Empty;
        public string IfscCode { get; set; } = string.Empty; 
    }

    public class EmployeeViewModel
    {
        public int empId { get; set; }
        public string empName { get; set; } = string.Empty;
        public string empEmail { get; set; } = string.Empty;
        public string empMobile { get; set; } = string.Empty;
        public int empBankId { get; set; } 
        public string bankName { get; set; } = string.Empty;
        public string accNo { get; set; } = string.Empty;
        public string IfscCode { get; set; } = string.Empty;

    } 


}
