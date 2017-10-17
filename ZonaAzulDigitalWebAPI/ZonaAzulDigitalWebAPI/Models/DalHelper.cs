using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ZonaAzulDigitalWebAPI.Models
{
    public class DalHelper
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["ZonaAzulSQLServer"].ConnectionString;
        }

        public static List<Cliente> GetCliente()
        {
            List<Cliente> _cliente = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var cliente = new Cliente();
                                cliente.Cd_Cliente = Convert.ToInt32(dr["Cd_Cliente"]);
                                cliente.Login = dr["Login"].ToString();
                                cliente.Nome = dr["Nome"].ToString();
                                cliente.CPF = Convert.ToInt32(dr["CPF"]);
                                cliente.RG = dr["RG"].ToString();
                                cliente.Email = dr["Email"].ToString();
                                cliente.Telefone = dr["Telefone"].ToString();
                                cliente.Senha = dr["Senha"].ToString();
                            }
                        }
                        return _cliente;
                    }
                }
            }
        }

        public static Cliente GetCliente(int Cd_Cliente)
        {
            Cliente cliente = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Produtos where Cd_Cliente = " + Cd_Cliente, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                            while (dr.Read())
                            {
                                cliente = new Cliente();
                                cliente.Cd_Cliente = Convert.ToInt32(dr["Cd_Cliente"]);
                                cliente.Login = dr["Login"].ToString();
                                cliente.Nome = dr["Nome"].ToString();
                                cliente.CPF = Convert.ToInt32(dr["CPF"]);
                                cliente.RG = dr["RG"].ToString();
                                cliente.Email = dr["Email"].ToString();
                                cliente.Telefone = dr["Telefone"].ToString();
                                cliente.Senha = dr["Senha"].ToString();

                            }
                        return cliente;
                    }

                }
            }
        }

        public static int InsertCliente(Cliente cliente)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Insert into Clientes(Login, Nome, CPF, RG, Email, Telefone, Senha) values (@Login, @Nome, @CPF, @RG, @Email, @Telefone, @Senha)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Login", cliente.Login);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                    cmd.Parameters.AddWithValue("@RG", cliente.RG);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("@Senha", cliente.Senha);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;

            }
        }
        public static int UpdateCliente(Cliente cliente)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Update Clientes set Login = @Login, Nome = @Nome, CPF=@CPF, RG=@RG, Email=@Email, Telefone=@Telefone, Senha=@Senha";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Login", cliente.Login);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                    cmd.Parameters.AddWithValue("@RG", cliente.RG);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    cmd.Parameters.AddWithValue("@Senha", cliente.Senha);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();

                }
                return reg;
            }

        }
        public static int DeleteCliente(int Cd_Cliente)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Delete from Clientes where Id = " + Cd_Cliente;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Cd_Cliente", Cd_Cliente);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return reg;
                
            }
        }
    }
}