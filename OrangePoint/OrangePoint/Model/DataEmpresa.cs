using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class DataEmpresa
    {
        private int codData;
        public int CodData { get => codData; set => codData = value; }

        private Empresa empresa;
        public Empresa Empresa { get => empresa; set => empresa = value; }

        private DateTime data;
        public DateTime Data { get => data; set => data = value; }

    }
}
