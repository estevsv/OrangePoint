using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class SubtipoAtividade
    {
        private int codSubtipoAtividade;
        public int CodSubtipoAtividade { get => codSubtipoAtividade; set => codSubtipoAtividade = value; }

        private Atividade atividade;
        public Atividade Atividade { get => atividade; set => atividade = value; }

        private SubtipoValor subtipoValor;
        public SubtipoValor SubtipoValor { get => subtipoValor; set => subtipoValor = value; }
    }
}
