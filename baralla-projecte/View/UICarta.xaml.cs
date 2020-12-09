using baralla_projecte;
using baralla_projecte.Model;
using System;
using System.Collections.Generic;
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
    public sealed partial class UICarta : UserControl
    {
        public UICarta()
        {
            this.InitializeComponent();
        }


        public Carta Carta
        {
            get { return (Carta)GetValue(CartaProperty); }
            set { SetValue(CartaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Carta.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CartaProperty =
            DependencyProperty.Register("Carta", typeof(Carta), typeof(UICarta), new PropertyMetadata(null, 
                CartaChangedCallbackStatic));

        private static void CartaChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UICarta c = (UICarta)d;
            c.CartaChangedCallback(e);
        }

        private void CartaChangedCallback(DependencyPropertyChangedEventArgs e)
        {
            SolidColorBrush color;
            if (Carta.Pal == EnumPal.COR || Carta.Pal == EnumPal.DIAMANT)
            {
                color = new SolidColorBrush(Colors.Red);
            } 
            else
            {
                color = new SolidColorBrush(Colors.Black);
            }
            txbNumero.Foreground = color;
            txbPal.Foreground = color;
            txbNumero.Text = EnumDescriptionConverter.getDesc(Carta.Numero);
            txbPal.Text = EnumDescriptionConverter.getDesc(Carta.Pal);
        }


        public Boolean BackFace
        {
            get { return (Boolean)GetValue(BackFaceProperty); }
            set { SetValue(BackFaceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackFace.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackFaceProperty =
            DependencyProperty.Register("BackFace", typeof(Boolean), typeof(UICarta), new PropertyMetadata(true));
    }
}
