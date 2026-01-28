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
        public string mobile { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string pancard { get; set; } = string.Empty;
        public string aadharcard { get; set; } = string.Empty;
        public bool isActive { get; set; }
    }

    //viewModel
    public class StudentDropdownModel 
    {
        public int studId { get; set; }
        public string studName { get; set; } = string.Empty;
    }


}
