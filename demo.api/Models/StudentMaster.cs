using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace demo.api.Models
{
    [Table("studentMasterTbl")]
    public class StudentMaster
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studId { get; set; } 
        public string studName { get; set; }   = string.Empty;
        [Required(ErrorMessage = "Mobile number is required")]
        [MaxLength(10)]
        [MinLength(10)]
        public string mobile { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        [RegularExpression(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN card number")]
        public string pancard { get; set; } = string.Empty;
        [Required]
        [MaxLength(12)]
        public string aadharcard { get; set; } = string.Empty;
        public bool isActive { get; set; }
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    //viewModel
    public class StudentDropdownModel 
    {
        public int studId { get; set; }
        public string studName { get; set; } = string.Empty;
    }

    public class StudentFilterMiodel
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string sortBy { get; set; } = "studName";
        public string sortDirection { get; set; } = "asc";
        public string? studName { get; set; }
        public string? mobile { get; set; }
        public string? email { get; set; }
    }

    public class StudentLoginModel
    {
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    public class LoginResponseModel
    {
        public int studId { get; set; }
        public string studName { get; set; } = string.Empty;
        public string mobile { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
    }

    public class LoginReturnModel
    {
        public int studId { get; set; }
        public string studName { get; set; } = string.Empty;
        public string mobile { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }

}
