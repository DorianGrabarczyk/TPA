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
    [Table("AssemblyModel")]

    public class DBAssemblyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssemblyID { get; set; }

        [NotMapped]
        public IEnumerable<DBNamespaceModel> Namespaces { get; set; }
        public List<DBNamespaceModel> NamespacesL { get; set; }
        public string Name { get; set; }

        public void SetValues()
        {
            NamespacesL = Namespaces.ToList();
            foreach (var n in NamespacesL)
            {
                n.SetValues();
            }
        }
    }
}
