using baralla_projecte;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //S'ha de fer una baralla, que son 52 cartes
        //removerange

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Carta> cartes = new ObservableCollection<Carta>();

            Carta carta1 = new Carta(EnumNumeracio.J, EnumPal.TREBOL, false);
            Carta carta2 = new Carta(EnumNumeracio.N6, EnumPal.PICA, false);
            Carta carta3 = new Carta(EnumNumeracio.N9, EnumPal.COR, false);
            Carta carta4 = new Carta(EnumNumeracio.N3, EnumPal.DIAMANT, false);
            Carta carta5 = new Carta(EnumNumeracio.K, EnumPal.PICA, false);

            cartes.Add(carta1);
            cartes.Add(carta2);
            cartes.Add(carta3);
            cartes.Add(carta4);
            cartes.Add(carta5);

            uiMa.Cartes = cartes;

            
        }
    }
}
