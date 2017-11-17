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

        #region DadosCliente

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

        #endregion DadosClientes

        public static int InsertCartoes(Cartoes cartoes)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Insert into Cartoes(DataEntrada, Placa, Tipo_Cartao, Ativo) values (@DataEntrada, @Placa, @Tipo_Cartao, @Ativo,)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@DataEntrada", cartoes.DataEntrada);
                    cmd.Parameters.AddWithValue("@Placa", cartoes.Placa);
                    cmd.Parameters.AddWithValue("@Tipo_Cartao", cartoes.Tipo_Cartao);
                    cmd.Parameters.AddWithValue("@Ativo", cartoes.Ativo);
                    
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;

            }
        }
        public static List<Cartoes> GetCartoes()
        {
            List<Cartoes> _cartoes = new List<Cartoes>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Cartoes", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var cartoes = new Cartoes();
                                cartoes.DataEntrada = Convert.ToDateTime("DataEntrada");
                                cartoes.Placa = dr["Placa"].ToString();
                                cartoes.Tipo_Cartao = Convert.ToInt32("Tipo_Cartao");
                                cartoes.Ativo = Convert.ToBoolean("Ativo");

                                _cartoes.Add(cartoes);
                            }
                        }

                        return _cartoes;
                    }
                }
            }
        }
        public static Cartoes GetCartoes(int Cd_Cartoes)
        {
            Cartoes cartoes = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes where Cd_Cartoes = " + Cd_Cartoes, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                cartoes = new Cartoes();
                                cartoes.DataEntrada = Convert.ToDateTime("DataEntrada");
                                cartoes.Placa = dr["Placa"].ToString();
                                cartoes.Tipo_Cartao = Convert.ToInt32("Tipo_Cartao");
                                cartoes.Ativo = Convert.ToBoolean("Ativo");

                            }
                        }
                        return cartoes;
                    }

                }
            }
        }
        public static int UpdateCartoes(Cartoes cartoes)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Update Clientes set DataEntrada = @DataEntrada, Placa = @Placa, Tipo_Catao=@Tipo_Cartao, Ativo=@Ativo";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DataEntrada", cartoes.DataEntrada);
                    cmd.Parameters.AddWithValue("@Placa", cartoes.Placa);
                    cmd.Parameters.AddWithValue("@Tipo_Cartao", cartoes.Tipo_Cartao);
                    cmd.Parameters.AddWithValue("@Ativo", cartoes.Ativo);              

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();

                }
                return reg;
            }

        }

        #region DadosVeiculo
        public static int InsertVeiculos(Veiculos veiculos)
        {

            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Insert into Veiculos(Placa, Marca, Modelo, CPF) values (@Placa, @Marca, @Modelo, @CPF)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Placa", veiculos.Placa);
                    cmd.Parameters.AddWithValue("@Marca", veiculos.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", veiculos.Modelo);
                    cmd.Parameters.AddWithValue("@CPF", veiculos.CPF);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static Veiculos GetVeiculos(string CPF)
        {
            Veiculos veiculos = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Veiculos where CPF = " + CPF, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                veiculos = new Veiculos();
                                veiculos.Placa = dr["Placa"].ToString();
                                veiculos.Marca = dr["Marca"].ToString();
                                veiculos.Modelo = dr["Modelo"].ToString();
                                veiculos.CPF = dr["CPF"].ToString();

                            }
                        }
                        return veiculos;
                    }

                }
            }
        }
        public static int DeleteVeiculos(string Placa)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "Delete from Veiculos where Placa = " + Placa;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Placa", Placa);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return reg;

            }
        }
#endregion DadosVeiculo

        public static List<Bairro> GetBairro()
        {
            List<Bairro> _bairro = new List<Bairro>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bairro", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var bairro = new Bairro();
                                bairro.Nome = dr["Nome"].ToString();
                               
                                _bairro.Add(bairro);
                            }
                        }

                        return _bairro;
                    }
                }
            }
        }

        public static List<Rua> GetRua()
        {
            List<Rua> _rua = new List<Rua>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Rua" , con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var rua = new Rua();
                                rua.Nome = dr["Nome"].ToString();
                                
                                _rua.Add(rua);
                            }
                        }

                        return _rua;
                    }
                }
            }
        }



    }
}