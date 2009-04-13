using System;
using System.Collections.Generic;
using System.Text;

namespace Avalon.Configuration
{
	public class DatabaseSettings
	{
        // Default Settings
        public string servername = "66.183.75.152";
        public string username = "lunia";
        public string password = "forsaken";
        public string database = "lunia";
        public string provider = "MySQLProv";

        public string ConnectionString
        {
            get
            {
                return String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", servername, username, password, database);
            }
        }
	}
}
