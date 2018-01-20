using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ForumAPI.Models {
    public class DAOTopicos {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;
        string conexao = @"Data Source = .\SqlExpress; Initial Catalog = ForumAPI; user id = sa; password = senai@123";

        public List<Topicos> Listar () {
            List<Topicos> topicos = new List<Topicos> ();

            try {
                con = new SqlConnection ();
                con.ConnectionString = conexao;
                con.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from topicoforum";
                rd = cmd.ExecuteReader ();

                while (rd.Read ()) {
                    topicos.Add (new Topicos () { ID = rd.GetInt32 (0), Titulo = rd.GetString (1), Descricao = rd.GetString (2), DataCadastro = rd.GetDateTime (3) });
                }
            } catch (SqlException se) {
                throw new Exception ("Erro ao consultar base de dados" + se.Message);
            } catch (SystemException ex) {
                throw new Exception (ex.Message);
            }
            return topicos;
        }
        public bool Cadastro (Topicos topicos) {
            bool resultado = false;
            try {
                con = new SqlConnection (conexao);
                con.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into topicoforum (Titulo, Descricao) values(@t, @d)";
                cmd.Parameters.AddWithValue ("@t", topicos.Titulo);
                cmd.Parameters.AddWithValue ("@d", topicos.Descricao);

                int r = cmd.ExecuteNonQuery ();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (SystemException ex) {
                throw new Exception (ex.Message);
            } finally {
                con.Close ();
            }
            return resultado;
        }

    }
}