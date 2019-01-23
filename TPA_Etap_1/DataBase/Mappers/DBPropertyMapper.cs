using DataBase.Models;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Mappers
{
    public class DBPropertyMapper
    {
        public static DBPropertyModel MapToDB(BasePropertyMetadata propertyMetadata)
        {
            DBPropertyModel propertyModel = new DBPropertyModel
            {
                Name = propertyMetadata.Name,
                TypeMetadata = DBTypeMapper.EmitReferenceDatabase(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<DBPropertyModel> EmitPropertiesDatabase(IEnumerable<BasePropertyMetadata> props)
        {
            return from prop in props
                   select MapToDB(prop);
        }


        public static BasePropertyMetadata MapToBase(DBPropertyModel propertyMetadata)
        {
            BasePropertyMetadata propertyModel = new BasePropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = DBTypeMapper.EmitReferenceDTG(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<BasePropertyMetadata> EmitPropertiesDTG(IEnumerable<DBPropertyModel> props)
        {
            if (props == null) return null;
            return from prop in props
                   select MapToBase(prop);
        }
    }
}
