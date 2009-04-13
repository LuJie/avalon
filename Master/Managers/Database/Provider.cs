using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Avalon.Utility.Debugging;
using MySql.Data.MySqlClient;

namespace Avalon.Managers.Database
{
    public partial class Database
    {
        public static string sConnectionString;
        public static MySql.Data.MySqlClient.MySqlConnection myConnection;

        public static void Initialize()
        {
            try
            {
                sConnectionString = Program.AvalonCfg.Database.ConnectionString;
                myConnection = new MySqlConnection(sConnectionString);
                myConnection.Open();
                Logger.Log(Logger.LogLevel.Info, "DBAccess", "Connection opened.");
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.LogLevel.Error, "DBAccess", "Connection Error: " + ex.Message);
                if (ex.InnerException != null)
                    Logger.Log(Logger.LogLevel.Error, "DBAccess", "Connection Sub-Error: " + ex.InnerException.Message);
            } 
        }
        
        public static MySqlDataReader Query(String query)
        {
            MySqlCommand sqlc;

            try
            {
                sqlc = new MySqlCommand(query, myConnection);
                MySqlDataReader sdr = sqlc.ExecuteReader();

                sdr.Read();

                if (!sdr.HasRows)
                {
                    sdr.Close();
                    return sdr;
                }
                else
                {
                    sdr.Close();
                    return sdr;
                }
              
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.LogLevel.Error, "DBAccess", "Error, {0}", ex.Message);
                return null;
            }
        }
    }
}
