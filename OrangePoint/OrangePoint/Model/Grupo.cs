using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class Grupo
    {
        private int codGrupo;
        public int CodGrupo { get => codGrupo; set => codGrupo = value; }

        private string descricao;
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
