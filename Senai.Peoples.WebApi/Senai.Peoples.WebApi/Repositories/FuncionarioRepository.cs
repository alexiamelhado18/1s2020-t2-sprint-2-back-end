using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private string StringConexao = "Data Source=DEV1001\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";


        public void AlterarInfoFunId(int id, FuncionarioDomain funcionarioDomain)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscarFun = "UPDATE Funcionario SET NomeFun = @NomeFun," +
                                        "SobrenomeFun = @SobrenomeFun WHERE IdFun = @ID";

                using (SqlCommand cmd = new SqlCommand(queryBuscarFun, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeFun", funcionarioDomain.NomeFun);
                    cmd.Parameters.AddWithValue("@SobrenomeFun", funcionarioDomain.SobrenomeFun);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }


        

        public void AlterarInfoFunCorpo(FuncionarioDomain funcionario)    
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                FuncionarioDomain funcionarios = new FuncionarioDomain();

                string queryAtualizarId = "UPDATE Funcionario SET NomeFun = @NomeFun," +
                                          "SobrenomeFun = @SobrenomeFun WHERE IdFun = @ID";

            using (SqlCommand cmd = new SqlCommand(queryAtualizarId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionario.IdFun);
                    cmd.Parameters.AddWithValue("@NomeFun", funcionario.NomeFun);
                    cmd.Parameters.AddWithValue("@SobrenomeFun", funcionario.SobrenomeFun);
                                       
                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }



        public FuncionarioDomain BuscarFunId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscarId = "SELECT * FROM Funcionario WHERE IdFun = @ID";


                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarId, con))
                {
                    cmd.Parameters.AddWithValue("@ID ", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFun = Convert.ToInt32(rdr[0]),
                            NomeFun = rdr["NomeFun"].ToString(),
                            SobrenomeFun = rdr["SobrenomeFun"].ToString()

                        };
                        return funcionario;
                    }
                }
                return null;
            }

        }





        public void CadastrarFun(FuncionarioDomain funcionarioDomain)
        {
            using (SqlConnection con = new SqlConnection (StringConexao))
            {
                string queryCadastrar = "INSERT INTO Funcionario(NomeFun,SobrenomeFun) VALUES (@NomeFun,@SobrenomeFun)";


                SqlCommand cmd = new SqlCommand(queryCadastrar, con);

                cmd.Parameters.AddWithValue("@NomeFun", funcionarioDomain.NomeFun);
                cmd.Parameters.AddWithValue("@SobrenomeFun", funcionarioDomain.SobrenomeFun);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }




        public void DeletarFun(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDeletar = "DELETE FROM Funcionario WHERE IdFun = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();                 
                    cmd.ExecuteNonQuery();

                }
            }
        }




        public List<FuncionarioDomain> ListarFuncionario()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryListarFun = "SELECT * FROM Funcionario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryListarFun, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFun = Convert.ToInt32(rdr[0]),
                            NomeFun = rdr["NomeFun"].ToString(),
                            SobrenomeFun = rdr["SobrenomeFun"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                      
                }
                return funcionarios;
            }
        }



    }
}
