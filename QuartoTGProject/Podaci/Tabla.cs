using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuartoTGProject;
using System.Windows.Forms;

namespace QuartoTGProject.Podaci
{
    public class Tabla : Form,ICloneable
    {
        public static string t = "";
        public Form1 test { get; set; }
        public Figura[][] _mat;
        
        public int pobedio = 0;
        public Tabla()
        {
            _mat = new Figura[4][];
            for (int i = 0; i < 4; i++)
            {
                _mat[i] = new Figura[4];
            }
        }

        public Tabla(Tabla T)
        {
            _mat = new Figura[4][];
            for (int i = 0; i < 4; i++)
            {

                _mat[i] = new Figura[4];
            }

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    _mat[i][j] = new Figura();
            /*  for (int i = 0; i < 4; i++)
                   for (int j = 0; j < 4; j++)
                       _mat[i][j] =  T._mat[i][j]; */
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    _mat[i][j] = new Figura(T._mat[i][j]);

        }
        public Figura Polje(int x, int y)
        {
            if (x < 0 || x > _mat.Length)
                return null;
            if (y < 0 || y > _mat.Length)
                return null;
            if (_mat == null)
                return null;
            return _mat[x][y];
        }

        public bool Potez(int igrac, int x, int y, out string info)
        {
            if (_mat[x][y].Popunjeno != 0)
            {
                info = "NEVALIDAN POTEZ!\nPolje je zauzeto!";
                return false;
            }
            info = null;
            _mat[x][y].Popunjeno = igrac;


          
                    return true;


        }
        
         //-------------->>>>>>>>Provera prebacena u formu<<<<<<-------------
        //public bool DaLiJeKraj()
        //{
        //    int c, cf, h, hf, s, sf, t, tf;
        //    c = cf = h = hf = s = sf = t = tf = 0;
        //    //glavna dijagonala
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (_mat[i][i].Popunjeno != 0)
        //        {
        //            if (_mat[i][i].Color)
        //                c++;
        //            else if (!_mat[i][i].Color)
        //                cf++;
        //            if (_mat[i][i].Heigth)
        //                h++;
        //            else if (!_mat[i][i].Heigth)
        //                hf++;
        //            if (_mat[i][i].Shape)
        //                s++;
        //            else if (!_mat[i][i].Shape)
        //                sf++;
        //            if (_mat[i][i].Top)
        //                t++;
        //            else if (!_mat[i][i].Top)
        //                tf++;
        //            if (c == 4 || cf == 4 || h == 4 || hf == 4 || s == 4 || sf == 4
        //                || t == 4 || tf == 4)
        //                return true;
        //        }
        //    }
        //    //sporedna dijagonala
        //    c = cf = h = hf = s = sf = t = tf = 0;
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (_mat[i][3 - i].Popunjeno != 0)
        //        {
        //            if (_mat[i][3 - i].Color)
        //                c++;
        //            else if (!_mat[i][3 - i].Color)
        //                cf++;
        //            if (_mat[i][3 - i].Heigth)
        //                h++;
        //            else if (!_mat[i][3 - i].Heigth)
        //                hf++;
        //            if (_mat[i][3 - i].Shape)
        //                s++;
        //            else if (!_mat[i][3 - i].Shape)
        //                sf++;
        //            if (_mat[i][3 - i].Top)
        //                t++;
        //            else if (!_mat[i][3 - i].Top)
        //                tf++;
        //            if (c == 4 || cf == 4 || h == 4 || hf == 4 || s == 4 || sf == 4
        //                || t == 4 || tf == 4)
        //                return true;
        //        }
        //    }
        //    // redovi
        //    for (int i = 0; i < 4; i++)
        //    {
        //        c = cf = h = hf = s = sf = t = tf = 0;
        //        for (int j = 0; j < 4; j++)
        //        {
        //            if (_mat[i][j].Popunjeno != 0)
        //            {
        //                if (_mat[i][j].Color)
        //                    c++;
        //                else if (!_mat[i][j].Color)
        //                    cf++;
        //                if (_mat[i][j].Heigth)
        //                    h++;
        //                else if (!_mat[i][j].Heigth)
        //                    hf++;
        //                if (_mat[i][j].Shape)
        //                    s++;
        //                else if (!_mat[i][j].Shape)
        //                    sf++;
        //                if (_mat[i][j].Top)
        //                    t++;
        //                else if (!_mat[i][j].Top)
        //                    tf++;
        //                if (c == 4 || cf == 4 || h == 4 || hf == 4 || s == 4 || sf == 4
        //                    || t == 4 || tf == 4)
        //                    return true;
        //            }
        //        }
        //    }
        //    //kolone
        //    for (int j = 0; j < 4; j++)
        //    {
        //        c = cf = h = hf = s = sf = t = tf = 0;
        //        for (int i = 0; i < 4; i++)
        //        {
        //            if (_mat[i][j].Popunjeno != 0)
        //            {
        //                if (_mat[i][j].Color)
        //                    c++;
        //                else if (!_mat[i][j].Color)
        //                    cf++;
        //                if (_mat[i][j].Heigth)
        //                    h++;
        //                else if (!_mat[i][j].Heigth)
        //                    hf++;
        //                if (_mat[i][j].Shape)
        //                    s++;
        //                else if (!_mat[i][j].Shape)
        //                    sf++;
        //                if (_mat[i][j].Top)
        //                    t++;
        //                else if (!_mat[i][j].Top)
        //                    tf++;
        //                if (c == 4 || cf == 4 || h == 4 || hf == 4 || s == 4 || sf == 4
        //                    || t == 4 || tf == 4)
        //                    return true;
        //            }
        //        }
        //    }
        //    return false;
        //}



