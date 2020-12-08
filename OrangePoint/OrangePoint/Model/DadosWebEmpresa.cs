using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class DadosWebEmpresa
    {
        private int codDadoWeb;
        public int CodDadoWeb { get => codDadoWeb; set => codDadoWeb = value; }

        private Empresa empresa;
        public Empresa Empresa { get => empresa; set => empresa = value; }

        private string usuarioWeb;
        public string UsuarioWeb { get => usuarioWeb; set => usuarioWeb = value; }

        private string senhaWeb;
        public string SenhaWeb { get => senhaWeb; set => senhaWeb = value; }

        private string descDado;
        public string DescDado { get => descDado; set => descDado = value; }
    }
}
