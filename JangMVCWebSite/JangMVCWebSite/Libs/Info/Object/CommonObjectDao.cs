using JangMVCWebSite.Utile.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace JangMVCWebSite.Libs.Info.Object
{
    public class CommonObjectDao
    {
        private void FindItem<T>(string query)
        {
            StringBuilder sb = new StringBuilder(query);
            SingletonDB db = SingletonDB.Instance;
            db.GetDBConnection();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            try
            {
                cmd = new SqlCommand(query);
                reader = cmd.ExecuteReader();
                
            }
            catch (Exception ex)
            {

            }

        }
    }
}