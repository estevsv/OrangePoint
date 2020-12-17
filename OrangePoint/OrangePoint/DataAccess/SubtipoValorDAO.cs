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
    public class SubtipoValorDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        TipoValorDAO tipoValorDAO = new TipoValorDAO();

        public DataTable PesquisaSubtipoValorTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.subtipo_valor;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro SubtipoValorDAO/PesquisaSubtipoValorTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<SubtipoValor> PesquisaSubtipoValorLista()
        {
            List<SubtipoValor> listSubtipoValorEmpresa = new List<SubtipoValor>();
            List<TipoValor> listTipoValor = tipoValorDAO.PesquisaTipoValorLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.subtipo_valor;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    SubtipoValor SubtipoValor = new SubtipoValor();
                    SubtipoValor.CodSubtipoValor = int.Parse(registro["COD_SUBTIPO_VALOR"].ToString());
                    SubtipoValor.TipoValor = listTipoValor.Find(o => o.CodTipoValor == int.Parse(registro["COD_TIPO_VALOR"].ToString()));
                    SubtipoValor.DescSubtipo = registro["DESC_SUBTIPO"].ToString();

                    listSubtipoValorEmpresa.Add(SubtipoValor);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro SubtipoValorDAO/PesquisaSubtipoValorLista. Contate o Suporte"); }
            return listSubtipoValorEmpresa;
        }

        public void ExcluiSubtipoValor(int codSubtipoValor)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.subtipo_valor where COD_SUBTIPO_VALOR = " + codSubtipoValor;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro SubtipoValorDAO/ExcluiSubtipoValor. Contate o Suporte");
            }
        }

        public void IncluirSubtipoValor(int codTipoValor,string descricao)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`subtipo_valor` (`COD_TIPO_VALOR`, `DESC_SUBTIPO`) VALUES ('"+ codTipoValor + "," + descricao + "');";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro SubtipoValorDAO/IncluirSubtipoValor. Contate o Suporte");
            }
        }
    }
}