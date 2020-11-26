using MySql.Data.MySqlClient;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.DataAccess
{
    public class PermissaoTelaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        TipoPermissaoDAO tipoPermissaoDAO = new TipoPermissaoDAO();

        public List<PermissaoTela> PesquisaPermissoesTela()
        {
            PermissaoTela permissaoTela = new PermissaoTela();
            List<PermissaoTela> listPermissaoTela = new List<PermissaoTela>();

            List<TipoPermissao> listaTipoPermissao = tipoPermissaoDAO.PesquisaTodosTipoPermissaoLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from bdorangepoint.permissoes_tela;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    permissaoTela.CodPermissaoTela = Convert.ToInt32(registro["COD_PERMISSAO_TELA"]);
                    int codTipoPermissao = Convert.ToInt32(registro["COD_TIPO_PERMISSAO"]);
                    permissaoTela.DescTela = registro["DESCRICAO_TELA"].ToString();
                    permissaoTela.TipoPermissao = listaTipoPermissao.Find(o => o.CodTipoPermissao == codTipoPermissao);
                    listPermissaoTela.Add(permissaoTela);
                }
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro PermissaoTelaDAO/PesquisaPermissoesTela. Contate o Suporte"); }
            return listPermissaoTela;
        }
    }
}
