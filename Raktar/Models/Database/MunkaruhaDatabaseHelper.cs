using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raktar.Models.Database.Abstract;
using MySql.Data.MySqlClient;
using System.Windows;
using Caliburn.Micro;

namespace Raktar.Models.Database
{
    class MunkaruhaDatabaseHelper : DatabaseHelper
    {
        //Cikkekkel való műveletek
        public List<Munkaruha> GetRuhakFromRaktar(){
            List<Munkaruha> munkaruhak = new List<Munkaruha>();

            MySqlConnection connection = getConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "GetStorageItems";
            command.Connection = connection;
            try
            {
                OpenConnection(connection);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    munkaruhak.Add(
                        new Munkaruha()
                        {
                            Id = int.Parse(reader["ID"].ToString()),
                            Cikkszam = reader["number"].ToString(),
                            Cikknev = reader["name"].ToString(),
                            CikkcsoportId = int.Parse(reader["groupid"].ToString()),
                            Cikkcsoport = reader["group"].ToString(),
                            Mennyiseg = int.Parse(reader["count"].ToString()),
                            Mertekegyseg = reader["unit"].ToString(),
                            Egysegar = int.Parse(reader["price"].ToString()),
                            Hasznalt = reader["used"].ToString() == "1" ? true : false,
                            Bevdatum = reader["date"].ToString(),
                            Partner = reader["partner"].ToString()
                        }
                        );
                }
               
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            finally {
                CloseConnection(connection);
            }
            return munkaruhak;
        }

