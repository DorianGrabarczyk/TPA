using DataBase.Models;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Mappers
{
    public class DBNamespaceMapper
    {
        public static DBNamespaceModel MapToDB(BaseNamespaceMetadata namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;           
            foreach (var type in namespaceMetadata.Types)
            {
                Dictionares.TypeDictonaryToDatabase[type] = DBTypeMapper.MapToDB(type);
            }
            var m_Types = from type in namespaceMetadata.Types orderby type.TypeName select DBTypeMapper.FillTypeDatabase(Dictionares.TypeDictonaryToDatabase[type], type);
            foreach (var t in m_Types)
            {
                t.NamespaceName = m_NamespaceName;
            }
            DBNamespaceModel namespaceModel = new DBNamespaceModel
            {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };

            return namespaceModel;
        }
        public static BaseNamespaceMetadata MapToBase(DBNamespaceModel namespaceMetadata)
        {
            var m_NamespaceName = namespaceMetadata.NamespaceName;            
            foreach (var type in namespaceMetadata.TypesL)
            {
                Dictionares.TypeDictonaryToDTG[type] = DBTypeMapper.MapToBase(type);
            }
            var m_Types = from type in namespaceMetadata.TypesL orderby type.TypeName select DBTypeMapper.fillType(Dictionares.TypeDictonaryToDTG[type], type);
            BaseNamespaceMetadata namespaceModel = new BaseNamespaceMetadata
            {
                NamespaceName = m_NamespaceName,
                Types = m_Types
            };
            return namespaceModel;
        }
    }
}
