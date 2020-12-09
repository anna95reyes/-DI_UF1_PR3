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

        public Carta(EnumNumeracio numero, EnumPal pal, int[,] distribucio, BitmapImage imatge, bool estaGirada)
        {
            Numero = numero;
            Pal = pal;
            Distribucio = distribucio;
            Imatge = imatge;
            BackFace = new BitmapImage(new Uri("ms-appx:///Assets/imatges/backFace.png"));
            EstaGirada = estaGirada;
        }

        public Carta(EnumNumeracio numero, EnumPal pal, int[,] distribucio, bool estaGirada)
        {
            Numero = numero;
            Pal = pal;
            Distribucio = distribucio;
            BackFace = new BitmapImage(new Uri("ms-appx:///Assets/imatges/backFace.png"));
            EstaGirada = estaGirada;
        }

        public EnumNumeracio Numero { get => numero; set => numero = value; }
        public EnumPal Pal { get => pal; set => pal = value; }
        public char Caracter { get => caracter; set => caracter = value; }
        public int[,] Distribucio { get => distribucio; set => distribucio = value; }
        public BitmapImage Imatge { get => imatge; set => imatge = value; }
        public BitmapImage BackFace { get => backFace; set => backFace = value; }
        public bool EstaGirada { get => estaGirada; set => estaGirada = value; }
    }
}