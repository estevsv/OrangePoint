using MySql.Data.MySqlClient;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.DataAccess
{
    public class RegimeEmpresaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public DataTable PesquisaRegimeEmpresasTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.regime_empresa;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro RegimeEmpresaDAO/PesquisaRegimeEmpresasTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<RegimeEmpresa> PesquisaRegimeEmpresasLista()
        {
            List<RegimeEmpresa> listRegimeEmpresa = new List<RegimeEmpresa>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.regime_empresa;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    RegimeEmpresa regimeEmpresa = new RegimeEmpresa();
                    regimeEmpresa.CodRegime = int.Parse(registro["COD_REGIME"].ToString());
                    regimeEmpresa.Descricao = registro["DESCRICAO"].ToString();

                    listRegimeEmpresa.Add(regimeEmpresa);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro RegimeEmpresaDAO/PesquisaRegimeEmpresasLista. Contate o Suporte"); }
            return listRegimeEmpresa;
        }

        public void ExcluiRegimeEmpresa(int codRegime)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.regime_empresa where COD_REGIME = " + codRegime;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro RegimeEmpresaDAO/ExcluiRegime. Contate o Suporte");
            }
        }

        public void IncluirRegimeEmpresa(string descricao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`regime_empresa` (`DESCRICAO`) VALUES ('" + descricao + "');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro RegimeEmpresaDAO/IncluirLogin. Contate o Suporte");
            }
        }

        public void AtualizaRegimeEmpresa(string descricao, int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "UPDATE `bdorangepoint`.`regime_empresa` SET `DESCRICAO` = '" + descricao+"' WHERE (`COD_REGIME` = '"+id+"');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro RegimeEmpresaDAO/AtualizaRegimeEmpresa. Contate o Suporte");
            }
        }
    }
}
