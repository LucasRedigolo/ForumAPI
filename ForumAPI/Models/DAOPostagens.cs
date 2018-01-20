using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ForumAPI.Models {
    public class DAOPostagens {

        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;
        string conexao = @"Data Source = .\SqlExpress; Initial Catalog = ForumAPI; user id = sa; password = senai@123";

        public List<Postagens> Listar () {
            List<Postagens> postagens = new List<Postagens> ();

            try {
                con = new SqlConnection ();
                con.ConnectionString = conexao;
                con.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from postagem";
                rd = cmd.ExecuteReader ();

                while (rd.Read ()) {
                    postagens.Add (new Postagens () { ID = rd.GetInt32 (0), IDTopico = rd.GetInt32 (1), IDUsuario = rd.GetInt32 (2), Mensagem = rd.GetString (3), DataPublicacao = rd.GetDateTime (4) });
                }
            } catch (SqlException se) {
                throw new Exception ("Erro ao consultar base de dados" + se.Message);
            } catch (SystemException ex) {
                throw new Exception (ex.Message);
            }
            return postagens;
        }
        public bool Cadastro (Postagens postagens) {
            bool resultado = false;
            try {
                con = new SqlConnection (conexao);
                con.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into postagem (idtopico, idusuario, mensagem) values(@idt, @idu, @m)";
                cmd.Parameters.AddWithValue ("@idt", postagens.IDTopico);
                cmd.Parameters.AddWithValue ("@idu", postagens.IDUsuario);
                cmd.Parameters.AddWithValue ("@m", postagens.Mensagem);

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