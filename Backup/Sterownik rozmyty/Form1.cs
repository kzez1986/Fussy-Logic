using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FunkcjeR;

namespace Sterownik_rozmyty
{
    public partial class Form1 : Form
    {
        //zmienne do rozmycia
        private Stack<double> wyniki_deszcz;
        private Stack<double> wyniki_burza;
        private double zachmurzenie_małe, zachmurzenie_średnie, zachmurzenie_duże;
        private double wilgotność_mała, wilgotność_średnia, wilgotność_duża;
        private double ciśnienie_spada, ciśnienie_stabilne, ciśninie_rośnie;
        private double prawd_deszczu_małe, prawd_deszczu_średnie, prawd_deszczu_duże;
        private double prawd_burzy_małe, prawd_burzy_średnie, prawd_burzy_duże;
        private short[] prawdopodobieństwo = new short[2];
        private int[,] punkty_rozmycia = new int[3,4];
        int m; //liczba reguł
        double stopieńaktywacji1, stopieńaktywacji2;
        private short[,] p_przypadków = new short[2,27];
        public Form1()
        {
            InitializeComponent();
            //domyślne wartości
            trZachmurzenie.Value = 0;
            trWilgotność.Value = 0;
            trGradient.Value = 80;
            trZachmurzenie_Scroll(null, null);
            trWilgotność_Scroll(null, null);
            trGradient_Scroll(null, null);
            wyniki_deszcz = new Stack<double>();
            wyniki_burza = new Stack<double>();
            //wartości można modyfikować w celu eksperymentów
            punkty_rozmycia[0, 0] = 20;
            punkty_rozmycia[0, 1] = 80;
            punkty_rozmycia[0, 2] = 120;
            punkty_rozmycia[0, 3] = 140;
            punkty_rozmycia[1, 0] = 10;
            punkty_rozmycia[1, 1] = 50;
            punkty_rozmycia[1, 2] = 120;
            punkty_rozmycia[1, 3] = 150;
            punkty_rozmycia[2, 0] = 30;
            punkty_rozmycia[2, 1] = 70;
            punkty_rozmycia[2, 2] = 110;
            punkty_rozmycia[2, 3] = 140;
            p_przypadków[0, 0] = 0; p_przypadków[1, 0] = 0;
            p_przypadków[0, 1] = 0; p_przypadków[1, 1] = 0;
            p_przypadków[0, 2] = 0; p_przypadków[1, 2] = 0;
            p_przypadków[0, 3] = 1; p_przypadków[1, 3] = 0;
            p_przypadków[0, 4] = 0; p_przypadków[1, 4] = 0;
            p_przypadków[0, 5] = 1; p_przypadków[1, 5] = 1;
            p_przypadków[0, 6] = 1; p_przypadków[1, 6] = 0;
            p_przypadków[0, 7] = 0; p_przypadków[1, 7] = 1;
            p_przypadków[0, 8] = 1; p_przypadków[1, 8] = 1;
            p_przypadków[0, 9] = 0; p_przypadków[1, 9] = 0;
            p_przypadków[0, 10] = 0; p_przypadków[1, 10] = 0;
            p_przypadków[0, 11] = 1; p_przypadków[1, 11] = 1;
            p_przypadków[0, 12] = 0; p_przypadków[1, 12] = 0;
            p_przypadków[0, 13] = 1; p_przypadków[1, 13] = 1;
            p_przypadków[0, 14] = 1; p_przypadków[1, 14] = 1;
            p_przypadków[0, 15] = 1; p_przypadków[1, 15] = 1;
            p_przypadków[0, 16] = 1; p_przypadków[1, 16] = 1;
            p_przypadków[0, 17] = 2; p_przypadków[1, 17] = 2;
            p_przypadków[0, 18] = 0; p_przypadków[1, 18] = 0;
            p_przypadków[0, 19] = 1; p_przypadków[1, 19] = 1;
            p_przypadków[0, 20] = 1; p_przypadków[1, 20] = 1;
            p_przypadków[0, 21] = 1; p_przypadków[1, 21] = 1;
            p_przypadków[0, 22] = 1; p_przypadków[1, 22] = 1;
            p_przypadków[0, 23] = 2; p_przypadków[1, 23] = 2;
            p_przypadków[0, 24] = 1; p_przypadków[1, 24] = 1;
            p_przypadków[0, 25] = 2; p_przypadków[1, 25] = 2;
            p_przypadków[0, 26] = 2; p_przypadków[1, 26] = 2;
        }

