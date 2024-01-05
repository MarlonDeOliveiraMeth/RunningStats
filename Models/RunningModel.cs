using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace RunningStats.Models
{
    public class RunningModel
    {
        [Key]
        public int RunningId { get; set; }

        [Required]
        [Column(TypeName = "numeric(5)")]
        [Range(0, 99999)]
        public int Meters { get; set; }

        [Required]
        [Column(TypeName = "numeric(4)")]
        [Range(0, 1440)]
        public int Minutes { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}
