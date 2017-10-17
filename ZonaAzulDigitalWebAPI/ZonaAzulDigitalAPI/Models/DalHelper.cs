using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ZonaAzulDigitalAPI.Models
{
    public class DalHelper
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["ZonaAzulSqlServer"].ConnectionString;
        }

        public static int InsertCliente(Cliente cliente)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Insert into Clientes(CPF, Nome, Email, Telefone, Senha) values (@CPF, @Nome, @Email, @Telefone, @Senha)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
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
                                cliente.CPF = dr["CPF"].ToString();
                                cliente.Nome = dr["Nome"].ToString();
                                cliente.Email = dr["Email"].ToString();
                                cliente.Telefone = dr["Telefone"].ToString();
                                cliente.Senha = dr["Senha"].ToString();
                                _cliente.Add(cliente);
                            }
                        }
                        
                        return _cliente;
                    }
                }
            }
        }
        
        public static Cliente GetCliente(string CPF)
        {
            Cliente cliente = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes where CPF = " + CPF, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                cliente = new Cliente();
                                cliente.CPF = dr["CPF"].ToString();
                                cliente.Nome = dr["Nome"].ToString();
                                cliente.Email = dr["Email"].ToString();
                                cliente.Telefone = dr["Telefone"].ToString();
                                cliente.Senha = dr["Senha"].ToString();

                            }
                        }
                        return cliente;
                    }

                }
            }
        }

       
        public static int UpdateCliente(Cliente cliente)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Update Clientes set CPF = @CPF, Nome = @Nome, Email=@Email, Telefone=@Telefone, Senha=@Senha";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
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
        public static int DeleteCliente(string CPF)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Delete from Clientes where CPF = " + CPF;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CPF", CPF);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return reg;

            }
        }
    }
}