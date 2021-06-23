using Microsoft.Office.Interop.Excel;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrangePoint.BusinessRule
{
    public class GeradorExcel
    {
        EmpresaRule empresaRule = new EmpresaRule();


        #region Excel Consultoria Contabil
        private int contadorGeral = 0;
        private int posicaoTotalizador = 0;
        private int contadorEsquerdo = 0;
        private int contadorDireito = 0;
        private List<List<string>> somatorioLadoEsquerdo;
        private List<List<string>> somatorioLadoDireito;
        ValorRule valorRule = new ValorRule();

        public void GeraExcelConsultoriaContabil(int idEmpresa, List<DateTime> meses)
        {
            Application planilha = new Application();
            planilha.Application.Workbooks.Add(Type.Missing);

            var xlSheets = planilha.ActiveWorkbook.Sheets as Microsoft.Office.Interop.Excel.Sheets;
            var xlNewSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
            xlNewSheet.Name = "BALANÇO PATRIMONIAL";

            GeraWorkSheetBalancoPatrimonial(idEmpresa, meses, planilha);

            xlSheets = planilha.ActiveWorkbook.Sheets as Microsoft.Office.Interop.Excel.Sheets;
            xlNewSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlSheets.Add(xlSheets[2], Type.Missing, Type.Missing, Type.Missing);
            xlNewSheet.Name = "DRE";

            GeraWorkSheetDRE(idEmpresa, meses, planilha);

            planilha.Visible = true;
        }

        #region Métodos Auxiliares
        private string capturaLogoFatore()
        {
            string directoryPath = Directory.GetCurrentDirectory().Replace('\\', '*');
            string[] caminho = directoryPath.Split('*');
            directoryPath = caminho[0];
            for (int i = 1; i < caminho.Length - 2; i++)
            {
                directoryPath += "\\" + caminho[i];
            }
            directoryPath += "\\Resources\\logo.jpg";

            return directoryPath;
        }

        private List<Tuple<string, List<decimal>>> geraTuplaValoresEmpresa(int tipo, int idEmpresa, List<DateTime> meses)
        {
            List<Valor> listaValores = valorRule.listaValor().Where(o => o.DataEmpresa.Empresa.CodEmpresa == idEmpresa).ToList();

            List<Tuple<string, List<decimal>>> tupla = new List<Tuple<string, List<decimal>>>();

            if (listaValores.Exists(o => o.SubtipoValor.TipoValor.CodTipoValor == tipo))
            {
                //Lista de Subtipos de um tipo de valor específico
                foreach (SubtipoValor subtipoValor in RetornaListaSubtipoValor(listaValores.Where(o => o.SubtipoValor.TipoValor.CodTipoValor == tipo).ToList()).OrderBy(o => o.DescSubtipo).ToList())
                {
                    List<Valor> listaValoresAux = listaValores.Where(o => o.SubtipoValor.CodSubtipoValor == subtipoValor.CodSubtipoValor).ToList();

                    tupla.Add(new Tuple<string, List<decimal>>(subtipoValor.DescSubtipo, new List<decimal> {
                        listaValoresAux.Where(o => o.DataEmpresa.Data.Month == meses[0].Month && o.DataEmpresa.Data.Year == meses[0].Year).Sum(o => o.NumValor),
                        listaValoresAux.Where(o => o.DataEmpresa.Data.Month == meses[1].Month && o.DataEmpresa.Data.Year == meses[1].Year).Sum(o => o.NumValor),
                        listaValoresAux.Where(o => o.DataEmpresa.Data.Month == meses[2].Month && o.DataEmpresa.Data.Year == meses[2].Year).Sum(o => o.NumValor)
                        }));
                }
            }

            return tupla;
        }

        private List<SubtipoValor> RetornaListaSubtipoValor(List<Valor> listaValores)
        {
            List<SubtipoValor> lista = new List<SubtipoValor>();
            foreach (Valor valor in listaValores)
            {
                if (lista.Where(o => o.CodSubtipoValor == valor.SubtipoValor.CodSubtipoValor).Count() == 0)
                {
                    lista.Add(valor.SubtipoValor);
                }
            }

            return lista;
        }
        #endregion

        #region Balanço Patrimonial
        private void GeraWorkSheetBalancoPatrimonial(int idEmpresa, List<DateTime> meses, Application planilha)
        {
            somatorioLadoEsquerdo = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };
            somatorioLadoDireito = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };

            Empresa empresa = empresaRule.PesquisaEmpresaPorId(idEmpresa);

            Range oRange = (Range)planilha.ActiveSheet.Cells[1, 1];
            float Left = (float)((double)oRange.Left);
            float Top = (float)((double)oRange.Top);
            const float ImageSize = 40;
            planilha.ActiveSheet.Shapes.AddPicture(capturaLogoFatore(), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);

            planilha.Range[planilha.Cells[1, 2], planilha.Cells[1, 9]].Interior.Color = XlRgbColor.rgbBlack;

            planilha.Cells[1, 2] = "CONSULTORIA CONTABIL";
            planilha.Range[planilha.Cells[1, 2], planilha.Cells[1, 2]].Font.Color = XlRgbColor.rgbDarkOrange;

            planilha.Range[planilha.Cells[2, 2], planilha.Cells[2, 8]].Merge();
            planilha.Range[planilha.Cells[3, 2], planilha.Cells[3, 7]].Merge();

            planilha.Range[planilha.Cells[2, 2], planilha.Cells[2, 9]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

            planilha.Cells[2, 2] = "Balanço Patrimonial";
            planilha.Cells[3, 2] = empresa.RazaoSocial.ToUpper();
            planilha.Range[planilha.Cells[2, 2], planilha.Cells[2, 2]].Font.Bold = true;

            planilha.Cells[3, 8] = "Data Base:";
            planilha.Cells[3, 9] = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year;

            planilha.Range[planilha.Cells[4, 2], planilha.Cells[4, 9]].Merge();
            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 5]].Merge();
            planilha.Cells[5, 2] = "ATIVO";
            planilha.Range[planilha.Cells[5, 6], planilha.Cells[5, 9]].Merge();

            planilha.Cells[5, 6] = "PASSIVO";
            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 9]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 5]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 9]].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 9]].Cells.VerticalAlignment = XlHAlign.xlHAlignCenter;
            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 9]].Font.Bold = true;


            planilha.Range[planilha.Cells[6, 2], planilha.Cells[6, 5]].Merge();
            planilha.Range[planilha.Cells[6, 6], planilha.Cells[6, 9]].Merge();
            planilha.Cells[7, 3] = DateTime.DaysInMonth(meses[0].Year, meses[0].Month) + "/" + (meses[0].Month < 10 ? "0" + meses[0].Month : meses[0].Month.ToString()) + "/" + meses[0].Year;
            planilha.Cells[7, 4] = DateTime.DaysInMonth(meses[1].Year, meses[1].Month) + "/" + (meses[1].Month < 10 ? "0" + meses[1].Month : meses[1].Month.ToString()) + "/" + meses[1].Year;
            planilha.Cells[7, 5] = DateTime.DaysInMonth(meses[2].Year, meses[2].Month) + "/" + (meses[2].Month < 10 ? "0" + meses[2].Month : meses[2].Month.ToString()) + "/" + meses[2].Year;
            planilha.Cells[7, 7] = DateTime.DaysInMonth(meses[0].Year, meses[0].Month) + "/" + (meses[0].Month < 10 ? "0" + meses[0].Month : meses[0].Month.ToString()) + "/" + meses[0].Year;
            planilha.Cells[7, 8] = DateTime.DaysInMonth(meses[1].Year, meses[1].Month) + "/" + (meses[1].Month < 10 ? "0" + meses[1].Month : meses[1].Month.ToString()) + "/" + meses[1].Year;
            planilha.Cells[7, 9] = DateTime.DaysInMonth(meses[2].Year, meses[2].Month) + "/" + (meses[2].Month < 10 ? "0" + meses[2].Month : meses[2].Month.ToString()) + "/" + meses[2].Year;

            planilha.Range[planilha.Cells[7, 2], planilha.Cells[7, 9]].Font.Bold = true;

            planilha.Range[planilha.Cells[7, 3], planilha.Cells[7, 9]].Font.Color = XlRgbColor.rgbDarkOrange;

            planilha.Range[planilha.Cells[7, 3], planilha.Cells[7, 3]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[7, 4], planilha.Cells[7, 4]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[7, 5], planilha.Cells[7, 5]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[7, 3], planilha.Cells[7, 3]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[7, 4], planilha.Cells[7, 4]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            planilha.Range[planilha.Cells[7, 7], planilha.Cells[7, 7]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[7, 8], planilha.Cells[7, 8]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[7, 7], planilha.Cells[7, 9]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

            contadorGeral = 8;
            contadorEsquerdo = 8;
            contadorDireito = 8;

            geraTipoBalanco(geraTuplaValoresEmpresa(1, idEmpresa, meses), planilha, "ATIVO CIRCULANTE", true);
            geraTipoBalanco(geraTuplaValoresEmpresa(2, idEmpresa, meses), planilha, "PASSIVO CIRCULANTE", false);
            geraTipoBalanco(geraTuplaValoresEmpresa(3, idEmpresa, meses), planilha, "ATIVO NÃO CIRCULANTE", true);
            geraTipoBalanco(geraTuplaValoresEmpresa(4, idEmpresa, meses), planilha, "PASSIVO NÃO CIRCULANTE", false);
            geraTipoBalanco(geraTuplaValoresEmpresa(5, idEmpresa, meses), planilha, "PATRIMÔNIO LÍQUIDO", false);


            contadorGeral = contadorEsquerdo > contadorDireito ? contadorEsquerdo : contadorDireito;
            planilha.Range[planilha.Cells[3, 5], planilha.Cells[contadorGeral - 1, 5]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            AnexaLinhaSomatorioTotal(planilha);

            contadorGeral += 2;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; contadorGeral++;
            planilha.Cells[contadorGeral, 2] = "Responsável Administrativo";

            contadorGeral += 4;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; contadorGeral++;
            planilha.Cells[contadorGeral, 2] = "Contador";  contadorGeral++;
            planilha.Cells[contadorGeral, 2] = "CRC";

            planilha.Range[planilha.Cells[contadorGeral-6, 2], planilha.Cells[contadorGeral, 2]].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            planilha.Range[planilha.Cells[1, 1], planilha.Cells[contadorGeral, 1]].Interior.Color = XlRgbColor.rgbBlack;
            planilha.Range[planilha.Cells[2, 2], planilha.Cells[contadorGeral, 9]].Interior.Color = XlRgbColor.rgbWhite;

            planilha.Range[planilha.Cells[posicaoTotalizador, 2], planilha.Cells[posicaoTotalizador, 9]].Font.Color = XlRgbColor.rgbDarkOrange;
            planilha.Range[planilha.Cells[posicaoTotalizador, 1], planilha.Cells[posicaoTotalizador, 9]].Interior.Color = XlRgbColor.rgbBlack;

            planilha.Columns.AutoFit();
            planilha.Calculate();
        }

        private void geraTipoBalanco(List<Tuple<string, List<decimal>>> tuplaValores, Application planilha, string tipo, bool ladoEsquerdo)
        {
            if (ladoEsquerdo)
            {
                planilha.Cells[contadorEsquerdo, 2] = tipo;
                planilha.Range[planilha.Cells[contadorEsquerdo, 2], planilha.Cells[contadorEsquerdo, 2]].Font.Bold = true;
                planilha.Range[planilha.Cells[contadorEsquerdo, 5], planilha.Cells[contadorEsquerdo, 5]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                contadorEsquerdo++;

                int contadorInicial = contadorEsquerdo;
                for (int i = 0; i < tuplaValores.Count; i++)
                {
                    planilha.Cells[contadorEsquerdo, 2] = tuplaValores[i].Item1;
                    planilha.Cells[contadorEsquerdo, 3] = tuplaValores[i].Item2[0];
                    planilha.Cells[contadorEsquerdo, 4] = tuplaValores[i].Item2[1];
                    planilha.Cells[contadorEsquerdo, 5] = tuplaValores[i].Item2[2];
                    planilha.Range[planilha.Cells[contadorEsquerdo, 2], planilha.Cells[contadorEsquerdo, 2]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    planilha.Range[planilha.Cells[contadorEsquerdo, 3], planilha.Cells[contadorEsquerdo, 3]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    planilha.Range[planilha.Cells[contadorEsquerdo, 4], planilha.Cells[contadorEsquerdo, 4]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    contadorEsquerdo++;
                }
                if (contadorInicial == contadorEsquerdo)
                    contadorEsquerdo++;
                planilha.Range[planilha.Cells[contadorEsquerdo, 2], planilha.Cells[contadorEsquerdo, 2]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                planilha.Range[planilha.Cells[contadorEsquerdo, 3], planilha.Cells[contadorEsquerdo, 3]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                planilha.Range[planilha.Cells[contadorEsquerdo, 4], planilha.Cells[contadorEsquerdo, 4]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                planilha.Range[planilha.Cells[contadorEsquerdo, 5], planilha.Cells[contadorEsquerdo, 5]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;

                planilha.Range[planilha.Cells[contadorEsquerdo, 3], planilha.Cells[contadorEsquerdo, 3]].FormulaLocal = "=SOMA(C" + contadorInicial + ":C" + (contadorEsquerdo - 1).ToString() + ")";
                somatorioLadoEsquerdo[0].Add("C" + contadorEsquerdo);
                planilha.Range[planilha.Cells[contadorEsquerdo, 4], planilha.Cells[contadorEsquerdo, 4]].FormulaLocal = "=SOMA(D" + contadorInicial + ":D" + (contadorEsquerdo - 1).ToString() + ")";
                somatorioLadoEsquerdo[1].Add("D" + contadorEsquerdo);
                planilha.Range[planilha.Cells[contadorEsquerdo, 5], planilha.Cells[contadorEsquerdo, 5]].FormulaLocal = "=SOMA(E" + contadorInicial + ":E" + (contadorEsquerdo - 1).ToString() + ")";
                somatorioLadoEsquerdo[2].Add("E" + contadorEsquerdo);

                planilha.Range[planilha.Cells[contadorInicial, 3], planilha.Cells[contadorEsquerdo, 5]].Numberformat = "#.###,00 ";
                planilha.Range[planilha.Cells[contadorEsquerdo, 3], planilha.Cells[contadorEsquerdo, 5]].Numberformat = "#.###,00 ";
                planilha.Range[planilha.Cells[contadorEsquerdo, 3], planilha.Cells[contadorEsquerdo, 5]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

                contadorEsquerdo += 2;
            }
            else
            {
                planilha.Cells[contadorDireito, 6] = tipo;
                planilha.Range[planilha.Cells[contadorDireito, 6], planilha.Cells[contadorDireito, 6]].Font.Bold = true;
                contadorDireito++;

                int contadorInicial = contadorDireito;
                for (int i = 0; i < tuplaValores.Count; i++)
                {
                    planilha.Cells[contadorDireito, 6] = tuplaValores[i].Item1;
                    planilha.Cells[contadorDireito, 7] = tuplaValores[i].Item2[0];
                    planilha.Cells[contadorDireito, 8] = tuplaValores[i].Item2[1];
                    planilha.Cells[contadorDireito, 9] = tuplaValores[i].Item2[2];
                    planilha.Range[planilha.Cells[contadorDireito, 6], planilha.Cells[contadorDireito, 6]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    planilha.Range[planilha.Cells[contadorDireito, 7], planilha.Cells[contadorDireito, 7]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    planilha.Range[planilha.Cells[contadorDireito, 8], planilha.Cells[contadorDireito, 8]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    contadorDireito++;
                }
                if (contadorInicial == contadorDireito)
                    contadorDireito++;
                planilha.Range[planilha.Cells[contadorDireito, 6], planilha.Cells[contadorDireito, 6]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                planilha.Range[planilha.Cells[contadorDireito, 7], planilha.Cells[contadorDireito, 7]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                planilha.Range[planilha.Cells[contadorDireito, 8], planilha.Cells[contadorDireito, 8]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                planilha.Range[planilha.Cells[contadorDireito, 9], planilha.Cells[contadorDireito, 9]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;

                planilha.Range[planilha.Cells[contadorDireito, 7], planilha.Cells[contadorDireito, 7]].FormulaLocal = "=SOMA(G" + contadorInicial + ":G" + (contadorDireito - 1).ToString() + ")";
                somatorioLadoDireito[0].Add("G" + contadorDireito);
                planilha.Range[planilha.Cells[contadorDireito, 8], planilha.Cells[contadorDireito, 8]].FormulaLocal = "=SOMA(H" + contadorInicial + ":H" + (contadorDireito - 1).ToString() + ")";
                somatorioLadoDireito[1].Add("H" + contadorDireito);
                planilha.Range[planilha.Cells[contadorDireito, 9], planilha.Cells[contadorDireito, 9]].FormulaLocal = "=SOMA(I" + contadorInicial + ":I" + (contadorDireito - 1).ToString() + ")";
                somatorioLadoDireito[2].Add("I" + contadorDireito);

                planilha.Range[planilha.Cells[contadorInicial, 7], planilha.Cells[contadorDireito, 9]].Numberformat = "#.###,00 ";
                planilha.Range[planilha.Cells[contadorDireito, 7], planilha.Cells[contadorDireito, 9]].Numberformat = "#.###,00 ";
                planilha.Range[planilha.Cells[contadorDireito, 7], planilha.Cells[contadorDireito, 9]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

                contadorDireito += 2;
            }
        }

        private void AnexaLinhaSomatorioTotal(Application planilha)
        {


            planilha.Cells[contadorGeral, 2] = "ATIVO TOTAL";
            planilha.Cells[contadorGeral, 6] = "PASSIVO TOTAL";

            planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 3]].FormulaLocal = "=SOMA(" + somatorioLadoEsquerdo[0][0] + ";" + somatorioLadoEsquerdo[0][1] + ";)";
            planilha.Range[planilha.Cells[contadorGeral, 4], planilha.Cells[contadorGeral, 4]].FormulaLocal = "=SOMA(" + somatorioLadoEsquerdo[1][0] + ";" + somatorioLadoEsquerdo[1][1] + ";)";
            planilha.Range[planilha.Cells[contadorGeral, 5], planilha.Cells[contadorGeral, 5]].FormulaLocal = "=SOMA(" + somatorioLadoEsquerdo[2][0] + ";" + somatorioLadoEsquerdo[2][1] + ";)";
            planilha.Range[planilha.Cells[contadorGeral, 7], planilha.Cells[contadorGeral, 7]].FormulaLocal = "=SOMA(" + somatorioLadoDireito[0][0] + ";" + somatorioLadoDireito[0][1] + ";" + somatorioLadoDireito[0][2] + ";)";
            planilha.Range[planilha.Cells[contadorGeral, 8], planilha.Cells[contadorGeral, 8]].FormulaLocal = "=SOMA(" + somatorioLadoDireito[1][0] + ";" + somatorioLadoDireito[1][1] + ";" + somatorioLadoDireito[1][2] + ";)";
            planilha.Range[planilha.Cells[contadorGeral, 9], planilha.Cells[contadorGeral, 9]].FormulaLocal = "=SOMA(" + somatorioLadoDireito[2][0] + ";" + somatorioLadoDireito[2][1] + ";" + somatorioLadoDireito[2][2] + ";)";

            posicaoTotalizador = contadorGeral;

            contadorGeral++;
            AnexaLinhaInconsistenciaTotal(planilha);
        }

        private void AnexaLinhaInconsistenciaTotal(Application planilha)
        {

            planilha.Range[planilha.Cells[contadorGeral, 7], planilha.Cells[contadorGeral, 7]].FormulaLocal = "=SOMA(C" + (contadorGeral - 1).ToString() + "-G" + (contadorGeral - 1).ToString() + ";)";
            planilha.Range[planilha.Cells[contadorGeral, 8], planilha.Cells[contadorGeral, 8]].FormulaLocal = "=SOMA(D" + (contadorGeral - 1).ToString() + "-H" + (contadorGeral - 1).ToString() + ";)";
            planilha.Range[planilha.Cells[contadorGeral, 9], planilha.Cells[contadorGeral, 9]].FormulaLocal = "=SOMA(E" + (contadorGeral - 1).ToString() + "-I" + (contadorGeral - 1).ToString() + ";)";


            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 9]].Font.Color = XlRgbColor.rgbWhite;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 9]].Interior.Color = XlRgbColor.rgbWhite;

            dynamic format = planilha.Range[planilha.Cells[contadorGeral, 7], planilha.Cells[contadorGeral, 7]].FormatConditions.Add(XlFormatConditionType.xlExpression, XlFormatConditionOperator.xlNotEqual,
             "=G" + contadorGeral + "<>0", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            format.Interior.Color = XlRgbColor.rgbRed;
            format.Font.Color = XlRgbColor.rgbBlack;

            format = planilha.Range[planilha.Cells[contadorGeral, 8], planilha.Cells[contadorGeral, 8]].FormatConditions.Add(XlFormatConditionType.xlExpression, XlFormatConditionOperator.xlNotEqual,
             "=H" + contadorGeral + "<>0", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            format.Interior.Color = XlRgbColor.rgbRed;
            format.Font.Color = XlRgbColor.rgbBlack;

            format = planilha.Range[planilha.Cells[contadorGeral, 9], planilha.Cells[contadorGeral, 9]].FormatConditions.Add(XlFormatConditionType.xlExpression, XlFormatConditionOperator.xlNotEqual,
             "=I" + contadorGeral + "<>0", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            format.Interior.Color = XlRgbColor.rgbRed;
            format.Font.Color = XlRgbColor.rgbBlack;
        }

        #endregion

        #region DRE
        private void GeraWorkSheetDRE(int idEmpresa, List<DateTime> meses, Application planilha)
        {
            posicaoTotalizador = 0;

            somatorioLadoEsquerdo = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };

            Empresa empresa = empresaRule.PesquisaEmpresaPorId(idEmpresa);

            CabecalhoDRE(planilha, empresa, meses);
            contadorGeral++;
            geraTipoDRE(geraTuplaValoresEmpresa(6, idEmpresa, meses), planilha, "RECEITAS OPERACIONAIS", "( = ) Receita Bruta de Vendas");contadorGeral--;
            geraTipoDRE(geraTuplaValoresEmpresa(10, idEmpresa, meses), planilha);
            SomatorioDRE(planilha, "( = ) RECEITA LÍQUIDA");

            somatorioLadoEsquerdo = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };
            somatorioLadoEsquerdo[0].Add("C" + (contadorGeral-2));
            somatorioLadoEsquerdo[1].Add("D" + (contadorGeral - 2));
            somatorioLadoEsquerdo[2].Add("E" + (contadorGeral - 2));

            geraTipoDRE(geraTuplaValoresEmpresa(7, idEmpresa, meses), planilha, "CUSTOS DO NEGÓCIO", "( = ) Custo Total");

            SomatorioDRE(planilha, "( = ) RESULTADO BRUTO");
            somatorioLadoEsquerdo = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };
            somatorioLadoEsquerdo[0].Add("C" + (contadorGeral - 2));
            somatorioLadoEsquerdo[1].Add("D" + (contadorGeral - 2));
            somatorioLadoEsquerdo[2].Add("E" + (contadorGeral - 2));

            geraTipoDRE(geraTuplaValoresEmpresa(8, idEmpresa, meses), planilha, "( +/- ) DESPESAS GERAIS");
            geraTipoDRE(geraTuplaValoresEmpresa(9, idEmpresa, meses), planilha, "( +/-) OPERAÇÕES FINANCEIRAS");

            SomatorioDRE(planilha, "( = ) RESULTADO OPERACIONAL",true);

            somatorioLadoEsquerdo = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };
            somatorioLadoEsquerdo[0].Add("C" + (contadorGeral - 2));
            somatorioLadoEsquerdo[1].Add("D" + (contadorGeral - 2));
            somatorioLadoEsquerdo[2].Add("E" + (contadorGeral - 2));

            geraTipoDRE(geraTuplaValoresEmpresa(11, idEmpresa, meses), planilha);

            SomatorioDRE(planilha, "( = ) RESULTADO LÍQUIDO DO EXERCÍCIO");

            planilha.Range[planilha.Cells[contadorGeral - 2, 2], planilha.Cells[contadorGeral -2, 5]].Font.Color = XlRgbColor.rgbDarkOrange;

            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; contadorGeral++;
            planilha.Cells[contadorGeral, 2] = "Responsável Administrativo";

            contadorGeral += 4;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; contadorGeral++;
            planilha.Cells[contadorGeral, 2] = "Contador"; contadorGeral++;
            planilha.Cells[contadorGeral, 2] = "CRC";

            planilha.Range[planilha.Cells[contadorGeral - 6, 2], planilha.Cells[contadorGeral, 2]].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            planilha.Range[planilha.Cells[2, 2], planilha.Cells[contadorGeral, 5]].Interior.Color = XlRgbColor.rgbWhite;

            planilha.Range[planilha.Cells[1, 1], planilha.Cells[contadorGeral, 1]].Interior.Color = XlRgbColor.rgbBlack;
            planilha.Range[planilha.Cells[contadorGeral - 9, 2], planilha.Cells[contadorGeral - 9, 5]].Interior.Color = XlRgbColor.rgbBlack;

            planilha.Columns.AutoFit();
            planilha.Calculate();
        }

        private void CabecalhoDRE(Application planilha, Empresa empresa, List<DateTime> meses)
        {
            Range oRange = (Range)planilha.ActiveSheet.Cells[1, 1];
            float Left = (float)((double)oRange.Left);
            float Top = (float)((double)oRange.Top);
            const float ImageSize = 40;
            planilha.ActiveSheet.Shapes.AddPicture(capturaLogoFatore(), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);

            planilha.Range[planilha.Cells[1, 2], planilha.Cells[1, 5]].Interior.Color = XlRgbColor.rgbBlack;

            planilha.Cells[1, 2] = "CONSULTORIA CONTABIL";
            planilha.Range[planilha.Cells[1, 2], planilha.Cells[1, 2]].Font.Color = XlRgbColor.rgbDarkOrange;
            planilha.Range[planilha.Cells[2, 2], planilha.Cells[2, 5]].Merge();
            planilha.Range[planilha.Cells[3, 2], planilha.Cells[2, 5]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;



            planilha.Cells[2, 2] = "Demonstração de Resultados";
            planilha.Cells[3, 2] = empresa.RazaoSocial.ToUpper();
            planilha.Range[planilha.Cells[2, 2], planilha.Cells[2, 2]].Font.Bold = true;

            planilha.Cells[3, 5] = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year;

            planilha.Range[planilha.Cells[3, 2], planilha.Cells[3, 4]].Merge();
            planilha.Range[planilha.Cells[4, 2], planilha.Cells[4, 5]].Merge();

            planilha.Cells[5, 3] = DateTime.DaysInMonth(meses[0].Year, meses[0].Month) + "/" + (meses[0].Month < 10 ? "0" + meses[0].Month : meses[0].Month.ToString()) + "/" + meses[0].Year;
            planilha.Cells[5, 4] = DateTime.DaysInMonth(meses[1].Year, meses[1].Month) + "/" + (meses[1].Month < 10 ? "0" + meses[1].Month : meses[1].Month.ToString()) + "/" + meses[1].Year;
            planilha.Cells[5, 5] = DateTime.DaysInMonth(meses[2].Year, meses[2].Month) + "/" + (meses[2].Month < 10 ? "0" + meses[2].Month : meses[2].Month.ToString()) + "/" + meses[2].Year;


            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 5]].Font.Bold = true;
            planilha.Range[planilha.Cells[5, 3], planilha.Cells[5, 5]].Font.Color = XlRgbColor.rgbDarkOrange;
            planilha.Range[planilha.Cells[5, 3], planilha.Cells[5, 5]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;

            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 2]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[5, 3], planilha.Cells[5, 3]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[5, 4], planilha.Cells[5, 4]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            contadorGeral = 5;
        }

        private void LoopContrucaoValoresDRE(List<Tuple<string, List<decimal>>> tuplaValores,Application planilha) 
        {
            for (int i = 0; i < tuplaValores.Count; i++)
            {
                planilha.Cells[contadorGeral, 2] = tuplaValores[i].Item1;
                planilha.Cells[contadorGeral, 3] = tuplaValores[i].Item2[0];
                planilha.Cells[contadorGeral, 4] = tuplaValores[i].Item2[1];
                planilha.Cells[contadorGeral, 5] = tuplaValores[i].Item2[2];
                planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 3]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                planilha.Range[planilha.Cells[contadorGeral, 4], planilha.Cells[contadorGeral, 4]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                contadorGeral++;
            }
        }

        private void geraTipoDRE(List<Tuple<string, List<decimal>>> tuplaValores, Application planilha, string tipo = "", string tituloSomatorio = "")
        {

            planilha.Cells[contadorGeral, 2] = tipo;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Font.Bold = true;
            contadorGeral++;


            int contadorInicial = contadorGeral;

            LoopContrucaoValoresDRE(tuplaValores, planilha);

            if (contadorInicial == contadorGeral)
                contadorGeral++;

            planilha.Cells[contadorGeral, 2] = tituloSomatorio;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Font.Bold = true;

            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 3]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[contadorGeral, 4], planilha.Cells[contadorGeral, 4]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[contadorGeral, 5], planilha.Cells[contadorGeral, 5]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;

            planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 3]].FormulaLocal = "=SOMA(C" + contadorInicial + ":C" + (contadorGeral - 1).ToString() + ")";
            somatorioLadoEsquerdo[0].Add("C" + contadorGeral);
            planilha.Range[planilha.Cells[contadorGeral, 4], planilha.Cells[contadorGeral, 4]].FormulaLocal = "=SOMA(D" + contadorInicial + ":D" + (contadorGeral - 1).ToString() + ")";
            somatorioLadoEsquerdo[1].Add("D" + contadorGeral);
            planilha.Range[planilha.Cells[contadorGeral, 5], planilha.Cells[contadorGeral, 5]].FormulaLocal = "=SOMA(E" + contadorInicial + ":E" + (contadorGeral - 1).ToString() + ")";
            somatorioLadoEsquerdo[2].Add("E" + contadorGeral);

            planilha.Range[planilha.Cells[contadorInicial, 3], planilha.Cells[contadorGeral, 5]].Numberformat = "#.###,00 ";
            planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 5]].Numberformat = "#.###,00 ";
            planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 5]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;

            contadorGeral += 2;
        }

        private void SomatorioDRE(Application planilha,string tituloSomatorio = "", bool somaTripla = false) {
            planilha.Cells[contadorGeral, 2] = tituloSomatorio;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Font.Bold = true;

            if (somaTripla)
            {
                planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 3]].FormulaLocal = "=SOMA(" + somatorioLadoEsquerdo[0][0] + ";" + somatorioLadoEsquerdo[0][1] + ";"
                    + ";" + somatorioLadoEsquerdo[0][2] + ";)";
                planilha.Range[planilha.Cells[contadorGeral, 4], planilha.Cells[contadorGeral, 4]].FormulaLocal = "=SOMA(" + somatorioLadoEsquerdo[1][0] + ";" + somatorioLadoEsquerdo[1][1] + ";"
                    + ";" + somatorioLadoEsquerdo[1][2] + ";)";
                planilha.Range[planilha.Cells[contadorGeral, 5], planilha.Cells[contadorGeral, 5]].FormulaLocal = "=SOMA(" + somatorioLadoEsquerdo[2][0] + ";" + somatorioLadoEsquerdo[2][1] + ";"
                    + ";" + somatorioLadoEsquerdo[2][2] + ";)";
            }
            else
            {
                planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 3]].FormulaLocal = "=SOMA(" + somatorioLadoEsquerdo[0][0] + ";" + somatorioLadoEsquerdo[0][1] + ";)";
                planilha.Range[planilha.Cells[contadorGeral, 4], planilha.Cells[contadorGeral, 4]].FormulaLocal = "=SOMA(" + somatorioLadoEsquerdo[1][0] + ";" + somatorioLadoEsquerdo[1][1] + ";)";
                planilha.Range[planilha.Cells[contadorGeral, 5], planilha.Cells[contadorGeral, 5]].FormulaLocal = "=SOMA(" + somatorioLadoEsquerdo[2][0] + ";" + somatorioLadoEsquerdo[2][1] + ";)";
            }

            planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 5]].Numberformat = "#.###,00 ";
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 5]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 5]].Font.Bold = true;
            planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 5]].Font.Color = XlRgbColor.rgbDarkOrange;

            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[contadorGeral, 3], planilha.Cells[contadorGeral, 3]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[contadorGeral, 4], planilha.Cells[contadorGeral, 4]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            contadorGeral+= 2;
        }

        #endregion

        #endregion
        }
}