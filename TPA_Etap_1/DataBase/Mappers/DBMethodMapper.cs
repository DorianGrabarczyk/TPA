using DataBase.Models;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Mappers
{
    public class DBMethodMapper
    {
        public static DBMethodModel MapToDB(BaseMethodMetadata methodMetadata)
        {
            DBMethodModel methodModel = new DBMethodModel
            {
                Name = methodMetadata.MethodName,
                GenericArguments = DBTypeMapper.EmitGenericArgumentsDatabase(methodMetadata.GenericArguments),
                ReturnType = EmitReturnTypeDatabase(methodMetadata),
                Parameters = EmitParametersDatabase(methodMetadata.Parameters),
            };
            return methodModel;
        }

        internal static IEnumerable<DBMethodModel> EmitMethodsDatabase(IEnumerable<BaseMethodMetadata> methods)
        {
            return from BaseMethodMetadata _currentMethod in methods
                   select MapToDB(_currentMethod);
        }

        private static IEnumerable<DBParameterModel> EmitParametersDatabase(IEnumerable<BaseParameterMetadata> parms)
        {
            return from parm in parms
                   select DBParameterMapper.MapToDB(parm);
        }
        private static DBTypeModel EmitReturnTypeDatabase(BaseMethodMetadata method)
        {
            BaseMethodMetadata methodInfo = method as BaseMethodMetadata;
            if (methodInfo == null)
                return null;
            return DBTypeMapper.EmitReferenceDatabase(methodInfo.ReturnType);
        }

        public static BaseMethodMetadata MapToBase(DBMethodModel methodMetadata)
        {
            BaseMethodMetadata methodModel = new BaseMethodMetadata
            {
                MethodName = methodMetadata.Name,
                GenericArguments = DBTypeMapper.EmitGenericArgumentsDTG(methodMetadata.GenericArgumentsL),
                ReturnType = EmitReturnTypeDTG(methodMetadata),
                Parameters = EmitParametersDTG(methodMetadata.ParametersL),
            };
            return methodModel;
        }

        internal static IEnumerable<BaseMethodMetadata> EmitMethodsDTG(IEnumerable<DBMethodModel> methods)
        {
            if (methods == null) return null;
            return from DBMethodModel _currentMethod in methods
                   select MapToBase(_currentMethod);
        }

        private static IEnumerable<BaseParameterMetadata> EmitParametersDTG(IEnumerable<DBParameterModel> parms)
        {
            return from parm in parms
                   select DBParameterMapper.MapToBase(parm);
        }
        private static BaseTypeMetadata EmitReturnTypeDTG(DBMethodModel method)
        {
            DBMethodModel methodInfo = method as DBMethodModel;
            if (methodInfo == null)
                return null;
            return DBTypeMapper.EmitReferenceDTG(methodInfo.ReturnType);
        }
    }
}
