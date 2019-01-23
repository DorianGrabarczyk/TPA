using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataBase
{
    public class DBMessageRepo
    {
        public void AddMessage(string message)
        {
            DBMessage databaseMessage = new DBMessage
            {
                MessageString = message
            };
            using (var context = new DBModelContext(ConfigurationManager.AppSettings["connectionstring"]))
            {
                context.Messages.Add(databaseMessage);
                context.SaveChanges();
            }
        }
    }
}
