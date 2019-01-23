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
    [Table("PropertyModel")]
    public class DBPropertyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyID { get; set; }
        public string Name { get; set; }
        //[NotMapped]
        public DBTypeModel TypeMetadata { get; set; }
        public ICollection<DBTypeModel> TypesProperties { get; set; }
    }
}

