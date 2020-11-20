using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class Usuario
    {
        private int codUsuario;
        public int CodUsuario { get => codUsuario; set => codUsuario = value; }

        private string login;
        public string Login { get => login; set => login = value; }

        private string senha;
        public string Senha { get => senha; set => senha = value; }

        private string nmeFuncionario;
        public string NmeFuncionario { get => nmeFuncionario; set => nmeFuncionario = value; }

        private decimal hrsDiaria;
        public decimal HrsDiaria { get => hrsDiaria; set => hrsDiaria = value; }

        private string fotoUsuario;
        public string FotoUsuario { get => fotoUsuario; set => fotoUsuario = value; }
    }
}
