using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raktar.Models.Database.Abstract;
using Caliburn.Micro;

namespace Raktar.Models.Database
{
    class PartnerHelper:DatabaseHelper
    {
        public BindableCollection<Partner> GetPartners() {
            BindableCollection<Partner> partnerek = new BindableCollection<Partner>();
            MySqlConnection connection = getConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "getpartners";
            command.Connection = connection;
            try
            {
                OpenConnection(connection);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    partnerek.Add(
                        new Partner()
                        {
                            Id = int.Parse(reader["id"].ToString()),
                            Name = reader["nev"].ToString(),
                        }
                        );
                }
                CloseConnection(connection);
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            return partnerek;
        }

        internal bool ModifyPartner(Partner partner)
        {
            throw new NotImplementedException();
        }

        public bool DeletePartner(int id)
        {
           
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "deletepartner";
            MySqlParameter pid = new MySqlParameter()
            {
                Value = id,
                ParameterName = "b_id",
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.Int32
            };
            MySqlParameter success = new MySqlParameter()
            {
                Direction = System.Data.ParameterDirection.ReturnValue,
                DbType = System.Data.DbType.Int32
            };
            command.Parameters.Add(pid);
            command.Parameters.Add(success);
            try
            {
                OpenConnection(connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            finally
            {
                CloseConnection(connection);
            }

            return success.Value.ToString() == "0"?false:true;
        }
        public bool AddPartner(Partner partner) {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "addpartner";
            MySqlParameter name = new MySqlParameter()
            {
                Value = partner.Name,
                DbType = System.Data.DbType.String,
                ParameterName = "NewName" 
            };
            command.Parameters.Add(name);
            try
            {
                OpenConnection(connection);
                success = command.ExecuteNonQuery() == 0 ? false : true;
            }
            catch (Exception e)
            {

                Logger.Log(e.Message);
            }
            finally {
                CloseConnection(connection);
            }
            return success;
        }
    }
}
