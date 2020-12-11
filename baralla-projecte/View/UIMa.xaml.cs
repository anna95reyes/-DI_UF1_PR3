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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace baralla_projecte.View
{
    public sealed partial class UIMa : UserControl
    {
        public UIMa()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Carta> Cartes
        {
            get { return (ObservableCollection<Carta>)GetValue(CartesProperty); }
            set { SetValue(CartesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cartes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CartesProperty =
            DependencyProperty.Register("Cartes", typeof(ObservableCollection<Carta>), typeof(UIMa), new PropertyMetadata(null,
               CartesChangedCallbackStatic));

        private static void CartesChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIMa c = (UIMa)d;
            c.CartesChangedCallback(e);
        }

        private void CartesChangedCallback(DependencyPropertyChangedEventArgs e)
        {
            //uiCarta.Carta = new Carta(EnumNumeracio.J, EnumPal.TREBOL, false);
            //uiCarta.BackFace = uiCarta.Carta.EstaGirada;

            //for (int i = 0; i < Cartes.Count; i++)
            //{
            uiCarta1.Carta = Cartes[0];
            uiCarta2.Carta = Cartes[1];
            uiCarta3.Carta = Cartes[2];
            uiCarta4.Carta = Cartes[3];
            uiCarta5.Carta = Cartes[4];

            for (int i = 0; i < Cartes.Count; i++) {
                    CompositeTransform transform = new CompositeTransform();
                transform.CenterX = i;
                transform.CenterY = i;
                transform.Rotation = 10 * i;
                transform.TranslateX = 10 * i;
                transform.TranslateY = 10 * i;
                if (i == 0)
                    uiCarta1.RenderTransform = transform;
                if (i == 1)
                    uiCarta2.RenderTransform = transform;
                if (i == 2)
                    uiCarta3.RenderTransform = transform;
                if (i == 3)
                    uiCarta4.RenderTransform = transform;
                if (i == 4)
                    uiCarta5.RenderTransform = transform;
            }

            //}
        }
    }
}
