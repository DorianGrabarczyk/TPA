using DataBase.Models;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Mappers
{
    public class DBParameterMapper
    {
        public static DBParameterModel MapToDB(BaseParameterMetadata parameterMetadata)
        {
            DBParameterModel parameterModel = new DBParameterModel
            {
                Name = parameterMetadata.ParameterName,
                TypeMetadata = DBTypeMapper.EmitReferenceDatabase(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }

        public static BaseParameterMetadata MapToBase(DBParameterModel parameterMetadata)
        {
            BaseParameterMetadata parameterModel = new BaseParameterMetadata
            {
                ParameterName = parameterMetadata.Name,
                TypeMetadata = DBTypeMapper.EmitReferenceDTG(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }
    }
}
