using DataBase.Models;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Mappers
{
    public class DBTypeMapper
    {
        public static DBTypeModel MapToDB(BaseTypeMetadata typeMetadata)
        {
            DBTypeModel DatabaseTypeMetadata = new DBTypeModel
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringTypeDatabase(typeMetadata.DeclaringType),
                Constructors = DBMethodMapper.EmitMethodsDatabase(typeMetadata.Constructors),
                Methods = DBMethodMapper.EmitMethodsDatabase(typeMetadata.Methods),
                NestedTypes = EmitNestedTypesDatabase(typeMetadata.NestedTypes),
                ImplementedInterfaces = EmitImplementsDatabase(typeMetadata.ImplementedInterfaces),
                GenericArguments = CheckGenericArgumentsDatabase(typeMetadata),
                BaseType = EmitExtendsDatabase(typeMetadata.BaseType),
                Properties = DBPropertyMapper.EmitPropertiesDatabase(typeMetadata.Properties),
            };

            return DatabaseTypeMetadata;
        }

        public static DBTypeModel FillTypeDatabase(DBTypeModel DTGTypeMetadata, BaseTypeMetadata typeMetadata)
        {
            DTGTypeMetadata.TypeName = typeMetadata.TypeName;
            DTGTypeMetadata.DeclaringType = EmitDeclaringTypeDatabase(typeMetadata.DeclaringType);
            DTGTypeMetadata.Constructors = DBMethodMapper.EmitMethodsDatabase(typeMetadata.Constructors);
            DTGTypeMetadata.Methods = DBMethodMapper.EmitMethodsDatabase(typeMetadata.Methods);
            DTGTypeMetadata.NestedTypes = EmitNestedTypesDatabase(typeMetadata.NestedTypes);
            DTGTypeMetadata.ImplementedInterfaces = EmitImplementsDatabase(typeMetadata.ImplementedInterfaces);
            if (typeMetadata.GenericArguments != null)
                DTGTypeMetadata.GenericArguments = EmitGenericArgumentsDatabase(typeMetadata.GenericArguments);
            else DTGTypeMetadata.GenericArguments = null;
            //DTGTypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            DTGTypeMetadata.BaseType = EmitExtendsDatabase(typeMetadata.BaseType);
            DTGTypeMetadata.Properties = DBPropertyMapper.EmitPropertiesDatabase(typeMetadata.Properties);

            return DTGTypeMetadata;
        }

        public static IEnumerable<DBTypeModel> CheckGenericArgumentsDatabase(BaseTypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArguments != null)
                return EmitGenericArgumentsDatabase(typeMetadata.GenericArguments);
            return null;
        }

        internal static DBTypeModel EmitReferenceDatabase(BaseTypeMetadata type)
        {
            if (type == null) return null;
            if (Dictionares.TypeDictonaryToDatabase.ContainsKey(type))
            {
                return Dictionares.TypeDictonaryToDatabase[type];
            }

            return MapToDB(type);
        }
        internal static IEnumerable<DBTypeModel> EmitGenericArgumentsDatabase(IEnumerable<BaseTypeMetadata> arguments)
        {
            if (arguments == null) return null;
            return from BaseTypeMetadata _argument in arguments select EmitReferenceDatabase(_argument);
        }

        private static DBTypeModel EmitDeclaringTypeDatabase(BaseTypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceDatabase(declaringType);
        }
        private static IEnumerable<DBTypeModel> EmitNestedTypesDatabase(IEnumerable<BaseTypeMetadata> nestedTypes)
        {
            return from _type in nestedTypes
                   select MapToDB(_type);
        }
        private static IEnumerable<DBTypeModel> EmitImplementsDatabase(IEnumerable<BaseTypeMetadata> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReferenceDatabase(currentInterface);
        }
        private static DBTypeModel EmitExtendsDatabase(BaseTypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceDatabase(baseType);
        }


        public static BaseTypeMetadata MapToBase(DBTypeModel typeMetadata)
        {
            BaseTypeMetadata DatabaseTypeMetadata = new BaseTypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType),
                Constructors = DBMethodMapper.EmitMethodsDTG(typeMetadata.ConstructorsL),
                Methods = DBMethodMapper.EmitMethodsDTG(typeMetadata.MethodsL),
                NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypesL),
                ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfacesL),
                GenericArguments = CheckGenericArgumentsDTG(typeMetadata),
                BaseType = EmitExtendsDTG(typeMetadata.BaseType),
                Properties = DBPropertyMapper.EmitPropertiesDTG(typeMetadata.PropertiesL),

            };

            return DatabaseTypeMetadata;
        }

        public static BaseTypeMetadata fillType(BaseTypeMetadata DTGTypeMetadata, DBTypeModel typeMetadata)
        {
            DTGTypeMetadata.TypeName = typeMetadata.TypeName;
            DTGTypeMetadata.DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType);
            DTGTypeMetadata.Constructors = DBMethodMapper.EmitMethodsDTG(typeMetadata.ConstructorsL);
            DTGTypeMetadata.Methods = DBMethodMapper.EmitMethodsDTG(typeMetadata.MethodsL);
            DTGTypeMetadata.NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypesL);
            DTGTypeMetadata.ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfacesL);
            if (typeMetadata.GenericArguments != null)
                DTGTypeMetadata.GenericArguments = EmitGenericArgumentsDTG(typeMetadata.GenericArguments);
            else DTGTypeMetadata.GenericArguments = null;
            //DTGTypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            DTGTypeMetadata.BaseType = EmitExtendsDTG(typeMetadata.BaseType);
            DTGTypeMetadata.Properties = DBPropertyMapper.EmitPropertiesDTG(typeMetadata.PropertiesL);

            return DTGTypeMetadata;
        }

        public static IEnumerable<BaseTypeMetadata> CheckGenericArgumentsDTG(DBTypeModel typeMetadata)
        {
            if (typeMetadata.GenericArgumentsL != null)
                return EmitGenericArgumentsDTG(typeMetadata.GenericArgumentsL);
            return null;
        }

        internal static BaseTypeMetadata EmitReferenceDTG(DBTypeModel type)
        {
            if (type == null) return null;
            if (Dictionares.TypeDictonaryToDTG.ContainsKey(type))
            {
                return Dictionares.TypeDictonaryToDTG[type];
            }

            return MapToBase(type);
        }
        internal static IEnumerable<BaseTypeMetadata> EmitGenericArgumentsDTG(IEnumerable<DBTypeModel> arguments)
        {
            if (arguments == null) return null;
            return from DBTypeModel _argument in arguments select EmitReferenceDTG(_argument);
        }

        private static BaseTypeMetadata EmitDeclaringTypeDTG(DBTypeModel declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceDTG(declaringType);
        }
        private static IEnumerable<BaseTypeMetadata> EmitNestedTypesDTG(IEnumerable<DBTypeModel> nestedTypes)
        {
            if (nestedTypes == null) return null;
            return from _type in nestedTypes
                   select MapToBase(_type);
        }
        private static IEnumerable<BaseTypeMetadata> EmitImplementsDTG(IEnumerable<DBTypeModel> interfaces)
        {
            if (interfaces == null) return null;
            return from currentInterface in interfaces
                   select EmitReferenceDTG(currentInterface);
        }
        private static BaseTypeMetadata EmitExtendsDTG(DBTypeModel baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceDTG(baseType);
        }
    }
}
