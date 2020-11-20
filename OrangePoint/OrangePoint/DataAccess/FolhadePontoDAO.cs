﻿using MySql.Data.MySqlClient;
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
    public class FolhadePontoDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public void Incluir(FolhaPonto folhaPonto)
        {
            string dataPesquisa = folhaPonto.DataPonto.Year + "-" + folhaPonto.DataPonto.Month + "-" + folhaPonto.DataPonto.Day;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO bdorangepoint.folha_ponto_usuario(COD_USUARIO, DATA_PONTO, ENTRADA_1, SAIDA_1, ENTRADA_2, SAIDA_2) VALUES(@COD_USUARIO, @DATA_PONTO, @ENTRADA_1, @SAIDA_1, @ENTRADA_2, @SAIDA_2);";
                cmd.Parameters.AddWithValue("@COD_USUARIO", folhaPonto.Usuario.CodUsuario);
                cmd.Parameters.AddWithValue("@DATA_PONTO", dataPesquisa);
                cmd.Parameters.AddWithValue("@ENTRADA_1", folhaPonto.Entrada1);
                cmd.Parameters.AddWithValue("@SAIDA_1", folhaPonto.Saida1);
                cmd.Parameters.AddWithValue("@ENTRADA_2", folhaPonto.Entrada2);
                cmd.Parameters.AddWithValue("@SAIDA_2", folhaPonto.Saida2);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro FolhaPontoDAO/Incluir. Contate o Suporte"); }
        }

        public DataTable PesquisaPontoPorIdUsuario(Usuario usuario)
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from bdorangepoint.folha_ponto_usuario where COD_USUARIO = "+ usuario .CodUsuario + ";", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro FolhaPontoDAO/PesquisarIdUsuario. Contate o Suporte.");
            }
            return tabela;
        }

        public FolhaPonto PesquisaFolhadePontoPorUsuarioData(DateTime dataPonto, Usuario usuario)
        {
            FolhaPonto ponto = new FolhaPonto();
            string dataPesquisa = dataPonto.Year + "-" + dataPonto.Month + "-" + dataPonto.Day;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from bdorangepoint.folha_ponto_usuario where COD_USUARIO = '" + usuario.CodUsuario + "' and DATA_PONTO = '" + dataPesquisa + "';";
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                registro.Read();
                if (registro.HasRows)
                {
                    ponto.Usuario = usuario;
                    ponto.DataPonto = dataPonto;
                    ponto.CodPonto = Convert.ToInt32(registro["COD_PONTO"]);
                    ponto.Entrada1 = registro["ENTRADA_1"].ToString();
                    ponto.Entrada1 = registro["SAIDA_1"].ToString();
                    ponto.Entrada1 = registro["ENTRADA_2"].ToString();
                    ponto.Entrada1 = registro["SAIDA_2"].ToString();
                }
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro FolhaPontoDAO/PesquisaFolhadePontoPorUsuarioData. Contate o Suporte"); }
            return ponto;
        }

        public void AtualizaPonto(FolhaPonto folhaPonto)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update `bdmirela`.`cadastro_clientes` set ENTRADA_1 = @ENTRADA_1,SAIDA_1 = @SAIDA_1,ENTRADA_2=@ENTRADA_2,SAIDA_2 = @SAIDA_2" +
                    "where COD_USUARIO = @COD_USUARIO and DATA_PONTO = @DATA_PONTO;";
                cmd.Parameters.AddWithValue("@ENTRADA_1", folhaPonto.Entrada1);
                cmd.Parameters.AddWithValue("@SAIDA_1", folhaPonto.Saida1);
                cmd.Parameters.AddWithValue("@ENTRADA_2", folhaPonto.Entrada2);
                cmd.Parameters.AddWithValue("@SAIDA_2", folhaPonto.Saida2);
                cmd.Parameters.AddWithValue("@COD_USUARIO", folhaPonto.Usuario.CodUsuario);
                cmd.Parameters.AddWithValue("@DATA_PONTO", folhaPonto.DataPonto);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro FolhaPontoDAO/AtualizaPonto. Contate o Suporte");
            }
        }
    }
}
