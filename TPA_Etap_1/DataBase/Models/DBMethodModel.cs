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
    [Table("MethodModel")]
    public class DBMethodModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MethodID { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [NotMapped]
        public IEnumerable<DBTypeModel> GenericArguments { get; set; }
        [Column("GenericArguments")]
        public List<DBTypeModel> GenericArgumentsL { get; set; }
        [Column("ReturnType")]
        public DBTypeModel ReturnType { get; set; }
        [NotMapped]
        public IEnumerable<DBParameterModel> Parameters { get; set; }
        [Column("Parameters")]
        public List<DBParameterModel> ParametersL { get; set; }

        public void SetValue()
        {
            if (GenericArguments == null)
            {
                GenericArgumentsL = null;
            }
            else
            {
                GenericArgumentsL = GenericArguments.ToList();
                foreach (var i in GenericArgumentsL)
                {
                    i.SetValue();
                }
            }

            ParametersL = Parameters.ToList();
        }
        #region lol1
        //public DBMethodModel()
        //{
        //    GenericArguments = new List<DBTypeModel>();
        //    Parameters = new List<DBParameterModel>();
        //    TypeConstructors = new HashSet<DBTypeModel>();
        //    TypeMethods = new HashSet<DBTypeModel>();
        //}
        //[Key]
        //public int Id { get; set; }
        //[Required]
        //[StringLength(100)]
        //public string MethodName { get; set; }

        //public IEnumerable<DBTypeModel> GenericArguments { get; set; }


        //public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> Modifiers { get; set; }


        //public DBTypeModel ReturnType { get; set; }

        //public bool Extension { get; set; }


        //public IEnumerable<DBParameterModel> Parameters { get; set; }
        //public virtual ICollection<DBTypeModel> TypeConstructors { get; set; }

        //public virtual ICollection<DBTypeModel> TypeMethods { get; set; }

        //public DBMethodModel(BaseMethodMetadata methodBase)
        //{
        //    MethodName = methodBase.MethodName;
        //    Extension = methodBase.Extension;
        //    ReturnType = DBTypeModel.GetOrAdd(methodBase.ReturnType);
        //    Modifiers = new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(methodBase.Modifiers.Item1, methodBase.Modifiers.Item2, methodBase.Modifiers.Item3, methodBase.Modifiers.Item4);
        //    GenericArguments = methodBase.GenericArguments?.Select(g => DBTypeModel.GetOrAdd(g));
        //    Parameters = methodBase.Parameters?.Select(p => new DBParameterModel(p));

        //}
        #endregion lol
    }
}
