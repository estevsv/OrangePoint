using OrangePoint.DataAccess;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.BusinessRule
{
    public class FolhaPontoRule
    {
        FolhadePontoDAO folhaPontoDAO = new FolhadePontoDAO();

        public void Incluir(FolhaPonto folhaPonto)
        {
            folhaPontoDAO.Incluir(folhaPonto);
        }

        public DataTable PesquisaPontoPorIdUsuario(Usuario usuario)
        {
            return folhaPontoDAO.PesquisaPontoPorIdUsuario(usuario);
        }

        public DataTable PesquisaPontoPorIdUsuarioeData(Usuario usuario, DateTime dataProcura)
        {
            return folhaPontoDAO.PesquisaPontoPorIdUsuarioeData(usuario, dataProcura);
        }

        public FolhaPonto PesquisaFolhaPontoIndividual(DateTime data, Usuario usuario)
        {
            return folhaPontoDAO.PesquisaFolhadePontoPorUsuarioData(data,usuario);
        }

        public void RegistrarPonto(DateTime data, Usuario usuario)
        {
            FolhaPonto folhaPonto = PesquisaFolhaPontoIndividual(data,usuario);
            if (folhaPonto.CodPonto.Equals(0))
            {
                folhaPonto.Usuario = usuario;
                folhaPonto.DataPonto = data.Date;
                folhaPonto.Entrada1 = data.ToLongTimeString();
                folhaPonto.Saida1 = "";
                folhaPonto.Entrada2 = "";
                folhaPonto.Saida2 = "";

                folhaPontoDAO.Incluir(folhaPonto);
            }
            else
            {
                if (folhaPonto.Entrada1 == "")
                    folhaPonto.Entrada1 = data.ToLongTimeString();
                else if (folhaPonto.Saida1 == "")
                    folhaPonto.Saida1 = data.ToLongTimeString();
                else if (folhaPonto.Entrada2 == "")
                    folhaPonto.Entrada2 = data.ToLongTimeString();
                else if (folhaPonto.Saida2 == "")
                    folhaPonto.Saida2 = data.ToLongTimeString();
                else
                {
                    MessageBox.Show("Dia de trabalho já finalizado");
                    return;
                }
                folhaPontoDAO.AtualizaPonto(folhaPonto);
            }
        }

        public void RegistraObservacao(DateTime data, Usuario usuario, string observacao)
        {
            if (folhaPontoDAO.VerificaFolha(data, usuario))
                folhaPontoDAO.AtualizaObservacao(data, observacao, usuario);
            else
            {
                FolhaPonto folhaPonto = new FolhaPonto();
                folhaPonto.Usuario = usuario;
                folhaPonto.DataPonto = data.Date;
                folhaPonto.Observacao = observacao;
                folhaPontoDAO.Incluir(folhaPonto);
            }
        }
    }
}
