using DataBase.Models;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Mappers
{
    public class DBAssemblyMapper
    {
        public static DBAssemblyModel MapToDB(BaseAssemblyMetadata assemblyMetadata)
        {
            Dictionares.ResetDictonaries();

            DBAssemblyModel assemblyModel = new DBAssemblyModel
            {
                Name = assemblyMetadata.AssemblyName,
                Namespaces = from BaseNamespaceMetadata _namespaces in assemblyMetadata.Namespaces
                             select DBNamespaceMapper.MapToDB(_namespaces)
            };
            assemblyModel.SetValues();
            return assemblyModel;
        }

        public static BaseAssemblyMetadata MapToBase(DBAssemblyModel assemblyMetadata)
        {
            Dictionares.ResetDictonaries();

            BaseAssemblyMetadata assemblyModel = new BaseAssemblyMetadata
            {
                AssemblyName = assemblyMetadata.Name,
                Namespaces = from DBNamespaceModel _namespace in assemblyMetadata.NamespacesL
                             select DBNamespaceMapper.MapToBase(_namespace)
            };
            return assemblyModel;
        }

    }
}
