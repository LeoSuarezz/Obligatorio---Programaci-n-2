using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Usuario
    {
        private int idUsuario;
        private string nickname;
        private string nombreUsuario;
        private string apellidoUsuario;
        private string password;
        private bool nivelUsuario;

        public Usuario() { }
        public Usuario(int idUsuario, string nickname, string nombreUsuario, string apellidoUsuario, string password, bool nivelUsuario)
        {
            this.idUsuario = idUsuario;
            this.nickname = nickname;
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
            this.password = password;
            this.nivelUsuario = nivelUsuario;
        }

        public int getIdUsuario() { return idUsuario; }
        public string getNickname() { return nickname; }
        public string getNombreUsuario() { return nombreUsuario; }
        public string getApellidoUsuario() { return apellidoUsuario; }
        public string getPassword() { return password; } //OJO//
        public bool getNivelUsuario() { return nivelUsuario; }

        public void setIdUsuario(int idUsuario) { this.idUsuario = idUsuario; }
        public void setNickname(string nickname) { this.nickname = nickname; }
        public void setNombreUsuario(string nombreUsuario) { this.nombreUsuario = nombreUsuario; }
        public void setApellidoUsuario(string apellidoUsuario) { this.apellidoUsuario = apellidoUsuario; }
        public void setPassword(string password) {  this.password = password; }
        public void setNivelUsuario(bool nivelUsuario) { this.nivelUsuario = nivelUsuario; }
    }
}