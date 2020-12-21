using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class Empresa
    {
        private int codEmpresa;
        public int CodEmpresa { get => codEmpresa; set => codEmpresa = value; }

        private RegimeEmpresa regime;
        public RegimeEmpresa Regime { get => regime; set => regime = value; }

        private Grupo grupo;
        public Grupo Grupo { get => grupo; set => grupo = value; }

        private string razaoSocial;
        public string RazaoSocial { get => razaoSocial; set => razaoSocial = value; }

        private string cnpj;
        public string CNPJ { get => cnpj; set => cnpj = value; }

        private int numSocios;
        public int NumSocios { get => numSocios; set => numSocios = value; }

        private int numVinculos;
        public int NumVinculos { get => numVinculos; set => numVinculos = value; }

        private string observacao;
        public string Observacao { get => observacao; set => observacao = value; }

        private string senhaSIAT;
        public string SenhaSIAT { get => senhaSIAT; set => senhaSIAT = value; }

        private string eSocial;
        public string ESocial { get => eSocial; set => eSocial = value; }

    }
}
