using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Test GitHub
namespace QuartoTGProject.Podaci
{
    public class Context
    {
        public static List<Potez> _potezi = new List<Potez>();
        public int NaPotezu { get; set; }
        public Tabla TrenutnoStanje { get;  set; }

        private List<Potez> listaPoteza = new List<Potez>();

        public int Value { get; set; }

        public List<Potez> _Potezi
        {
            get
            {
                return _potezi;
            }

            set
            {
                _potezi = value;
            }
        }

        public Context(Tabla t, int igrac)
        {
            NaPotezu = igrac;
            TrenutnoStanje = t;
            Value = 0;
        }

        public virtual int Evaluate(int x)
        {
            return TrenutnoStanje.Evaluacija(x);
        }

        internal void Sledeci() 
        {
            if (NaPotezu == 1)
                NaPotezu = 2;
            else
                NaPotezu = 1;
           // NaPotezu = NaPotezu ^ 3;
        }

        public List<Potez> GetListaMogucihPoteza() //Za svaki potez i za svaku figuru kombinacija
        {
            List<Potez> potezi = TrenutnoStanje.GetListaPoteza();
            foreach (Figura f in Figura.Kontrole)
            {
                if (f.Enabled)
                {         
                    potezi.ForEach(x =>
                    {
                        string info;
                        x.PrethodnoStanje = this;
                        x.NarednoStanje = new Context(new Tabla(TrenutnoStanje), NaPotezu);
                        x.NarednoStanje.TrenutnoStanje.Potez(NaPotezu, x.x, x.y, out info);
                        x.NarednoStanje.Sledeci();
                    });
                }
            }
            return potezi;
        }


        //-------------->>>>>Stari kod za AlfaBeta<<<<<<<<<<<<<<-------------------

       /* public static Potez AlfaBeta(Context c, int alfa, int beta, int depth, bool maximizing)
        {
            Potez bestV = new Potez();
            Potez ret = new Potez();
            List<Potez> moves = new List<Potez>();

            //moves = c.TrenutnoStanje.GetListaPoteza();
            if (c.TrenutnoStanje.DaLiJeKraj() || depth == 0)
            {
                //ret.Value = c.Evaluate();
                //return ret;
                bestV.Value = c.Evaluate();   //proveri ovo!
                return bestV;
            }
            if (maximizing)
            {
                bestV.Value = int.MinValue;
                moves = c.GetListaMogucihPoteza();
                foreach (Potez m in moves)
                {
                    ret = AlfaBeta(m.NarednoStanje, alfa, beta, depth - 1, false);
                    int val = bestV.Value;
                    bestV.Value = Math.Max(bestV.Value, ret.Value);
                    if (bestV.Value != val)
                        bestV = ret;
                    alfa = Math.Max(alfa, bestV.Value);
                    if (beta <= alfa)
                    {
                        break;
                    }
                }
                return bestV;

            }
            else
            {
                bestV.Value = int.MaxValue;
                moves = c.GetListaMogucihPoteza();
                foreach (Potez m in moves)
                {
                    ret = AlfaBeta(m.NarednoStanje, alfa, beta, depth - 1, true);
                    int val = bestV.Value;
                    bestV.Value = Math.Min(bestV.Value, ret.Value);
                    if (bestV.Value != val)
                        bestV = ret;
                    beta = Math.Min(beta, bestV.Value);
                    if (beta <= alfa)
                    {
                        break;
                    }
                }
                return bestV;
            }
        }
        */

        public static Potez AlfaBeta(Context c, int alfa, int beta, int depth, bool maximizing)
        {
            Potez bestV = new Potez();
            Potez ret = new Potez();
            List<Potez> moves = new List<Potez>();

            moves = c.GetListaMogucihPoteza();
            if (c.TrenutnoStanje.DoKraja() == 0 || depth == 0)
            {
                c.Value = c.Evaluate(c.NaPotezu);
                return new Potez()
                {
                    Value = c.Value
                };
            }
            if (maximizing)
            {
                bestV.Value = int.MinValue;
                moves = c.GetListaMogucihPoteza();
                foreach (Potez m in moves)
                {
                    ret = AlfaBeta(m.NarednoStanje, alfa, beta, depth - 1, false);
                    _potezi.Add(ret);
                    int val = System.Math.Max(ret.Value, bestV.Value);
                    if (val >= ret.Value)
                    {
                        bestV = m;
                        bestV.Value = val;
                    }
                    alfa = Math.Max(alfa, bestV.Value);
                    if (beta <= alfa)
                    {
                        break;
                    }
                }
                
                return bestV;

            }
            else
            {
                bestV.Value = int.MaxValue;
                moves = c.GetListaMogucihPoteza();
                foreach (Potez m in moves)
                {
                    ret = AlfaBeta(m.NarednoStanje, alfa, beta, depth - 1, true);
                    _potezi.Add(ret);
                    int val = Math.Min(ret.Value, bestV.Value);
                    if (val <= ret.Value)
                    {
                        bestV = m;
                        bestV.Value = val;
                    }
                    beta = Math.Min(beta, bestV.Value);
                    if (beta <= alfa)
                    {
                        break;
                    }
                }
               
                return bestV;
            }
        }
    }
    }



