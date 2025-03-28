﻿using atividade.Models;
using System.Security.Cryptography;

namespace atividade.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AdicionarUsuario(Usuario usuario)
        {
                using (var db= new Conexao(_connectionString))
                {
                    var cmd = db.MySqlCommand();
                    cmd.CommandText = "INSERT INTO Usuario (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha ";
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                    
                }
        }

        public  Usuario ObterUsuario(string email)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "Select * From Usuario Where Email = @Email";
                cmd.Parameters.AddWithValue("@Email", email);
                

                using (var reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        return new Usuario
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Email = reader.GetString("Email"),
                            Senha= reader.GetString("Senha"),
                        };

                    }
                }
                return null;
            }
            

        }



    }
}
