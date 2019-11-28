using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Raktar.Models.Database.Abstract
{
   abstract class DatabaseHelper
    {
        /// <summary>
        /// Gives back a valid mysqlconnection you can change the connection data in App.Conf
        /// </summary>
        /// <returns></returns>
        protected MySqlConnection getConnection()
        {
            string server = ConfigurationManager.AppSettings["DATABASEPATH"];
            string database = ConfigurationManager.AppSettings["DATABASENAME"];
            string uid = ConfigurationManager.AppSettings["DATABASEUSER"];
            string password = ConfigurationManager.AppSettings["DATABASEPASSWORD"];
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "CharSet = utf8;" + "UID=" + uid + ";" + "PASSWORD=" + password + "; Connect Timeout=5";

            return new MySqlConnection(connectionString);
        }
        /// <summary>
        /// Opens a valid connection throw exceptions but we logged that
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected bool OpenConnection(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {

                switch (e.Number)
                {
                    case 0:
                        Logger.Log(e.Message);
                        break;

                    case 1045:
                        Logger.Log(e.Message);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Close a valid connection throw exceptions but we logged that
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected bool CloseConnection(MySqlConnection connection)
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Logger.Log(e.Message);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }
        }
    }
}
