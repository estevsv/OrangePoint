using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class FolhaPonto
    {
        private int codPonto;
        public int CodPonto { get => codPonto; set => codPonto = value; }

        private Usuario usuario;
        public Usuario Usuario { get => usuario; set => usuario = value; }

        private DateTime dataPonto;
        public DateTime DataPonto { get => dataPonto; set => dataPonto = value; }

        private string entrada1;
        public string Entrada1 { get => entrada1; set => entrada1 = value; }

        private string saida1;
        public string Saida1 { get => saida1; set => saida1 = value; }

        private string entrada2;
        public string Entrada2 { get => entrada2; set => entrada2 = value; }

        private string saida2;
        public string Saida2 { get => saida2; set => saida2 = value; }

        private string observacao;
        public string Observacao { get => observacao; set => observacao = value; }
    }
}
