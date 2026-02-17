using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.api.Models
{
    [Table("countryMaster")]
    public class CountryMaster
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int countryId { get; set; }
        public string countryName { get; set; } = string.Empty;

    }
    [Table("stateMaster")]
    public class StateMaster
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stateId { get; set; }
        public string stateName { get; set; } = string.Empty;
        public int countryId { get; set; }

    }
    [Table("districtMaster")]
    public class DistrictMaster
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int districtId { get; set; }
        public string districtName { get; set; } = string.Empty;

        public int stateId { get; set; }

    }
}