        private void trZachmurzenie_Scroll(object sender, EventArgs e)
        {
            int zachmurzenie = trZachmurzenie.Value / 20;
            teZachmurzenie.Text = zachmurzenie.ToString();
        }

        private void trWilgotność_Scroll(object sender, EventArgs e)
        {
            int wilgotność = trWilgotność.Value * 10 / 20;
            teWilgotność.Text = wilgotność.ToString() + "%";
        }

        private void trGradient_Scroll(object sender, EventArgs e)
        {
            double gradient = (trGradient.Value / 2.0 - 2) / 20.0 - 1.9;
            teGradient.Text = gradient.ToString() + " hPA";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void BlokRozmywania()
        {
            FunkcjeRozmyte f = new FunkcjeRozmyte();
            zachmurzenie_małe = f.L(trZachmurzenie.Value, punkty_rozmycia[0,0], punkty_rozmycia[0,1]);
            zachmurzenie_średnie = f.PI(trZachmurzenie.Value, punkty_rozmycia[0, 0], punkty_rozmycia[0, 1], punkty_rozmycia[0, 2], punkty_rozmycia[0, 3]);
            zachmurzenie_duże = f.Gamma(trZachmurzenie.Value, punkty_rozmycia[0, 2], punkty_rozmycia[0, 3]);
            wilgotność_mała = f.L(trWilgotność.Value, punkty_rozmycia[1, 0], punkty_rozmycia[1, 1]);
            wilgotność_średnia = f.PI(trWilgotność.Value, punkty_rozmycia[1, 0], punkty_rozmycia[1, 1], punkty_rozmycia[1, 2], punkty_rozmycia[1, 3]);
            wilgotność_duża = f.Gamma(trWilgotność.Value, punkty_rozmycia[1, 2], punkty_rozmycia[1, 3]);
            ciśnienie_spada = f.L(trGradient.Value, punkty_rozmycia[2, 0], punkty_rozmycia[2, 1]);
            ciśnienie_stabilne = f.PI(trGradient.Value, punkty_rozmycia[2, 0], punkty_rozmycia[2, 1], punkty_rozmycia[2, 2], punkty_rozmycia[2, 3]);
            ciśninie_rośnie = f.Gamma(trGradient.Value, punkty_rozmycia[2, 2], punkty_rozmycia[2, 3]);
        }
        public double Przesłanki()
        {
            //p[0] - prawdopodobieństwo, że spadnie wogóle deszcz (zakłada się, że [pdczas nurzy też pada deszcz)
            //p[1] - prawdopodobieństwo wystąpienia burzy
            string[] p = new string[2];
            double[] wynik = new double[3];
            double iloczyn_mnogościowy;
            if (trZachmurzenie.Value < punkty_rozmycia[0,0]) //zachhmurzenie małe
            {
                wynik[0] = zachmurzenie_małe;
                if (trWilgotność.Value < punkty_rozmycia[1, 0]) //wilgotność mała
                {
                    wynik[1] = wilgotność_mała;
                    if (trGradient.Value < punkty_rozmycia[2, 0]) //ciśnienie spada
                    {
                        wynik[2] = ciśnienie_spada;
                        prawdopodobieństwo[0] = p_przypadków[0, 0];
                        prawdopodobieństwo[1] = p_przypadków[1, 0];
                    }
                    else if (trGradient.Value < punkty_rozmycia[2, 1]) //ciśnienie stabilne
                    {
                        wynik[2] = ciśnienie_stabilne;
                        prawdopodobieństwo[0] = p_przypadków[0, 1];
                        prawdopodobieństwo[1] = p_przypadków[1, 1];
                    }
                    else //ciśnienie rośnie
                    {
                        wynik[2] = ciśninie_rośnie;
                        prawdopodobieństwo[0] = p_przypadków[0, 2];
                        prawdopodobieństwo[1] = p_przypadków[1, 2];
                    }
                }
                else if (trWilgotność.Value < punkty_rozmycia[1, 1]) //wilgotność średnia
                {
                    wynik[1] = wilgotność_średnia;
                    if (trGradient.Value < punkty_rozmycia[2, 0]) //ciśnienie spada
                    {
                        wynik[2] = ciśnienie_spada;
                        prawdopodobieństwo[0] = p_przypadków[0, 3];
                        prawdopodobieństwo[1] = p_przypadków[1, 3];
                    }
                    else if (trGradient.Value < punkty_rozmycia[2, 1]) //ciśnienie stabilne
                    {
                        wynik[2] = ciśnienie_stabilne;
                        prawdopodobieństwo[0] = p_przypadków[0, 4];
                        prawdopodobieństwo[1] = p_przypadków[1, 4];
                    }
                    else //ciśnienie rośnie
                    {
                        wynik[2] = ciśninie_rośnie;
                        prawdopodobieństwo[0] = p_przypadków[0, 5];
                        prawdopodobieństwo[1] = p_przypadków[1, 5];
                    }
                }
                else //wilgotność duża
                {
                    wynik[1] = wilgotność_duża;
                    if (trGradient.Value < punkty_rozmycia[2, 0]) //ciśnienie spada
                    {
                        wynik[2] = ciśnienie_spada;
                        prawdopodobieństwo[0] = p_przypadków[0, 6];
                        prawdopodobieństwo[1] = p_przypadków[1, 6];
                    }
                    else if (trGradient.Value < punkty_rozmycia[2, 1]) //ciśnienie stabilne
                    {
                        wynik[2] = ciśnienie_stabilne;
                        prawdopodobieństwo[0] = p_przypadków[0, 7];
                        prawdopodobieństwo[1] = p_przypadków[1, 7];
                    }
                    else //ciśnienie rośnie
                    {
                        wynik[2] = ciśninie_rośnie;
                        prawdopodobieństwo[0] = p_przypadków[0, 8];
                        prawdopodobieństwo[1] = p_przypadków[1, 8];
                    }
                }
            }
            else if (trZachmurzenie.Value < punkty_rozmycia[0, 1]) //zachhmurzenie średnie
            {
                wynik[0] = zachmurzenie_średnie;
                if (trWilgotność.Value < punkty_rozmycia[1, 0]) //wilgotność mała
                {
                    wynik[1] = wilgotność_mała;
                    if (trGradient.Value < punkty_rozmycia[2, 0]) //ciśnienie spada
                    {
                        wynik[2] = ciśnienie_spada;
                        prawdopodobieństwo[0] = p_przypadków[0, 9];
                        prawdopodobieństwo[1] = p_przypadków[1, 9];
                    }
                    else if (trGradient.Value < punkty_rozmycia[2, 1]) //ciśnienie stabilne
                    {
                        wynik[2] = ciśnienie_stabilne;
                        prawdopodobieństwo[0] = p_przypadków[0, 10];
                        prawdopodobieństwo[1] = p_przypadków[1, 10];
                    }
                    else //ciśnienie rośnie
                    {
                        wynik[2] = ciśninie_rośnie;
                        prawdopodobieństwo[0] = p_przypadków[0, 11];
                        prawdopodobieństwo[1] = p_przypadków[1, 11];
                    }
                }
                else if (trWilgotność.Value < punkty_rozmycia[1, 1]) //wilgotność średnia
                {
                    wynik[1] = wilgotność_średnia;
                    if (trGradient.Value < punkty_rozmycia[2, 0]) //ciśnienie spada
                    {
                        wynik[2] = ciśnienie_spada;
                        prawdopodobieństwo[0] = p_przypadków[0, 12];
                        prawdopodobieństwo[1] = p_przypadków[1, 12];
                    }
                    else if (trGradient.Value < punkty_rozmycia[2, 1]) //ciśnienie stabilne
                    {
                        wynik[2] = ciśnienie_stabilne;
                        prawdopodobieństwo[0] = p_przypadków[0, 13];
                        prawdopodobieństwo[1] = p_przypadków[1, 13];
                    }
                    else //ciśnienie rośnie
                    {
                        wynik[2] = ciśninie_rośnie;
                        prawdopodobieństwo[0] = p_przypadków[0, 14];
                        prawdopodobieństwo[1] = p_przypadków[1, 14];
                    }
                }
                else //wilgotność duża
                {
                    wynik[1] = wilgotność_duża;
                    if (trGradient.Value < punkty_rozmycia[2, 0]) //ciśnienie spada
                    {
                        wynik[2] = ciśnienie_spada;
                        prawdopodobieństwo[0] = p_przypadków[0, 15];
                        prawdopodobieństwo[1] = p_przypadków[1, 15];
                    }
                    else if (trGradient.Value < punkty_rozmycia[2, 1]) //ciśnienie stabilne
                    {
                        wynik[2] = ciśnienie_stabilne;
                        prawdopodobieństwo[0] = p_przypadków[0, 16];
                        prawdopodobieństwo[1] = p_przypadków[1, 16];
                    }
                    else //ciśnienie rośnie
                    {
                        wynik[2] = ciśninie_rośnie;
                        prawdopodobieństwo[0] = p_przypadków[0, 17];
                        prawdopodobieństwo[1] = p_przypadków[1, 17];
                    }
                }
            }
            else //zachhmurzenie duże
            {
                wynik[0] = zachmurzenie_duże;
                if (trWilgotność.Value < punkty_rozmycia[1, 0]) //wilgotność mała
                {
                    wynik[1] = wilgotność_mała;
                    if (trGradient.Value < punkty_rozmycia[2, 0]) //ciśnienie spada
                    {
                        wynik[2] = ciśnienie_spada;
                        prawdopodobieństwo[0] = p_przypadków[0, 18];
                        prawdopodobieństwo[1] = p_przypadków[1, 18];
                    }
                    else if (trGradient.Value < punkty_rozmycia[2, 1]) //ciśnienie stabilne
                    {
                        wynik[2] = ciśnienie_stabilne;
                        prawdopodobieństwo[0] = p_przypadków[0, 19];
                        prawdopodobieństwo[1] = p_przypadków[1, 19];
                    }
                    else //ciśnienie rośnie
                    {
                        wynik[2] = ciśninie_rośnie;
                        prawdopodobieństwo[0] = p_przypadków[0, 20];
                        prawdopodobieństwo[1] = p_przypadków[1, 20];
                    }
                }
                else if (trWilgotność.Value < punkty_rozmycia[1, 1]) //wilgotność średnia
                {
                    wynik[1] = wilgotność_średnia;
                    if (trGradient.Value < punkty_rozmycia[2, 0]) //ciśnienie spada
                    {
                        wynik[2] = ciśnienie_spada;
                        prawdopodobieństwo[0] = p_przypadków[0, 21];
                        prawdopodobieństwo[1] = p_przypadków[1, 21];
                    }
                    else if (trGradient.Value < punkty_rozmycia[2, 1]) //ciśnienie stabilne
                    {
                        wynik[2] = ciśnienie_stabilne;
                        prawdopodobieństwo[0] = p_przypadków[0, 22];
                        prawdopodobieństwo[1] = p_przypadków[1, 22];
                    }
                    else //ciśnienie rośnie
                    {
                        wynik[2] = ciśninie_rośnie;
                        prawdopodobieństwo[0] = p_przypadków[0, 23];
                        prawdopodobieństwo[1] = p_przypadków[1, 23];
                    }
                }
                else //wilgotność duża
                {
                    wynik[1] = wilgotność_duża;
                    if (trGradient.Value < punkty_rozmycia[2, 0]) //ciśnienie spada
                    {
                        wynik[2] = ciśnienie_spada;
                        prawdopodobieństwo[0] = p_przypadków[0, 24];
                        prawdopodobieństwo[1] = p_przypadków[1, 24];
                    }
                    else if (trGradient.Value < punkty_rozmycia[2, 1]) //ciśnienie stabilne
                    {
                        wynik[2] = ciśnienie_stabilne;
                        prawdopodobieństwo[0] = p_przypadków[0, 25];
                        prawdopodobieństwo[1] = p_przypadków[1, 25];
                    }
                    else //ciśnienie rośnie
                    {
                        wynik[2] = ciśninie_rośnie;
                        prawdopodobieństwo[0] = p_przypadków[0, 26];
                        prawdopodobieństwo[1] = p_przypadków[1, 26];
                    }
                }
            }
            iloczyn_mnogościowy = wynik.Min();
            return iloczyn_mnogościowy;
        }

        public double[] StopieńAktywacji()
        {
            double[] dane_przypadku = new double[3];
            wyniki_deszcz.Clear();
            wyniki_burza.Clear();
            //kolejno - zachmurzenie, wilgotność, gradient ciśnienia
            //deszcz
            if(prawdopodobieństwo[0] == 0)
            {    
                for (int j = 0; j < 27; j++)
                {
                    if (p_przypadków[0, j] == 0)
                    {
                        dane_przypadku = PrzypadekNaDane(j);
                        wyniki_deszcz.Push(dane_przypadku.Min());

                    }
                }
            }
            if (prawdopodobieństwo[0] == 1)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (p_przypadków[0, j] == 1)
                    {
                        dane_przypadku = PrzypadekNaDane(j);
                        wyniki_deszcz.Push(dane_przypadku.Min());

                    }
                }
            }
            if (prawdopodobieństwo[0] == 2)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (p_przypadków[0, j] == 2)
                    {
                        dane_przypadku = PrzypadekNaDane(j);
                        wyniki_deszcz.Push(dane_przypadku.Min());

                    }
                }
            }
            if (prawdopodobieństwo[1] == 0)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (p_przypadków[1, j] == 0)
                    {
                        dane_przypadku = PrzypadekNaDane(j);
                        wyniki_burza.Push(dane_przypadku.Min());

                    }
                }
            }
            if (prawdopodobieństwo[0] == 1)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (p_przypadków[1, j] == 1)
                    {
                        dane_przypadku = PrzypadekNaDane(j);
                        wyniki_burza.Push(dane_przypadku.Min());

                    }
                }
            }
            if (prawdopodobieństwo[0] == 2)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (p_przypadków[1, j] == 2)
                    {
                        dane_przypadku = PrzypadekNaDane(j);
                        wyniki_burza.Push(dane_przypadku.Min());

                    }
                }
            }
           
            double[] wyjście = new double[2];
            wyjście[0] = wyniki_deszcz.Max();
            wyjście[1] = wyniki_burza.Max();
            stopieńaktywacji1 = wyjście[0];
            stopieńaktywacji2 = wyjście[1];
            return wyjście;
        }

        public double[] WyostrzanieSingleton()
        {
            double[] wynik = new double[2];
            double suma1 = 0;
            double suma2 = 0;
            double suma3 = 0;
            double suma4 = 0;
            for (int i = 0; i < wyniki_deszcz.Count; i++)
            {
                suma1 += stopieńaktywacji1 * wyniki_deszcz.Peek();
                suma2 += wyniki_deszcz.Pop();
            }
            for (int i = 0; i < wyniki_burza.Count; i++)
            {

            }
            if (suma2 == 0)
                suma2 = 0.0000001;
            if (suma4 == 0)
                suma4 = 0.0000001;
            wynik[0] = suma1 / suma2;
            wynik[1] = suma3 / suma4;
            return wynik;
        }

        private void buStart_Click(object sender, EventArgs e)
        {
            BlokRozmywania();
            teIloczyn.Text = Przesłanki().ToString();
            double[] temp = new double[2];
            temp = StopieńAktywacji();
            teStopieńAktywacji.Text = temp[0].ToString();
            teStopieńBurzy.Text = temp[1].ToString();
            temp = WyostrzanieSingleton();
            textBox1.Text = temp[0].ToString();
            textBox2.Text = temp[1].ToString();
        }
        private double[] PrzypadekNaDane(int numer)
        {
            double[] wyniki = new double[3];
            if (numer < 9)
            {
                wyniki[0] = zachmurzenie_małe;
            }
            else if (numer < 18)
            {
                wyniki[0] = zachmurzenie_średnie;
            }
            else
            {
                wyniki[0] = zachmurzenie_duże;
            }
            if (numer % 9 < 3)
            {
                wyniki[1] = wilgotność_mała;
            }
            if (numer % 9 < 6)
            {
                wyniki[1] = wilgotność_średnia;
            }
            else
            {
                wyniki[1] = wilgotność_duża;
            }
            if (numer % 3 == 0)
            {
                wyniki[2] = ciśnienie_spada;
            }
            else if (numer % 3 == 1)
            {
                wyniki[2] = ciśnienie_stabilne;
            }
            else
            {
                wyniki[2] = ciśninie_rośnie;
            }
            return wyniki;
        }
    }
}
