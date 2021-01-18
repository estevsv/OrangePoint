using MySql.Data.MySqlClient;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.DataAccess
{
    public class ValorDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        DataEmpresaDAO dataEmpresaDAO = new DataEmpresaDAO();
        SubtipoValorDAO subtipoValorDAO = new SubtipoValorDAO();

        public List<Valor> PesquisaValorLista()
        {
            List<Valor> listValorlista = new List<Valor>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.valor;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    Valor valor = new Valor();
                    valor.CodValor = int.Parse(registro["COD_VALOR"].ToString());
                    valor.DataEmpresa = dataEmpresaDAO.PesquisaDataEmpresaLista().Find(o => o.CodData == int.Parse(registro["COD_DATA"].ToString()));
                    valor.SubtipoValor = subtipoValorDAO.PesquisaSubtipoValorLista().Find(o => o.CodSubtipoValor == int.Parse(registro["COD_SUBTIPO_VALOR"].ToString()));
                    valor.NumValor = decimal.Parse(registro["DESCRICAO"].ToString());

                    listValorlista.Add(valor);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro ValorDAO/PesquisaValorLista. Contate o Suporte"); }
            return listValorlista;
        }

        public void ExcluiValor(int codValor)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.valor where COD_VALOR = " + codValor;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro ValorDAO/ExcluiValor. Contate o Suporte");
            }
        }

        public void IncluirValor(int codData, int codSubtipoValor,string valor)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`valor` (`COD_SUBTIPO_VALOR`, `COD_DATA`, `DESCRICAO`) VALUES ('"+ codSubtipoValor + "'," +
                    " '"+ codData + "', '"+ valor +"');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro ValorDAO/IncluirValor. Contate o Suporte");
            }
        }
    }
}
