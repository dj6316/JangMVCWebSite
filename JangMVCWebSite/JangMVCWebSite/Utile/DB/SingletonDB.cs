using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JangMVCWebSite.Utile.DB
{
    /// <summary>
    /// 애플리케이션 시작될 때 최초 한번만 메모리 할당하고(static) 그 메모리에 인스턴스를 만들어 사용하는 디자인 패턴.
    /// sealed 다른 클래스 상속 못하게 함.
    /// </summary>
    public sealed class SingletonDB
    {
        private static volatile SingletonDB instance = null;
        private static object sysnRoot = new object();
        private static readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AdoTemplate"].ConnectionString);

        static SingletonDB()
        {
        }

        public static SingletonDB Instance
        {
            get
            {
                lock (sysnRoot)
                {
                    if (instance == null)
                    {
                        instance = new SingletonDB();
                    }
                }
                return instance;
            }
        }

        public SqlConnection GetDBConnection()
        {
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Not connected : " + ex.ToString());
            }
            return conn;
        }
    }
}