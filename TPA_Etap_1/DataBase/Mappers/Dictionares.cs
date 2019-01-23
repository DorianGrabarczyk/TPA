using DataBase.Models;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Mappers
{
    public class Dictionares
    {
        private static Dictionary<BaseTypeMetadata, DBTypeModel> typeDictonaryToDatabase = new Dictionary<BaseTypeMetadata, DBTypeModel>();
        public static Dictionary<BaseTypeMetadata, DBTypeModel> TypeDictonaryToDatabase { get => typeDictonaryToDatabase; set => typeDictonaryToDatabase = value; }

        private static Dictionary<DBTypeModel, BaseTypeMetadata> typeDictonaryToDTG = new Dictionary<DBTypeModel, BaseTypeMetadata>();
        public static Dictionary<DBTypeModel, BaseTypeMetadata> TypeDictonaryToDTG { get => typeDictonaryToDTG; set => typeDictonaryToDTG = value; }

        public static void ResetDictonaries()
        {
            typeDictonaryToDatabase.Clear();
            typeDictonaryToDTG.Clear();
        }
    }
}
