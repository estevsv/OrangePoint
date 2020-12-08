using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class Atividade
    {
        private int codAtividade;
        public int CodAtividade { get => codAtividade; set => codAtividade = value; }

        private string descricao;
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
