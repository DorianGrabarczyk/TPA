using DataBase.Models;
using DataLayer.DTO;
using Interfaces;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using DataBase.Mappers;

namespace DataBase
{
    [Export("Database",typeof(ISerializer))]
    public class DatabaseSerializer : ISerializer
    {
        public BaseAssemblyMetadata Deserialize(string path)
        {
             using (var context = new DBModelContext())
            {
                context.Assemblies.Load();
                context.Namespaces.Load();
                context.Methods.Load();
                context.Parameters.Load();
                context.Properties.Load();
                context.Types.Load();
                var ret = context.Assemblies.First();
                return DBAssemblyMapper.MapToBase(ret);
            }
            
        }

        public void Serialize(BaseAssemblyMetadata target, string path)
        {
           using (var context = new DBModelContext())
            {
                context.Assemblies.Add(DBAssemblyMapper.MapToDB(target));
                context.SaveChanges();
            }
        }

        
           
    }
}
