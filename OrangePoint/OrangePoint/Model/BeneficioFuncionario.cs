using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class BeneficioFuncionario
    {
        private int codBeneficio;
        public int CodBeneficio { get => codBeneficio; set => codBeneficio = value; }

        private Funcionario funcionario;
        public Funcionario Funcionario { get => funcionario; set => funcionario = value; }

        private string descBeneficio;
        public string DescBeneficio { get => descBeneficio; set => descBeneficio = value; }

        private DateTime dataAcordo;
        public DateTime DataAcordo { get => dataAcordo; set => dataAcordo = value; }

        private DateTime dataVencimento;
        public DateTime DataVencimento { get => dataVencimento; set => dataVencimento = value; }

        private int flgParcFGTS;
        public int FlgParcFGTS { get => flgParcFGTS; set => flgParcFGTS = value; }

    }
}