        public List<Potez> GetListaPoteza() //Vraca listu neodigranih poteza
        {
            List<Potez> potezi = new List<Potez>();
            if (Form1.DaLiJeKraj()/*DaLiJeKraj()*/)
                return potezi;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (_mat[i][j].Popunjeno == 0)
                        potezi.Add(new Potez()
                        {
                            x = i,
                            y = j
                        });
            return potezi;
        }

        internal int DoKraja()
        {
            int c = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (_mat[i][j].Popunjeno == 0) c++;
            return c;
        }

        public int Evaluacija(int xx)
        {
            // int pobedio;
            if (Form1.DaLiJeKraj()/*DaLiJeKraj(/*out pobedio)*/)
            {
                if (pobedio == 1)
                    return -100;
                if (pobedio == 2)
                    return 100;
                if (pobedio == 3)
                    return 0;
            }
            return proveriTablu(xx);
        }

        //uklonio sam nepotrebne provere uslova i uprostio kod
        //ubacio sam brojace u petlje gde treba da budu
        public int proveriTablu(int x)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    t += _mat[i][j].Popunjeno.ToString() + " ";
                }
                t += "\n";
            }
            t += "\n";
                int visina, vrh, boja, oblik;
            visina = vrh = boja = oblik = 0;

            for (int i = 0; i < 4; i++)
            {
                if (_mat[i][i].Popunjeno == 0)
                    continue;
                if (_mat[i][i].Top)
                    vrh++;
                else if (_mat[i][i].Popunjeno !=0)
                    vrh--;

                if (_mat[i][i].Shape)
                    oblik++;
                else if (_mat[i][i].Popunjeno != 0)
                    oblik--;

                if (_mat[i][i].Color)
                    boja++;
                else if  (_mat[i][i].Popunjeno != 0)
                    boja--;

                if (_mat[i][i].Heigth)
                    visina++;
                else if (_mat[i][i].Popunjeno != 0)
                    visina--;
            }
            if ((vrh % 4 == 0 && vrh != 0) || (oblik % 4 == 0 && oblik != 0) || (boja % 4 == 0 && boja != 0) || (visina % 4 == 0 && visina != 0)) //promeni ako ne radi)
                if (x == 2)
                {
                    pobedio = 2;
                    return 2000;
                }
                else if (x == 1)
                {
                    pobedio = 1;
                    return -2000;
                }



            if ((vrh % 3 == 0 && vrh != 0) || (oblik % 3 == 0 && oblik != 0) || (boja % 3 == 0 && boja != 0) || (visina % 3 == 0 && visina != 0)) //promeni ako ne radi
                if (x == 2)
                    return -80;
                else if (x == 1)
                    return 80;
            if ((vrh % 2 == 0 && vrh != 0) || (oblik % 2 == 0 && oblik != 0) || (boja % 2 == 0 && boja != 0) || (visina % 2 == 0 && visina != 0))
                if (x == 2)
                    return -50;
                else if (x == 1)
                    return 50;



            for (int i = 0; i < 4; i++)
            {
                visina = vrh = boja = oblik = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (_mat[i][j].Popunjeno == 0)
                        continue;
                    if (_mat[i][j].Top)
                        vrh++;
                    else if (_mat[i][j].Popunjeno !=0)
                        vrh--;

                    if (_mat[i][j].Shape)
                        oblik++;
                    else if (_mat[i][j].Popunjeno != 0)
                        oblik--;
                    if (_mat[i][j].Color)
                        boja++;
                    else if (_mat[i][j].Popunjeno != 0)
                        boja--;

                    if (_mat[i][j].Heigth)
                        visina++;
                    else if (_mat[i][j].Popunjeno != 0)
                        visina--;
                }
                if ((vrh % 4 == 0 && vrh != 0) || (oblik % 4 == 0 && oblik != 0) || (boja % 4 == 0 && boja != 0) || (visina % 4 == 0 && visina != 0)) //promeni ako ne radi)
                {
                    if (x == 2)
                    {
                        pobedio = 2;
                        return 2000;

                    }

                    else if (x == 1)
                    {
                        pobedio = 2;
                        return -2000;
                           
                    }
                }
                else
                if ((vrh % 3 == 0 && vrh != 0) || (oblik % 3 == 0 && oblik != 0) || (boja % 3 == 0 && boja != 0) || (visina % 3 == 0 && visina != 0)) //promeni ako ne radi
                    if (x == 2)
                        return -80;
                    else if (x == 1)
                        return 80;

                if ((vrh % 2 == 0 && vrh != 0) || (oblik % 2 == 0 && oblik != 0) || (boja % 2 == 0 && boja != 0) || (visina % 2 == 0 && visina != 0))
                {
                    if (x == 2)
                        return -20;
                    else if (x == 1)
                        return 20;
                }
            }


            for (int i = 0; i < 4; i++)
            {
                visina = vrh = boja = oblik = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (_mat[j][i].Popunjeno == 0)
                        continue;
                    if (_mat[j][i].Top)
                        vrh++;
                    else if (_mat[j][i].Popunjeno !=0)
                        vrh--;

                    if (_mat[j][i].Shape)
                        oblik++;
                    else if (_mat[j][i].Popunjeno != 0)
                        oblik--;

                    if (_mat[j][i].Color)
                        boja++;
                    else if (_mat[j][i].Popunjeno != 0)
                        boja--;

                    if (_mat[j][i].Heigth)
                        visina++;
                    else if (_mat[j][i].Popunjeno != 0)
                        visina--;

                }
                if ((vrh % 4 == 0 && vrh != 0) || (oblik % 4 == 0 && oblik != 0) || (boja % 4 == 0 && boja != 0) || (visina % 4 == 0 && visina != 0)) //promeni ako ne radi)
                {
                    if (x == 2)
                    {
                        pobedio = 2;
                        return 2000;
                    }
                    else if (x == 1)
                    {
                        pobedio = 1;
                        return -2000;
                    }
                 }
                if ((vrh % 3 == 0 && vrh != 0) || (oblik % 3 == 0 && oblik != 0) || (boja % 3 == 0 && boja != 0) || (visina % 3 == 0 && visina != 0)) //promeni ako ne radi
                {
                    if (x == 2)
                        return -80;
                    else if (x == 1)
                        return 80;
                }

                if ((vrh % 2 == 0 && vrh != 0) || (oblik % 2 == 0 && oblik != 0) || (boja % 2 == 0 && boja != 0) || (visina % 2 == 0 && visina != 0))

                    if (x == 2)
                        return -50;
                    else if (x == 1)
                        return 50;


                visina = vrh = boja = oblik = 0;

            }

            for (int i = 0; i < 4; i++)
            {
                
                if (_mat[i][3 - i].Popunjeno == 0)
                    continue;
                if (_mat[i][3 - i].Top)
                    vrh++;
                else if (_mat[i][3 - i].Popunjeno != 0)
                    vrh--;

                if (_mat[i][3 - i].Shape)
                    oblik++;
                else if (_mat[i][3 - i].Popunjeno != 0)
                    oblik--;

                if (_mat[i][3 - i].Color == true)
                    boja++;
                else if (_mat[i][3 - i].Popunjeno != 0)
                    boja--;

                if (_mat[i][3 - i].Heigth)
                    visina++;
                else if (_mat[i][3 - i].Popunjeno != 0)

                    if (_mat[i][3 - i].Popunjeno != 0)
                    visina--;
            }
            if ((vrh % 4 == 0 && vrh != 0) || (oblik % 4 == 0 && oblik != 0) || (boja % 4 == 0 && boja != 0) || (visina % 4 == 0 && visina != 0)) //promeni ako ne radi)
            {
                if (x == 2)
                {
                    pobedio = 2;
                    return 2000;
                }
                else if (x == 1)
                {
                    pobedio = 1;
                    return -2000;
                }
            }
            if ((vrh % 3 == 0 && vrh != 0) || (oblik % 3 == 0 && oblik != 0) || (boja % 3 == 0 && boja != 0) || (visina % 3 == 0 && visina != 0)) //promeni ako ne radi
                if (x == 2)
                    return -80;
                else if (x == 1)
                    return 80;

            if ((vrh % 2 == 0 && vrh != 0) || (oblik % 2 == 0 && oblik != 0) || (boja % 2 == 0 && boja != 0) || (visina % 2 == 0 && visina != 0))
            {
                if (x == 2)
                    return -50;
                else if (x == 1)
                    return 50;
            }
            

            
            return 0;
        }

        public object Clone()
        {
            return Dulpicate();
        }

        public Tabla Dulpicate()
        {
            return new Tabla(this);
        }
    }
}
