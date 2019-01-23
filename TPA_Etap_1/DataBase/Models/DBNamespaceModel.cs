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
    [Table("NamespaceModel")]
    public class DBNamespaceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NamespaceID { get; set; }
        public string NamespaceName { get; set; }
        [NotMapped]
        public IEnumerable<DBTypeModel> Types { get; set; }
        public List<DBTypeModel> TypesL { get; set; }

        public void SetValues()
        {
            TypesL = Types.ToList();
            foreach (var i in TypesL)
            {
                i.SetValue();
            }
        }
    }
}
