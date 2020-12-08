using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class Funcionario
    {
        private int codFuncionario;
        public int CodFuncionario { get => codFuncionario; set => codFuncionario = value; }

        private Empresa empresa;
        public Empresa Empresa { get => empresa; set => empresa = value; }

        private string nomeFuncionario;
        public string NomeFuncionario { get => nomeFuncionario; set => nomeFuncionario = value; }

    }
}
