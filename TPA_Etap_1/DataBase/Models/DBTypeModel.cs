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
    [Table("TypeModel")]
    public class DBTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string NamespaceName { get; set; }
        public DBTypeModel BaseType { get; set; }
        [NotMapped]
        public IEnumerable<DBTypeModel> GenericArguments { get; set; }
        public List<DBTypeModel> GenericArgumentsL { get; set; }
        //public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        //public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public bool IsGenericType { get; set; }
        [NotMapped]
        public IEnumerable<DBTypeModel> ImplementedInterfaces { get; set; }
        public List<DBTypeModel> ImplementedInterfacesL { get; set; }
        [NotMapped]
        public IEnumerable<DBTypeModel> NestedTypes { get; set; }
        public List<DBTypeModel> NestedTypesL { get; set; }
        [NotMapped]
        public IEnumerable<DBPropertyModel> Properties { get; set; }
        public List<DBPropertyModel> PropertiesL { get; set; }
        public DBTypeModel DeclaringType { get; set; }
        [NotMapped]
        public IEnumerable<DBMethodModel> Methods { get; set; }
        public List<DBMethodModel> MethodsL { get; set; }
        [NotMapped]
        public IEnumerable<DBMethodModel> Constructors { get; set; }
        public List<DBMethodModel> ConstructorsL { get; set; }

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

            ImplementedInterfacesL = ImplementedInterfaces.ToList();
            foreach (var i in ImplementedInterfacesL)
            {
                i.SetValue();
            }

            NestedTypesL = NestedTypes.ToList();
            foreach (var i in NestedTypesL)
            {
                i.SetValue();
            }

            PropertiesL = Properties.ToList();

            MethodsL = Methods.ToList();
            foreach (var i in MethodsL)
            {
                i.SetValue();
            }

            ConstructorsL = Constructors.ToList();
            foreach (var i in ConstructorsL)
            {
                i.SetValue();
            }
        }
        #region lol
        //public static Dictionary<string, DBTypeModel> TypeDictionary = new Dictionary<string, DBTypeModel>();

        //[Key, StringLength(150)]
        //public  string Name { get; set; }

        //public  string AssemblyName { get; set; }

        //public  bool IsExternal { get; set; }

        //public  bool IsGeneric { get; set; }

        //public  DBTypeModel BaseType { get; set; }


        //public  DBTypeModel DeclaringType { get; set; }



        //public int? NamespaceId { get; set; }

        //public  IEnumerable<DBMethodModel> Constructors { get; set; }


        //public  IEnumerable<DBTypeModel> GenericArguments { get; set; }

        //public  IEnumerable<DBTypeModel> ImplementedInterfaces { get; set; }

        //public  IEnumerable<DBMethodModel> Methods { get; set; }

        //public  IEnumerable<DBTypeModel> NestedTypes { get; set; }

        //public  IEnumerable<DBPropertyModel> Properties { get; set; }


        //[InverseProperty("BaseType")]
        //public  ICollection<DBTypeModel> TypeBaseTypes { get; set; }

        //[InverseProperty("DeclaringType")]
        //public  ICollection<DBTypeModel> TypeDeclaringTypes { get; set; }

        //public  ICollection<DBMethodModel> MethodGenericArguments { get; set; }

        //public  ICollection<DBTypeModel> TypeGenericArguments { get; set; }

        //public  ICollection<DBTypeModel> TypeImplementedInterfaces { get; set; }

        //public  ICollection<DBTypeModel> TypeNestedTypes { get; set; }


        //public TypeKind TypeKind { get; set; }

        //public DBTypeModel()
        //{
        //    MethodGenericArguments = new HashSet<DBMethodModel>();
        //    TypeGenericArguments = new HashSet<DBTypeModel>();
        //    TypeImplementedInterfaces = new HashSet<DBTypeModel>();
        //    TypeNestedTypes = new HashSet<DBTypeModel>();
        //    Constructors = new List<DBMethodModel>();

        //    GenericArguments = new List<DBTypeModel>();
        //    ImplementedInterfaces = new List<DBTypeModel>();
        //    Methods = new List<DBMethodModel>();
        //    NestedTypes = new List<DBTypeModel>();
        //    Properties = new List<DBPropertyModel>();
        //}

        //public DBTypeModel(BaseTypeMetadata typeBase)
        //{
        //    if (!TypeDictionary.ContainsKey(typeBase.TypeName))
        //    {
        //        TypeDictionary.Add(typeBase.TypeName, this);
        //    }
        //    Name = typeBase.TypeName;
        //   // NamespaceName = typeBase.NamespaceName;
        //    TypeKind = typeBase.TypeKind;

        //    BaseType = GetOrAdd(typeBase.BaseType);
        //    DeclaringType = GetOrAdd(typeBase.DeclaringType);

        //   // Modifiers = new Tuple<AccessLevel, SealedEnum, AbstractEnum>(typeBase.Modifiers.Item1, typeBase.Modifiers.Item2, typeBase.Modifiers.Item3);

        //    Constructors = typeBase.Constructors?.Select(c => new DBMethodModel(c));
        //    GenericArguments = typeBase.GenericArguments?.Select(GetOrAdd);
        //    ImplementedInterfaces = typeBase.ImplementedInterfaces?.Select(GetOrAdd);
        //    Methods = typeBase.Methods?.Select(m => new DBMethodModel(m));
        //    NestedTypes = typeBase.NestedTypes?.Select(GetOrAdd);
        //    Properties = typeBase.Properties?.Select(p => new DBPropertyModel(p));

        //}

        //public static DBTypeModel GetOrAdd(BaseTypeMetadata baseType)
        //{
        //    if (baseType != null)
        //    {
        //        if (TypeDictionary.ContainsKey(baseType.TypeName))
        //        {
        //            return TypeDictionary[baseType.TypeName];
        //        }
        //        else
        //        {
        //            return new DBTypeModel(baseType);
        //        }
        //    }
        //    else
        //        return null;
        //}
        #endregion 
    }
}
