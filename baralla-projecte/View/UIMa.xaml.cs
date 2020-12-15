using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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

        //ObservableCollection<UICarta> llistaUiCartesEnMa = new ObservableCollection<UICarta>();
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
            grdUiCarta.Children.Clear();
            
            for (int i = 0; i < Cartes.Count; i++)
            {
                UICarta nouUiCarta = new UICarta();
                nouUiCarta.Carta = Cartes[i];
                grdUiCarta.Children.Add(nouUiCarta);
            }

            for (int i = 0; i < grdUiCarta.Children.Count; i++)
            {
                CompositeTransform uiTransform = new CompositeTransform();
                uiTransform.CenterX = ((UICarta)grdUiCarta.Children[grdUiCarta.Children.Count / 2]).Width*25/100;
                uiTransform.CenterY = ((UICarta)grdUiCarta.Children[grdUiCarta.Children.Count / 2]).Height;
                uiTransform.Rotation = 12 * (i + 1);
                uiTransform.TranslateX = 1 * (i + 1);
                uiTransform.TranslateY = 1 * (i + 1);
                grdUiCarta.Children[i].RenderTransform = uiTransform;
            }
            
            colocacioSegonsNumCartes();
            
        }

        private void colocacioSegonsNumCartes()
        {
            int numCartes = grdUiCarta.Children.Count;

            CompositeTransform grdTransform = new CompositeTransform();
            grdTransform.CenterX = grdUiCarta.Width / 2;
            grdTransform.CenterY = grdUiCarta.Height;

            switch (numCartes)
            {
                case 1:
                    grdTransform.Rotation = -12;
                    grdTransform.TranslateX = -36;
                    grdTransform.TranslateY = 90;
                    break;
                case 2:
                    grdTransform.Rotation = -20;
                    grdTransform.TranslateX = -90;
                    grdTransform.TranslateY = 199;
                    break;
                case 3:
                    grdTransform.Rotation = -28;
                    grdTransform.TranslateX = -128;
                    grdTransform.TranslateY = 315;
                    break;
                case 4:
                    grdTransform.Rotation = -36;
                    grdTransform.TranslateX = -151;
                    grdTransform.TranslateY = 437;
                    break;
                case 5:
                    grdTransform.Rotation = -44;
                    grdTransform.TranslateX = -156;
                    grdTransform.TranslateY = 559;
                    break;
                case 6:
                    grdTransform.Rotation = -52;
                    grdTransform.TranslateX = -145;
                    grdTransform.TranslateY = 680;
                    break;
                case 7:
                    grdTransform.Rotation = -60;
                    grdTransform.TranslateX = -116;
                    grdTransform.TranslateY = 801;
                    break;
                case 8:
                    grdTransform.Rotation = -68;
                    grdTransform.TranslateX = -70;
                    grdTransform.TranslateY = 915;
                    break;
                case 9:
                    grdTransform.Rotation = -76;
                    grdTransform.TranslateX = -10;
                    grdTransform.TranslateY = 1022;
                    break;
                case 10:
                    grdTransform.Rotation = -84;
                    grdTransform.TranslateX = 66;
                    grdTransform.TranslateY = 1120;
                    break;
                case 11:
                    grdTransform.Rotation = -92;
                    grdTransform.TranslateX = 150;
                    grdTransform.TranslateY = 1207;
                    break;
                case 12:
                    grdTransform.Rotation = -100;
                    grdTransform.TranslateX = 247;
                    grdTransform.TranslateY = 1280;
                    break;
            }

            grdUiCarta.RenderTransform = grdTransform;
        }
    }
}
