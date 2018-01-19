using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ForumAPI.Models {
    public class DAOUsuarios {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;
        string conexao = @"Data Source = .\SqlExpress; Initial Catalog = ForumAPI; user id = sa; password = senai@123";

        public List<Usuarios> Listar () {
            List<Usuarios> usuarios = new List<Usuarios> ();

            try {
                con = new SqlConnection ();
                con.ConnectionString = conexao;
                con.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from usuario";
                rd = cmd.ExecuteReader ();

                while (rd.Read ()) {
                    usuarios.Add (new Usuarios () { ID = rd.GetInt32 (0), Nome = rd.GetString (1), Login = rd.GetString (2), Senha = rd.GetString (3), DataCadastro = rd.GetDateTime (4) });
                }
            } catch (SqlException se) {
                throw new Exception ("Erro ao consultar base de dados" + se.Message);
            } catch (SystemException ex) {
                throw new Exception (ex.Message);
            }
            return usuarios;
        }

    }
}