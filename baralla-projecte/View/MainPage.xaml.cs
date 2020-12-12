using baralla_projecte;
using baralla_projecte.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace baralla_projecte
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        ObservableCollection<Carta> baralla = new ObservableCollection<Carta>();
        
        const int qtatPals = 4;
        const int qtatNumeros = 13;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            generarBaralla();
            barrellarBaralla();

            ObservableCollection<Carta> maCartes = new ObservableCollection<Carta>();
            cartesEnMa(maCartes, 5);
            uiMa.Cartes = maCartes;

        }

        private void cartesEnMa(ObservableCollection<Carta> maCartes, int qtatCarnesEnMa)
        {
            for (int i = 0; i < qtatCarnesEnMa; i++)
            {
                maCartes.Add(baralla[i]);
            }
        }

        private void barrellarBaralla()
        {
            
        }

        private void generarBaralla()
        {
            for (int p = 0; p < qtatPals; p++)
            {
                for (int n = 0; n < qtatNumeros; n++)
                {
                    Carta carta = new Carta((EnumNumeracio)n, (EnumPal)p, false);
                    baralla.Add(carta);
                }
            }
        }
    }
}
