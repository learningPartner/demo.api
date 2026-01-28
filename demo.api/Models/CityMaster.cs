using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.api.Models
{
    [Table("cityMasterTbl")]
    public class CityMaster
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cityId { get; set; }
        public string cityName { get; set; } = string.Empty;
    }
}
