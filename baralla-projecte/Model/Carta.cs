using baralla_projecte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace baralla_projecte
{
    public class Carta
    {
        private EnumNumeracio numero;
        private EnumPal pal;
        //private char caracter; // Faig servir el Description de cada enueracio
        private int[,] distribucio;
        private Boolean estaGirada;
        private BitmapImage imatge;
        private BitmapImage backFace;

        public Carta(EnumNumeracio numero, EnumPal pal, bool estaGirada)
        {
            Numero = numero;
            Pal = pal;
            Distribucio = distribucioSegonsNumero();
            Imatge = getImatge();
            BackFace = new BitmapImage(new Uri("ms-appx:///Assets/imatges/backFace.png"));
            EstaGirada = estaGirada;
        }

        //Aquesta funcio retorna la imatge corresponent al Pal si el Numero es J, Q o K, si no retorna null
        private BitmapImage getImatge()
        {
            BitmapImage bitmapImage = null;

            if (Numero == EnumNumeracio.J && Pal == EnumPal.COR)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/H_J.png"));
            } 
            else if (Numero == EnumNumeracio.Q && Pal == EnumPal.COR)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/H_Q.png"));
            }
            else if (Numero == EnumNumeracio.K && Pal == EnumPal.COR)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/H_K.png"));
            }
            else if (Numero == EnumNumeracio.J && Pal == EnumPal.DIAMANT)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/D_J.png"));
            }
            else if (Numero == EnumNumeracio.Q && Pal == EnumPal.DIAMANT)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/D_Q.png"));
            }
            else if (Numero == EnumNumeracio.K && Pal == EnumPal.DIAMANT)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/D_K.png"));
            }
            else if (Numero == EnumNumeracio.J && Pal == EnumPal.PICA)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/S_J.png"));
            }
            else if (Numero == EnumNumeracio.Q && Pal == EnumPal.PICA)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/S_Q.png"));
            }
            else if (Numero == EnumNumeracio.K && Pal == EnumPal.PICA)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/S_K.png"));
            }
            else if (Numero == EnumNumeracio.J && Pal == EnumPal.TREBOL)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/C_J.png"));
            }
            else if (Numero == EnumNumeracio.Q && Pal == EnumPal.TREBOL)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/C_Q.png"));
            }
            else if (Numero == EnumNumeracio.K && Pal == EnumPal.TREBOL)
            {
                bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/imatges/C_K.png"));
            }

            return bitmapImage;
        }

        //Aquesta funcio retorna la distribuccio dels Pal respecte al Numero si no es J, Q o K, si no retorna null
        private int[,] distribucioSegonsNumero()
        {
            int[,] matriu = new int[12,3];

            if (Numero != EnumNumeracio.J && Numero != EnumNumeracio.Q && Numero != EnumNumeracio.K)
            {
                if (Numero == EnumNumeracio.A)
                {
                    matriu[5,1] = 1;
                }
                else if (Numero == EnumNumeracio.N2)
                {
                    matriu[0,1] = 1;
                    matriu[10,1] = 2;
                }
                else if (Numero == EnumNumeracio.N3)
                {
                    matriu[0, 1] = 1;
                    matriu[5, 1] = 1;
                    matriu[10, 1] = 2;
                }
                else if (Numero == EnumNumeracio.N4)
                {
                    matriu[0, 0] = 1;
                    matriu[0, 2] = 1;
                    matriu[10, 0] = 2;
                    matriu[10, 2] = 2;
                }
                else if (Numero == EnumNumeracio.N5)
                {
                    matriu[0, 0] = 1;
                    matriu[0, 2] = 1;
                    matriu[5, 1] = 1;
                    matriu[10, 0] = 2;
                    matriu[10, 2] = 2;
                }
                else if (Numero == EnumNumeracio.N6)
                {
                    matriu[0, 0] = 1;
                    matriu[0, 2] = 1;
                    matriu[5, 0] = 1;
                    matriu[5, 2] = 1;
                    matriu[10, 0] = 2;
                    matriu[10, 2] = 2;
                }
                else if (Numero == EnumNumeracio.N7)
                {
                    matriu[0, 0] = 1;
                    matriu[0, 2] = 1;
                    matriu[3, 1] = 1;
                    matriu[5, 0] = 1;
                    matriu[5, 2] = 1;
                    matriu[10, 0] = 2;
                    matriu[10, 2] = 2;
                }
                else if (Numero == EnumNumeracio.N8)
                {
                    matriu[0, 0] = 1;
                    matriu[0, 2] = 1;
                    matriu[3, 1] = 1;
                    matriu[5, 0] = 1;
                    matriu[5, 2] = 1;
                    matriu[8, 1] = 2;
                    matriu[10, 0] = 2;
                    matriu[10, 2] = 2;
                }
                else if (Numero == EnumNumeracio.N9)
                {
                    matriu[0, 0] = 1;
                    matriu[0, 2] = 1;
                    matriu[3, 0] = 1;
                    matriu[3, 2] = 1;
                    matriu[5, 1] = 1;
                    matriu[7, 0] = 2;
                    matriu[7, 2] = 2;
                    matriu[10, 0] = 2;
                    matriu[10, 2] = 2;
                }
                else if (Numero == EnumNumeracio.N10)
                {
                    matriu[0, 0] = 1;
                    matriu[0, 2] = 1;
                    matriu[2, 1] = 1;
                    matriu[4, 0] = 1;
                    matriu[4, 2] = 1;
                    matriu[7, 0] = 2;
                    matriu[7, 2] = 2;
                    matriu[8, 1] = 2;
                    matriu[10, 0] = 2;
                    matriu[10, 2] = 2;
                }

                return matriu;
            }
                

            return null;
        }

        public EnumNumeracio Numero { get => numero; set => numero = value; }
        public EnumPal Pal { get => pal; set => pal = value; }
        //public char Caracter { get => caracter; set => caracter = value; }
        public int[,] Distribucio { get => distribucio; set => distribucio = value; }
        public BitmapImage Imatge { get => imatge; set => imatge = value; }
        public BitmapImage BackFace { get => backFace; set => backFace = value; }
        public bool EstaGirada { get => estaGirada; set => estaGirada = value; }
    }
}