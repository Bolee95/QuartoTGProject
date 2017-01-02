using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace QuartoTGProject.Podaci
{
    public class Figura : Button
    {
        public static int temp = 0;
        
        bool kontrola;
        public static Figura glob;
        public static Figura prethodna;
        public static List<Figura> iskorisceneKontrole = new List<Figura>();
        public static List<Figura> Kontrole;
        public static Context kontekst;
        bool heigth; // true = tall, false = short
        bool color;  // true = player1(red),false = player2(blue)
        bool shape; // true = square, false = circle
        bool top;  // true = solid, false - hollow
        int popunjeno;
        public int x, y;
        public Form1 f { get; set; }
        #region Propeties
        public bool Heigth
        {
            get
            {
                return heigth;
            }

            set
            {
                heigth = value;
            }
        }

        public bool Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public bool Shape
        {
            get
            {
                return shape;
            }

            set
            {
                shape = value;
            }
        }

        public bool Top
        {
            get
            {
                return top;
            }

            set
            {
                top = value;
            }
        }

        public bool Kontrola
        {
            get
            {
                return kontrola;
            }

            set
            {
                kontrola = value;
            }
        }

        public int Popunjeno
        {
            get
            {
                return popunjeno;
            }

            set
            {
                popunjeno = value;
            }
        }
        #endregion

        public Figura(bool c, bool h, bool s, bool t) :base()
        {
            heigth = h;
            color = c;
            shape = s;
            top = t;
            this.Click += new EventHandler(this.KlikMisa);
            popunjeno = 0;
        }

        public Figura(Figura g)
        {
            this.heigth = g.heigth;
            this.color = g.color;
            this.shape = g.shape;
            this.top = g.top;
            popunjeno = g.popunjeno;
            this.Click += new EventHandler(this.KlikMisa);
        }
        public Figura() {
            this.Click += new EventHandler(this.KlikMisa);
            popunjeno = 0;
        }
        private void KlikMisa(object sender, EventArgs e) {
            if (this.Kontrola == true)
            {
                if (prethodna != null)
                {
                  
                }
                glob = this;


            }
            else if (glob != null)
            {
                if (String.IsNullOrEmpty(Text))
                {
                   
                    this.color = glob.color;
                    this.heigth = glob.heigth;
                    this.top = glob.top;
                    this.shape = glob.shape;
                    this.Text = ToString();
                    if (color == true)
                        this.BackColor = System.Drawing.Color.Red;
                    else BackColor = System.Drawing.Color.Blue;
                    f.UradiPotez(new Potez()
                    {
                        x = x,
                        y = y,
                    });
                    prethodna = new Figura(glob);
                    iskorisceneKontrole.Add(glob);

                    
                    validacijaKontrola();
                    
                    glob.Visible = false;
                    glob = null;
                    //kontekst.TrenutnoStanje.DaLiJeKraj();
                    Form1.DaLiJeKraj();


                }
              
            }
            if (kontekst.NaPotezu == 2) // treba da uzima kontrolno dugme i da ga preslika na tablu
            {
                try
                {
                    if (kontekst.TrenutnoStanje.DoKraja() == 0)
                    {
                        MessageBox.Show("Nerešeno");
                        return;
                    }
                    Figura figure = new Figura();
                    foreach(Figura f in Kontrole)
                    {

                        if (f.Enabled)
                        {
                            figure = f;
                            break;
                        }
                          
                    }
                    // mozda ovde treba proveriti da li je kraj
                    if (!Form1.DaLiJeKraj()/*f.kontekst.TrenutnoStanje.DaLiJeKraj()*/)
                    {
                        Potez px = Context.AlfaBeta(kontekst, int.MinValue, int.MaxValue, 3 , true);
                        if (Form1.mat[px.x][px.y].Popunjeno == 0)
                        {
                            f.UradiPotez(px);
                            if (color == true)
                                Form1.mat[px.x][px.y].BackColor = System.Drawing.Color.Red;

                            else
                                Form1.mat[px.x][px.y].BackColor = System.Drawing.Color.Blue;
                            Form1.mat[px.x][px.y].Text = figure.ToString();
                            Form1.mat[px.x][px.y].heigth = figure.heigth;
                            Form1.mat[px.x][px.y].shape = figure.shape;
                            Form1.mat[px.x][px.y].top = figure.top;
                            prethodna = new Figura(figure);
                            iskorisceneKontrole.Add(figure);
                            validacijaKontrola();
                            figure.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Polje je popunjeno!");
                        }
                    }
                }
                finally
                {
                }
            }
        }

        public bool validacijaPoteza()
        {
            bool ret = false;
            if (this.color == prethodna.Color)
                ret = true;
            if (this.top == prethodna.Top)
                ret = true;
            if (this.shape == prethodna.Shape)
                ret = true;
            if (this.heigth == prethodna.heigth)
                ret = true;
            return ret;

        }

        public void validacijaKontrola()
        { 
            foreach (Figura f in Kontrole)
            {
                if (f.validacijaPoteza() && !iskorisceneKontrole.Contains(f))
                {
                    f.Enabled = true;
                    if (f.Color == true)
                        f.BackColor = System.Drawing.Color.Red;
                    else f.BackColor = System.Drawing.Color.Blue;
                }
                else
                {
                    f.Enabled = false;
                    f.BackColor = System.Drawing.Color.Gray;
                }

            }
        }
      

        public override string ToString()
        {
            string s="";
            if (color)
                s += "1";
            else s += "0";
            if (heigth)
                s += "1";
            else s += "0";
            if(shape)
                s += "1";
            else s += "0";
            if(top)
                s += "1";
            else s += "0";
            return s;

        }
    }
}
