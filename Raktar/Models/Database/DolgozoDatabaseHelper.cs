using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raktar.Models.Database.Abstract;
using MySql.Data.MySqlClient;
using Caliburn.Micro;
namespace Raktar.Models.Database
{
    class DolgozoDatabaseHelper:DatabaseHelper
    {
        //Dolgozók
        public BindableCollection<Dolgozo> GetDolgozok() {

            BindableCollection<Dolgozo> dolgozok = new BindableCollection<Dolgozo>();
            MySqlConnection connection = getConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "gethumans";
            command.Connection = connection;
            try
            {
                OpenConnection(connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    dolgozok.Add(new Dolgozo()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        GroupId = int.Parse(reader["groupid"].ToString()),
                        GroupName = reader["group"].ToString()
                    });
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            finally {
                CloseConnection(connection);
            }
            return dolgozok;
        }


        public async Task DeleteEndings() {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "DeleteEndings";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                OpenConnection(connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            finally
            {
                CloseConnection(connection);
            }
        }
        public async Task<CheckedData> CheckCloths()
        {
            await Task.Delay(3000);
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "CheckLejarat";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            CheckedData data = new CheckedData(0,0);
            try
            {
                OpenConnection(connection);
                MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        data = new CheckedData(int.Parse(reader["ember"].ToString()), int.Parse(reader["cikk"].ToString()));
                    }

                }
            }
            catch (Exception e)
            {
                return data;
            }
            finally
            {
                CloseConnection(connection);
            }
            return data;


        }


