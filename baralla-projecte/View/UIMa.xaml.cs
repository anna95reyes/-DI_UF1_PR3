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

        ObservableCollection<UICarta> llistaUiCartesEnMa = new ObservableCollection<UICarta>();
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
            
            for (int i = 0; i < Cartes.Count; i++)
            {
                UICarta nouUiCarta = new UICarta();
                nouUiCarta.Carta = Cartes[i];
                llistaUiCartesEnMa.Add(nouUiCarta);
                grdUiCarta.Children.Add(nouUiCarta);
            }

            for (int i = 0; i < llistaUiCartesEnMa.Count; i++)
            {
                CompositeTransform transform = new CompositeTransform();
                transform.CenterX = i;
                transform.CenterY = i;
                transform.Rotation = 12 * i;
                transform.TranslateX = 10 * i;
                transform.TranslateY = 10 * i;
                llistaUiCartesEnMa[i].RenderTransform = transform;
            }
        }
    }
}
