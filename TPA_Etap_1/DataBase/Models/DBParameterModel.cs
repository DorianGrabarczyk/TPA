using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    [Table("ParameterModel")]
    public class DBParameterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParameterID { get; set; }
        public string Name { get; set; }
        public DBTypeModel TypeMetadata { get; set; }
    }
}
