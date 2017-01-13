using QuartoTGProject.Podaci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuartoTGProject
{
    public partial class Form1 : Form
    {
        public int pobedio = 0;
        public static Figura[][] mat;
        public List<Figura> kontrolniDugmici;
        public Context kontekst;
        public Form1()
        {
            InitializeComponent();
        }

        public Pocetak poc { get; set; }

        void crtajTablu()
        {
            mat = new Figura[4][];

            for (int i = 0; i < 4; i++)
            {
                mat[i] = new Figura[4];
            }
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    mat[i][k] = new Figura();
                    mat[i][k].f = this;
                    mat[i][k].Kontrola = false;
                }

            }
            int y = -panelTabla.Height / 4;
            for (int i = 0; i < 4; i++)
            {
                y += panelTabla.Height / 4;
                int x = 0;
                for (int j = 0; j < 4; j++)
                {
                    mat[i][j].Parent = panelTabla;
                    mat[i][j].Size = new Size(mat[i][j].Parent.Width / 4, mat[i][j].Parent.Height / 4);
                    mat[i][j].Location = new Point(x, y);
                    mat[i][j].x = i;
                    mat[i][j].y = j;
                    x += panelTabla.Width / 4;
                }
            }
        }
        
        void crtajKontrolneDugmice() {
            int y = 0;
            int x = 0;
            grpP1.Size = new Size(100, 400);
            bool a1 = false;
            bool a2 = false;
            bool a3 = false;
            bool a4 = false;
            int cnt = 0;
            for (int i = 1; i <= 16; i++)
            {
                a4 = !a4;
                if (cnt % 2 == 0)
                    a3 = !a3;
                if (cnt % 4 == 0)
                    a2 = !a2;
                if (cnt % 8 == 0)
                    a1 = !a1;


                if (i == 9)
                {
                    x += 50;
                    y = 0;
                }

                Figura f1 = new Figura(a1, a2, a3, a4);
                f1.Text = f1.ToString();
                if (f1.Color == true)
                    f1.BackColor = Color.Red;
                else f1.BackColor = System.Drawing.Color.Blue;
                f1.Kontrola = true;

                f1.Size = new Size(50, 50);
                f1.Parent = grpP1;
                f1.f = this;
                f1.Location = new Point(x, y);
                kontrolniDugmici.Add(f1);
                y += 50;
                cnt++;
            }
            Figura.Kontrole = kontrolniDugmici;

        }
        public virtual void UradiPotez(Potez p, Figura fg)
        {
            textBox1.Text = "";
            for (int i=0; i < 4;i++)
            {
                for (int j=0;j<4;j++)
                {
                    textBox1.Text += mat[i][j].Popunjeno + " ";
                }
                textBox1.Text += "\n";
            }
            string info;
            //Promena
            if (kontekst.TrenutnoStanje.Potez(1, p.x, p.y, out info))
            {
                if (Form1.DaLiJeKraj()/*kontekst.TrenutnoStanje.DaLiJeKraj()*/)
                {
                    DialogResult dlg;
                    if (kontekst.NaPotezu == 1)
                        dlg = MessageBox.Show("Pobedio je prvi igrac!");
                    else
                        dlg = MessageBox.Show("Pobedio je drugi igrac!");
                    /*  if (dlg == DialogResult.OK)
                      {
                          Form2 frm = new Form2();
                          frm.FormaIgrica = this;
                          frm.ShowDialog();
                      }*/
                    return;
                }
                kontekst.Sledeci();
                if (kontekst.NaPotezu == 1)
                    lblIgrac.Text = "Na potezu je prvi igrac";
                else
                    lblIgrac.Text = "Na potezu je drugi igrac";
                textBox2.Text = "";
                textBox2.Text = Tabla.t;
                

                string k = "";
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                        k += kontekst.TrenutnoStanje._mat[i][j].Popunjeno + " ";
                    k += "\n";
                }
                MessageBox.Show(k, "Trenutno stanje matrice odnosno table");
            }
            else
            {
                MessageBox.Show(info);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblIgrac.Text = "Na potezu je prvi igrac!";
            kontrolniDugmici = new List<Figura>();
            this.crtajTablu();
            crtajKontrolneDugmice();
            kontekst = new Context(new Tabla(), 1);
            kontekst.TrenutnoStanje._mat = mat; //ispitaj to
           
            Figura.kontekst = kontekst;
        }

        public static bool DaLiJeKraj()
        {
            int c, cf, h, hf, s, sf, t, tf;
            c = cf = h = hf = s = sf = t = tf = 0;
            //glavna dijagonala
            for (int i = 0; i < 4; i++)
            {

                if (mat[i][i].Popunjeno != 0)
                {
                    if (mat[i][i].Color)
                        c++;
                    else if (mat[i][i].Color)
                        cf++;
                    if (mat[i][i].Heigth)
                        h++;
                    else if (!mat[i][i].Heigth)
                        hf++;
                    if (mat[i][i].Shape)
                        s++;
                    else if (!mat[i][i].Shape)
                        sf++;
                    if (mat[i][i].Top)
                        t++;
                    else if (!mat[i][i].Top)
                        tf++;
                    if (c == 4 || cf == 4 || h == 4 || hf == 4 || s == 4 || sf == 4
                        || t == 4 || tf == 4)
                        return true;
                }
            }
            //sporedna dijagonala
            c = cf = h = hf = s = sf = t = tf = 0;
            for (int i = 0; i < 4; i++)
            {
                if (mat[i][3 - i].Popunjeno != 0)
                {
                    if (mat[i][3 - i].Color)
                        c++;
                    else if (!mat[i][3 - i].Color)
                        cf++;
                    if (mat[i][3 - i].Heigth)
                        h++;
                    else if (!mat[i][3 - i].Heigth)
                        hf++;
                    if (mat[i][3 - i].Shape)
                        s++;
                    else if (!mat[i][3 - i].Shape)
                        sf++;
                    if (mat[i][3 - i].Top)
                        t++;
                    else if (!mat[i][3 - i].Top)
                        tf++;
                    if (c == 4 || cf == 4 || h == 4 || hf == 4 || s == 4 || sf == 4
                        || t == 4 || tf == 4)
                        return true;
                }
            }
            // redovi
            for (int i = 0; i < 4; i++)
            {
                c = cf = h = hf = s = sf = t = tf = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (mat[i][j].Popunjeno != 0)
                    {
                        if (mat[i][j].Color)
                            c++;
                        else if (!mat[i][j].Color)
                            cf++;
                        if (mat[i][j].Heigth)
                            h++;
                        else if (!mat[i][j].Heigth)
                            hf++;
                        if (mat[i][j].Shape)
                            s++;
                        else if (!mat[i][j].Shape)
                            sf++;
                        if (mat[i][j].Top)
                            t++;
                        else if (!mat[i][j].Top)
                            tf++;
                        if (c == 4 || cf == 4 || h == 4 || hf == 4 || s == 4 || sf == 4
                            || t == 4 || tf == 4)
                            return true;
                    }
                }
            }
            //kolone
            for (int j = 0; j < 4; j++)
            {
                c = cf = h = hf = s = sf = t = tf = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (mat[i][j].Popunjeno != 0)
                    {
                        if (mat[i][j].Color)
                            c++;
                        else if (!mat[i][j].Color)
                            cf++;
                        if (mat[i][j].Heigth)
                            h++;
                        else if (!mat[i][j].Heigth)
                            hf++;
                        if (mat[i][j].Shape)
                            s++;
                        else if (!mat[i][j].Shape)
                            sf++;
                        if (mat[i][j].Top)
                            t++;
                        else if (!mat[i][j].Top)
                            tf++;
                        if (c == 4 || cf == 4 || h == 4 || hf == 4 || s == 4 || sf == 4
                            || t == 4 || tf == 4)
                            return true;
                    }
                }
            }
            return false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            poc.Close();
        }
       
    }
}
