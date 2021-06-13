using Microsoft.Office.Interop.Excel;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void GeraExcelConsultoriaContabil(int idEmpresa, List<string> meses)
        {
            somatorioLadoEsquerdo = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };
            somatorioLadoDireito = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };

            Empresa empresa = empresaRule.PesquisaEmpresaPorId(idEmpresa);

            Application planilha = new Application();
            planilha.Application.Workbooks.Add(Type.Missing);

            planilha.Range[planilha.Cells[1, 1], planilha.Cells[1, 9]].Interior.Color = XlRgbColor.rgbBlack;

            planilha.Cells[1, 2] = "CONSULTORIA CONTABIL";
            planilha.Range[planilha.Cells[1, 2], planilha.Cells[1, 2]].Font.Color = XlRgbColor.rgbDarkOrange;

            planilha.Range[planilha.Cells[2, 2], planilha.Cells[2, 8]].Merge();
            planilha.Range[planilha.Cells[3, 2], planilha.Cells[3, 7]].Merge();

            planilha.Range[planilha.Cells[2, 2], planilha.Cells[2, 9]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;



            planilha.Cells[2, 2] = "Balanço Patrimonial";
            planilha.Cells[3, 2] = empresa.RazaoSocial;
            planilha.Cells[3, 8] = "Data Base:";
            planilha.Cells[3, 9] = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year;

            planilha.Range[planilha.Cells[4, 2], planilha.Cells[4, 9]].Merge();
            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 5]].Merge();
            planilha.Cells[5, 2] = "Ativo";
            planilha.Range[planilha.Cells[5, 6], planilha.Cells[5, 9]].Merge();
            planilha.Cells[5, 6] = "Passivo";
            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 9]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            planilha.Range[planilha.Cells[5, 2], planilha.Cells[5, 5]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;


            planilha.Range[planilha.Cells[6, 2], planilha.Cells[6, 5]].Merge();
            planilha.Range[planilha.Cells[6, 6], planilha.Cells[6, 9]].Merge();
            planilha.Cells[7, 3] = System.DateTime.DaysInMonth(int.Parse(meses[0].Substring(3, 4)), int.Parse(meses[0].Substring(0, 2))) + "/" + int.Parse(meses[0].Substring(0, 2)) + "/" + int.Parse(meses[0].Substring(3, 4));
            planilha.Cells[7, 4] = System.DateTime.DaysInMonth(int.Parse(meses[1].Substring(3, 4)), int.Parse(meses[1].Substring(0, 2))) + "/" + int.Parse(meses[1].Substring(0, 2)) + "/" + int.Parse(meses[1].Substring(3, 4));
            planilha.Cells[7, 5] = System.DateTime.DaysInMonth(int.Parse(meses[2].Substring(3, 4)), int.Parse(meses[2].Substring(0, 2))) + "/" + int.Parse(meses[2].Substring(0, 2)) + "/" + int.Parse(meses[2].Substring(3, 4));
            planilha.Cells[7, 7] = System.DateTime.DaysInMonth(int.Parse(meses[0].Substring(3, 4)), int.Parse(meses[0].Substring(0, 2))) + "/" + int.Parse(meses[0].Substring(0, 2)) + "/" + int.Parse(meses[0].Substring(3, 4));
            planilha.Cells[7, 8] = System.DateTime.DaysInMonth(int.Parse(meses[1].Substring(3, 4)), int.Parse(meses[1].Substring(0, 2))) + "/" + int.Parse(meses[1].Substring(0, 2)) + "/" + int.Parse(meses[1].Substring(3, 4));
            planilha.Cells[7, 9] = System.DateTime.DaysInMonth(int.Parse(meses[2].Substring(3, 4)), int.Parse(meses[2].Substring(0, 2))) + "/" + int.Parse(meses[2].Substring(0, 2)) + "/" + int.Parse(meses[2].Substring(3, 4));


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

            geraTipoBalanco(geraTuplaValoresEmpresa(idEmpresa, meses), planilha, "ATIVO CIRCULANTE", true);
            geraTipoBalanco(geraTuplaValoresEmpresa(idEmpresa, meses), planilha, "ATIVO NÃO CIRCULANTE", true);
            geraTipoBalanco(geraTuplaValoresEmpresa(idEmpresa, meses), planilha, "PASSIVO CIRCULANTE", false);
            geraTipoBalanco(geraTuplaValoresEmpresa(idEmpresa, meses), planilha, "PASSIVO NÃO CIRCULANTE", false);
            geraTipoBalanco(geraTuplaValoresEmpresa(idEmpresa, meses), planilha, "PATRIMÔNIO LÍQUIDO", false);


            contadorGeral = contadorEsquerdo > contadorDireito ? contadorEsquerdo : contadorDireito;
            planilha.Range[planilha.Cells[3, 5], planilha.Cells[contadorGeral - 1, 5]].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            AnexaLinhaSomatorioTotal(planilha);

            contadorGeral += 2;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; contadorGeral++;
            planilha.Cells[contadorGeral, 2] = "Responsável Administrativo";

            contadorGeral += 4;
            planilha.Range[planilha.Cells[contadorGeral, 2], planilha.Cells[contadorGeral, 2]].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; contadorGeral++;
            planilha.Cells[contadorGeral, 2] = "Contador"; contadorGeral++;
            planilha.Cells[contadorGeral, 2] = "CRC";

            planilha.Range[planilha.Cells[1, 1], planilha.Cells[contadorGeral, 1]].Interior.Color = XlRgbColor.rgbBlack;
            planilha.Range[planilha.Cells[2, 2], planilha.Cells[contadorGeral, 9]].Interior.Color = XlRgbColor.rgbWhite;

            planilha.Range[planilha.Cells[posicaoTotalizador, 2], planilha.Cells[posicaoTotalizador, 9]].Font.Color = XlRgbColor.rgbDarkOrange;
            planilha.Range[planilha.Cells[posicaoTotalizador, 1], planilha.Cells[posicaoTotalizador, 9]].Interior.Color = XlRgbColor.rgbBlack;

            planilha.Columns.AutoFit();
            planilha.Calculate();
            planilha.Visible = true;
        }

        private List<Tuple<string, List<decimal>>> geraTuplaValoresEmpresa(int idEmpresa, List<string> meses)
        {
            List<decimal> listaValores = new List<decimal>();
            //enche listaValores
            List<Tuple<string, List<decimal>>> tupla = new List<Tuple<string, List<decimal>>>();

            for (int i = 0; i < 10; i++)
            {
                listaValores = new List<decimal> { 0, 0, 0 };
                tupla.Add(new Tuple<string, List<decimal>>("teste" + i, listaValores));
            }

            return tupla;
        }

        private void geraTipoBalanco(List<Tuple<string, List<decimal>>> tuplaValores, Application planilha, string tipo, bool ladoEsquerdo)
        {
            if (ladoEsquerdo)
            {
                planilha.Cells[contadorEsquerdo, 2] = tipo;
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
    } 
    #endregion
}