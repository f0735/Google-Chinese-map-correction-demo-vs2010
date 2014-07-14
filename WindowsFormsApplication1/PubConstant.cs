using System;
using System.Configuration;
namespace WindowsFormsApplication1
{
    
    public class PubConstant
    {        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                string _connectionString = "Server=192.168.1.6;initial catalog=EssenceSystem;User ID=essence;Password=111"; 
                return _connectionString; 
            }
        }
   }
}