        public bool AddDolgozo(string newName, Osztaly group)
        {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "AddDolgozo";
            MySqlParameter name = new MySqlParameter()
            {
                Value = newName,
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input,
                ParameterName = "newname"
            };
            MySqlParameter csid = new MySqlParameter()
            {
                Value = group.Id,
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                ParameterName = "csid"
            };
            command.Parameters.Add(name);
            command.Parameters.Add(csid);
            try
            {
                OpenConnection(connection);
                success = command.ExecuteNonQuery()==0?false:true;
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
        internal bool ModifyDolgozo(Dolgozo dolgozo, Osztaly group)
        {
            bool siker = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ModifyDolgozo";
            command.Connection = connection;
            MySqlParameter ujnev = new MySqlParameter()
            {
                ParameterName = "newname",
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input,
                Value = dolgozo.Name
            };
            MySqlParameter groupid = new MySqlParameter()
            {
                ParameterName = "gid",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                Value = group.Id
            };
            MySqlParameter did = new MySqlParameter()
            {
                ParameterName = "did",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                Value = dolgozo.Id
            };
            command.Parameters.Add(ujnev);
            command.Parameters.Add(groupid);
            command.Parameters.Add(did);
            try
            {
               OpenConnection(connection);
               siker = command.ExecuteNonQuery() == 0 ? false : true;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            finally {
                CloseConnection(connection);
            }
            return siker;
        }
        public bool DeleteDolgozo(int id)
        {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "deletedolgozo";
            MySqlParameter b_id = new MySqlParameter()
            {
                Value = id,
                ParameterName = "b_id",
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.Int32

            };
            command.Parameters.Add(b_id);
            try
            {
                OpenConnection(connection);
                success = command.ExecuteNonQuery() == 0 ? false : true;
            }
            catch (Exception e)
            {

                Logger.Log(e.Message);
            }
            finally
            {
                CloseConnection(connection);
            }
            return success;
        }

        //Dolgozó ruhai
        public BindableCollection<Munkaruha> GetRuhakByDolgozoId(int id)
        {
            BindableCollection<Munkaruha> ruhak = new BindableCollection<Munkaruha>();
            MySqlConnection connection = getConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "GetHumanItems";
            command.Connection = connection;
            MySqlParameter emberid = new MySqlParameter()
            {
                Value = id,
                Direction = System.Data.ParameterDirection.Input,
                ParameterName = "v_id",
                DbType = System.Data.DbType.Int32
            };
            command.Parameters.Add(emberid);
            try
            {
                OpenConnection(connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    ruhak.Add(new Munkaruha() {
                        Id = int.Parse(reader["id"].ToString()),
                        Bevdatum = reader["date"].ToString(),
                        Cikkszam = reader["number"].ToString(),
                        Cikknev = reader["name"].ToString(),
                        Cikkcsoport = reader["group"].ToString(),
                        Mennyiseg = int.Parse(reader["count"].ToString()),
                        Mertekegyseg = reader["unit"].ToString(),
                        Egysegar = int.Parse(reader["price"].ToString()),
                        Hasznalt = int.Parse(reader["used"].ToString()) == 0 ? false : true,
                        Partner = reader["partner"].ToString(),
                        KiadDatum = reader["date"].ToString(),

                    });
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            finally
            {
                CloseConnection(connection);
            }
            return ruhak;
        }

        //Dolgozóval kapcsolatos ruha pakolások
        public bool Visszavetelezes(int emberid,params Munkaruha[] ruhak) {
            if (ruhak.Length == 0) return false;
            bool success = true;            
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "visszavet";
            MySqlConnection connection = getConnection()
;
            command.Connection = connection;

            try
            {
                OpenConnection(connection);
                foreach (Munkaruha munkaruha in ruhak)
                {
                    command.Parameters.Clear();
                    MySqlParameter p_emberid = new MySqlParameter()
                    {
                        Value = emberid,
                        ParameterName = "emberid",
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    command.Parameters.Add(p_emberid);
                    MySqlParameter p_raktarid = new MySqlParameter()
                    {
                        Value = munkaruha.Id,
                        ParameterName = "raktarid",
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    command.Parameters.Add(p_raktarid);
                    MySqlParameter p_mennyiseg = new MySqlParameter()
                    {
                        Value = munkaruha.Mennyiseg,
                        ParameterName = "b_mennyiseg",
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    command.Parameters.Add(p_mennyiseg);
                    command.ExecuteNonQuery();
                }    
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
        public bool Kivezetes(params Munkaruha[] ruhak) {
            bool success = true;

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "kivezetes";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            try
            {
                OpenConnection(connection);
                foreach (Munkaruha munkaruha in ruhak)
                {
                    command.Parameters.Clear();
                    MySqlParameter raktarid = new MySqlParameter()
                    {
                        Value = munkaruha.Id,
                        ParameterName = "raktarid",
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    MySqlParameter mennyiseg = new MySqlParameter()
                    {
                        Value = munkaruha.Mennyiseg,
                        ParameterName = "b_mennyiseg",
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input
                    };
                    command.Parameters.Add(raktarid);
                    command.Parameters.Add(mennyiseg);
                    if (command.ExecuteNonQuery() == 0) success = false ;
                }
            }
            catch (Exception e)
            {

                Logger.Log(e.Message);
                success = false;
            }
            finally
            {
                CloseConnection(connection);
            }
            return success;
        }

        //Osztályok
        public BindableCollection<Osztaly> GetOsztalyok()
        {
            BindableCollection<Osztaly> osztalyok = new BindableCollection<Osztaly>();
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "select * from osztaly where id != 1 and deleted = 0 order by id";
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                OpenConnection(connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    osztalyok.Add(new Osztaly()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Name = reader["nev"].ToString()
                    });
                }
            }
            catch (Exception e)
            {

                Logger.Log(e.Message);
            }
            finally
            {
                CloseConnection(connection);
            }

            return osztalyok;
        }
        public bool AddOsztaly(Osztaly osztaly)
        {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.CommandText = "AddOsztaly";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlParameter pname = new MySqlParameter()
            {
                ParameterName = "pname",
                Value = osztaly.Name,
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.String
            };
            command.Connection = connection;
            command.Parameters.Add(pname);
            try
            {
                OpenConnection(connection);
                success = command.ExecuteNonQuery() == 0 ? false : true;
            }
            catch (Exception e)
            {

                Logger.Log(e.Message);
            }
            finally
            {
                CloseConnection(connection);
            }
            return success;
        }
        public bool ModifyOsztaly(Osztaly osztaly)
        {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.CommandText = "ModifyOsztaly";
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlParameter pname = new MySqlParameter()
            {
                ParameterName = "pname",
                Value = osztaly.Name,
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.String
            };
            MySqlParameter pid = new MySqlParameter()
            {
                ParameterName = "pid",
                Value = osztaly.Id,
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.Int32
            };
            command.Parameters.Add(pname);
            command.Parameters.Add(pid);
            try
            {
                OpenConnection(connection);
                success = command.ExecuteNonQuery() == 0 ? false : true;
            }
            catch (Exception e)
            {

                Logger.Log(e.Message);
            }
            finally
            {
                CloseConnection(connection);

            }



            return success;
        }
        public bool RemoveOsztaly(Osztaly osztaly)
        {
            bool success = false;

            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "RemoveOsztaly";
            MySqlParameter pid = new MySqlParameter()
            {
                ParameterName = "delid",
                Value = osztaly.Id,
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.Int32
            };
            MySqlParameter eredmeny = new MySqlParameter()
            {
                Direction = System.Data.ParameterDirection.ReturnValue,
                ParameterName = "eredmeny",
                DbType = System.Data.DbType.Int32
            };
            command.Parameters.Add(pid);
            command.Parameters.Add(eredmeny);
            try
            {
                OpenConnection(connection);
                command.ExecuteNonQuery();
                //1 ha törölte 0 ha van még rajta ember
                int isDeleted = int.Parse(eredmeny.Value.ToString());
                if (isDeleted == 1)
                {
                    success = true;
                }
            }
            catch (Exception e)
            {

                Logger.Log(e.Message);
            }
            finally
            {
                CloseConnection(connection);
            }
            return success;
        }

    }
}