        internal BindableCollection<Bevetel> GetDistinctBevetByPartner(Partner selectedPartner)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "getDistinctBevetByPartner";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            BindableCollection<Bevetel> bevetelek = new BindableCollection<Bevetel>();
            command.Parameters.AddWithValue("pid",selectedPartner.Id);
            try
            {
                OpenConnection(connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bevetelek.Add(new Bevetel()
                    {
                        BevetId = int.Parse(reader["id"].ToString()),
                        Szamlaszam = reader["szam"].ToString()
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
            return bevetelek;
        }

        public BindableCollection<Munkaruha> GetRuhaByBevetId(int bevetId)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "getRuhaByBevetId";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            BindableCollection<Munkaruha> ruhak = new BindableCollection<Munkaruha>();
            MySqlParameter id = new MySqlParameter()
            {
                Value = bevetId,
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.Int32,
                ParameterName = "b_bevetid"
            };
            command.Parameters.Add(id);
            try
            {
                OpenConnection(connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    ruhak.Add(new Munkaruha() {
                        Cikkszam = reader["cikkszam"].ToString(),
                        Cikknev = reader["cikknev"].ToString(),
                        Mertekegyseg = reader["unit"].ToString(),
                        Cikkcsoport = reader["csoport"].ToString(),
                        Mennyiseg = int.Parse(reader["mennyiseg"].ToString()),
                        Egysegar = int.Parse(reader["egysegar"].ToString()),
                        Partner = reader["partner"].ToString()

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
            return ruhak;
        }

        public bool MegvaltRuhakByDolgozoID(int id)
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "TorolDolgozCikkek";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("did", id);
            bool result = false;
            try
            {
                OpenConnection(connection);
                result = command.ExecuteNonQuery() == 0 ? false : true;
            }
            catch (Exception e) {
                
                Logger.Log(e.Message);
            }
            return result;
        }

        public BindableCollection<Bevetel> GetDistinctBevet()
        {
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "getDistinctBevet";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            BindableCollection<Bevetel> bevetelek = new BindableCollection<Bevetel>();
            try
            {
                OpenConnection(connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    bevetelek.Add(new Bevetel()
                    {
                        BevetId = int.Parse(reader["id"].ToString()),
                        Szamlaszam = reader["szam"].ToString()
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
            return bevetelek;
        }

        public bool AddNewRuha(string newName, string mertekegyseg, Csoport group)
        {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "addcikk";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlParameter name = new MySqlParameter()
            {
                Value = newName,
                ParameterName = "megnevezes",
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.String

            };
            MySqlParameter mertek = new MySqlParameter()
            {
                Value = mertekegyseg,
                ParameterName = "b_mertekegyseg",
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.String

            };
            MySqlParameter gid = new MySqlParameter()
            {
                Value = group.Id,
                ParameterName = "b_cikkcsoport",
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.Int32

            };
            command.Parameters.Add(name);
            command.Parameters.Add(mertek);
            command.Parameters.Add(gid);
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

        public BindableCollection<Munkaruha> GetAllCikkek() {
            BindableCollection<Munkaruha> cikkek = new BindableCollection<Munkaruha>();
            MySqlConnection connection = getConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "GetAllCikkek";
            command.Connection = connection;
            try
            {
                OpenConnection(connection);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cikkek.Add(
                        new Munkaruha()
                        {
                            Id = int.Parse(reader["ID"].ToString()),
                            Cikkszam = reader["number"].ToString(),
                            Cikknev = reader["name"].ToString(),
                            CikkcsoportId = int.Parse(reader["groupid"].ToString()),
                            Cikkcsoport = reader["group"].ToString(),                           
                            Mertekegyseg = reader["unit"].ToString()
                        }
                        );
                }
                CloseConnection(connection);
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            return cikkek;
        }
        public bool AddMunkaruhaToRaktar(params Munkaruha[] ruhak) {
            bool success = true;
            if (ruhak.Length == 0) return false;
            MySqlConnection connection = getConnection();
            MySqlCommand command = new MySqlCommand();
            MySqlParameter bevetid = new MySqlParameter()
            {
                Direction = System.Data.ParameterDirection.ReturnValue,
                DbType = System.Data.DbType.Int32
            };
            command.Connection = connection;
            try
            {
                OpenConnection(connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "get_BevetId";
                command.Parameters.Add(bevetid);
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                Logger.Log(e.Message);
            }
            try {
                
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "bevet";
                foreach (Munkaruha munkaruha in ruhak)
                {

                    command.Parameters.Clear();
                    MySqlParameter c_cikkid = new MySqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        Value = munkaruha.Id,
                        Direction = System.Data.ParameterDirection.Input,
                        ParameterName = "b_cikkid"
                        
                    };
                    command.Parameters.Add(c_cikkid);
                    MySqlParameter c_mennyiseg = new MySqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        Value = munkaruha.Mennyiseg,
                        Direction = System.Data.ParameterDirection.Input,
                        ParameterName = "b_mennyiseg"

                    };
                    command.Parameters.Add(c_mennyiseg);
                    MySqlParameter c_egysegar = new MySqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        Value = munkaruha.Egysegar,
                        Direction = System.Data.ParameterDirection.Input,
                        ParameterName = "b_egysegar"

                    };
                    command.Parameters.Add(c_egysegar);
                    MySqlParameter c_partner = new MySqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        Value = munkaruha.PartnerId,
                        Direction = System.Data.ParameterDirection.Input,
                        ParameterName = "b_partnerid"

                    };
                    command.Parameters.Add(c_partner);
                    MySqlParameter c_bevetid = new MySqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        Value = int.Parse(bevetid.Value.ToString()),
                        Direction = System.Data.ParameterDirection.Input,
                        ParameterName = "b_bevetid"

                    };
                    command.Parameters.Add(c_bevetid);
                    MySqlParameter c_szamlaszam = new MySqlParameter()
                    {
                        DbType = System.Data.DbType.String,
                        Value = munkaruha.Szamlaszam,
                        Direction = System.Data.ParameterDirection.Input,
                        ParameterName = "b_szamlaszam"

                    };
                    command.Parameters.Add(c_szamlaszam);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e) {
                Logger.Log(e.Message);
                success = false;
                CloseConnection(connection);
                return success;
            }
            CloseConnection(connection);
            return success;
        }
        public bool KiadasMunkaruha(int partnerid,params Munkaruha[] ruhak) {
            bool success = true;
            if (ruhak.Length == 0) return false;
            MySqlConnection connection = getConnection();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "kiadas";
            command.Connection = connection;
            try
            {

                OpenConnection(connection);
                foreach (var ruha in ruhak)
                {
                    command.Parameters.Clear();
                    MySqlParameter raktarid = new MySqlParameter()
                    {
                        Value = ruha.Id,
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        ParameterName = "raktarid"
                    };
                    MySqlParameter mennyiseg = new MySqlParameter()
                    {
                        Value = ruha.Mennyiseg,
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        ParameterName = "v_mennyiseg"
                    };
                    MySqlParameter v_emberid = new MySqlParameter()
                    {
                        Value = partnerid,
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        ParameterName = "v_emberid"
                    };
                    command.Parameters.Add(raktarid);
                    command.Parameters.Add(mennyiseg);
                    command.Parameters.Add(v_emberid);
                    success = command.ExecuteNonQuery() == 0?false:true;
                }
                
            }
            catch (Exception e) {
                Logger.Log(e.Message);
            }
            return success;
        }

        public bool DeleteRuha(int id)
        {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.CommandText = "deleteCikkfunction";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = connection;
            MySqlParameter did = new MySqlParameter()
            {
                Value = id,
                ParameterName = "did",
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.Int32
            };
            command.Parameters.Add(did);
            MySqlParameter siker = new MySqlParameter()
            {
                Direction = System.Data.ParameterDirection.ReturnValue,
                DbType = System.Data.DbType.Int32
            };
            command.Parameters.Add(siker);
            try
            {
                OpenConnection(connection);
                command.ExecuteNonQuery();
                success = siker.Value.ToString() == "1" ? true : false;
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
        public bool ModifyRuha(Munkaruha ruha) {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "ModifyRuha";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlParameter id = new MySqlParameter()
            {
                ParameterName = "rid",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                Value = ruha.Id
            };
            MySqlParameter cikknev = new MySqlParameter()
            {
                ParameterName = "rcikknev",
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input,
                Value = ruha.Cikknev
            };
            MySqlParameter mertekegyseg = new MySqlParameter()
            {
                ParameterName = "rmertekegyseg",
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.String,
                Value = ruha.Mertekegyseg
            };
            MySqlParameter csoportid = new MySqlParameter()
            {
                ParameterName = "csid",
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.Int32,
                Value = ruha.CikkcsoportId
            };
            command.Parameters.Add(id);
            command.Parameters.Add(cikknev);
            command.Parameters.Add(mertekegyseg);
            command.Parameters.Add(csoportid);
            try
            {
                OpenConnection(connection);
                success = command.ExecuteNonQuery() == 0 ? false : true;
            }
            catch(Exception e) {
                Logger.Log(e.Message);
            }
            finally
            {
                CloseConnection(connection);
            }
            return success;
        }

        //Cikkcsoportokkal való műveletek
        public BindableCollection<Csoport> GetCikkCsoportok()
        {
            BindableCollection<Csoport> csoportok = new BindableCollection<Csoport>();
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandText = "select * from cikkcsoport where deleted = 0 order by id";
            try
            {
                OpenConnection(connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    csoportok.Add(new Csoport()
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
            return csoportok;
        }

        public bool AddCikkCsoport(Csoport newCsoport)
        {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "AddGroup";
            MySqlParameter p_name = new MySqlParameter()
            {
                Value = newCsoport.Name,
                ParameterName = "newName",
                Direction = System.Data.ParameterDirection.Input,
                DbType = System.Data.DbType.String
            };
            command.Parameters.Add(p_name);
            try
            {
                OpenConnection(connection);
                success = command.ExecuteNonQuery() == 0 ? false : true;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                success = false;
            }
            finally {
                CloseConnection(connection);
            }


            return success;

        }
        public bool DeleteCikkCsoport(Csoport delCsoport) {
            bool success = false;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = getConnection();
            command.CommandText = "Delgroup";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlParameter p_id = new MySqlParameter()
            {
                Value = delCsoport.Id,
                ParameterName = "delid",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                

            };
            MySqlParameter p_success = new MySqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.ReturnValue
            };
            command.Parameters.Add(p_id);
            command.Parameters.Add(p_success);
            command.Connection = connection;
            try
            {
                OpenConnection(connection);
                command.ExecuteNonQuery();
                success = p_success.Value.ToString() == "1" ? true:false;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                success = false;

            }
            finally {
                CloseConnection(connection);
            }
            return success;
        }
    }
}
