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
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
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

        public Boolean BackFace
        {
            get { return (Boolean)GetValue(BackFaceProperty); }
            set { SetValue(BackFaceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackFace.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackFaceProperty =
            DependencyProperty.Register("BackFace", typeof(Boolean), typeof(UICarta), new PropertyMetadata(false, 
                CartaChangedCallbackStatic));

        private static void CartaChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UICarta c = (UICarta)d;
            c.CartaChangedCallback(e);
        }

        private void CartaChangedCallback(DependencyPropertyChangedEventArgs e)
        {
            if (BackFace)
            {
                for (int i = 0; i < rvpCarta.Children.Count; i++)
                {
                    rvpCarta.Children.RemoveAt(i);
                }
                Image imgBackFace = new Image();
                imgBackFace.Source = Carta.BackFace;
                rvpCarta.Children.Add(imgBackFace);               
            }
            else
            {
              dibujarCarta();  
            }
        }

        SolidColorBrush color;

        private void dibujarCarta()
        {
            
            if (Carta.Pal == EnumPal.COR || Carta.Pal == EnumPal.DIAMANT)
            {
                color = new SolidColorBrush(Colors.Red);
            }
            else
            {
                color = new SolidColorBrush(Colors.Black);
            }

            grdPalAdalt();
            grdPalsCarta();
            grdPalAbaix();
        }

        private void grdPalAdalt()
        {
            /*
             <Grid RelativePanel.AlignLeftWithPanel="True" Margin="20 10 0 0">
                <TextBlock x:Name="txbNumero" Text="{Binding Converter={StaticResource EnumDescriptionConverter}}" 
                           HorizontalAlignment="Center" FontSize="50" FontWeight="Black" FontFamily="Times New Roman"></TextBlock>
                <TextBlock x:Name="txbPal" Text="{Binding Converter={StaticResource EnumDescriptionConverter}}" 
                           FontSize="70" HorizontalAlignment="Center" Margin="0,40,0,0"/>
            </Grid>
             */

            Grid grdPalDret = new Grid();
            grdPalDret.Margin = new Thickness(20, 10, 0, 0);

            grdPalDret.Children.Add(getTxbNumero());
            grdPalDret.Children.Add(getTxbPal());

            RelativePanel.SetAlignLeftWithPanel(grdPalDret, true);

            rvpCarta.Children.Add(grdPalDret);
        }

        private void grdPalsCarta()
        {
            /*
             <Grid RelativePanel.AlignHorizontalCenterWithPanel="True" RelativePanel.AlignVerticalCenterWithPanel="True">
                <Image Source="/Assets/imatges/C_J.png" Height="520" VerticalAlignment="Center" HorizontalAlignment="Center"/>

                --><!--<TextBlock Text="♥" FontSize="160"></TextBlock>--><!--
            </Grid>
             */
            Grid grdPalsCarta = new Grid();

            if (Carta.Numero == EnumNumeracio.J || Carta.Numero == EnumNumeracio.Q || Carta.Numero == EnumNumeracio.K)
            {
                Image imgReis = new Image();
                imgReis.Source = Carta.Imatge;
                imgReis.Height = 520;
                imgReis.VerticalAlignment = VerticalAlignment.Center;
                imgReis.HorizontalAlignment = HorizontalAlignment.Center;

                grdPalsCarta.Children.Add(imgReis);
            }
            else
            {
                Grid grdPalCentre = distribucioCarta(Carta.Numero, Carta.Pal);
                grdPalsCarta.Children.Add(grdPalCentre);
            }

            RelativePanel.SetAlignHorizontalCenterWithPanel(grdPalsCarta, true);
            RelativePanel.SetAlignVerticalCenterWithPanel(grdPalsCarta, true);

            rvpCarta.Children.Add(grdPalsCarta);
        }

        private Grid distribucioCarta(EnumNumeracio numero, EnumPal pal)
        {
            Grid grdPals = new Grid();
            grdPals.Height = 520;
            grdPals.Width = 330;
            //grdPals.Background = new SolidColorBrush(Colors.Blue);

            int files = Carta.Distribucio.GetLength(0);
            int columnes = Carta.Distribucio.GetLength(1);

            /*
            <Grid>
                <Grid.RowDefinitions> //12
                    <RowDefinition Height="1*"></RowDefinition>
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions> //3
                    <ColumnDefinition Width="1*"></ColumnDefinition>
                </Grid.ColumnDefinitions>
            </Grid>
            */

            for (int i = 0; i < files; i++)
            {
                RowDefinition fila = new RowDefinition();
                fila.Height = new GridLength(2, GridUnitType.Star);
                grdPals.RowDefinitions.Add(fila);
            }

            for (int i = 0; i < columnes; i++)
            {
                ColumnDefinition columna = new ColumnDefinition();
                columna.Width = new GridLength(2, GridUnitType.Star);
                grdPals.ColumnDefinitions.Add(columna);
            }


            for (int y = 0; y < files; y++)
            {
                for (int x = 0; x < columnes; x++)
                {
                    if (Carta.Distribucio[y, x] == 1)
                    {
                        TextBlock txtPalsCentre = crearPals(pal);
                        Grid.SetColumn(txtPalsCentre, x);
                        Grid.SetRow(txtPalsCentre, y);
                        Grid.SetRowSpan(txtPalsCentre, 2);
                        grdPals.Children.Add(txtPalsCentre);
                    }
                    else if (Carta.Distribucio[y, x] == 2)
                    {
                        TextBlock txtPalsCentre = crearPals(pal);
                        Grid.SetColumn(txtPalsCentre, x);
                        Grid.SetRow(txtPalsCentre, y);
                        Grid.SetRowSpan(txtPalsCentre, 2);

                        CompositeTransform transformGrdPalsCentre = new CompositeTransform();
                        transformGrdPalsCentre.Rotation = 180;
                        transformGrdPalsCentre.TranslateX = 82;
                        transformGrdPalsCentre.TranslateY = 160;

                        txtPalsCentre.RenderTransform = transformGrdPalsCentre;
                        grdPals.Children.Add(txtPalsCentre);
                    }

                }
            }

            return grdPals;
        }

        private TextBlock crearPals(EnumPal pal)
        {
            TextBlock txtPalsCentre = new TextBlock();
            txtPalsCentre.FontSize = 120;
            txtPalsCentre.Foreground = color;
            txtPalsCentre.Text = EnumDescriptionConverter.getDesc(pal);
            txtPalsCentre.HorizontalAlignment = HorizontalAlignment.Center;
            txtPalsCentre.VerticalAlignment = VerticalAlignment.Center;
            return txtPalsCentre;
        }

        private void grdPalAbaix()
        {
            /*
              <Grid RelativePanel.AlignBottomWithPanel="True" RelativePanel.AlignRightWithPanel="True" 
                  Margin="20 10 0 0">
                <Grid.RenderTransform>
                    <CompositeTransform  Rotation="180" TranslateX="25" TranslateY="120"></CompositeTransform>
                </Grid.RenderTransform>
                <TextBlock x:Name="txbNumeroReves" Text="{Binding Converter={StaticResource EnumDescriptionConverter}}" 
                           HorizontalAlignment="Center" FontSize="50" 
                           FontWeight="Black" FontFamily="Times New Roman"></TextBlock>
                <TextBlock x:Name="txbPalReves" Text="{Binding Converter={StaticResource EnumDescriptionConverter}}" 
                           FontSize="70" HorizontalAlignment="Center" Margin="0,40,0,0"/>
            </Grid>
             */

            Grid grdPalGirat = new Grid();
            grdPalGirat.Margin = new Thickness(20, 10, 0, 0);

            CompositeTransform transformGrdPalGirat = new CompositeTransform();
            transformGrdPalGirat.Rotation = 180;
            transformGrdPalGirat.TranslateX = 25;
            transformGrdPalGirat.TranslateY = 120;

            grdPalGirat.RenderTransform = transformGrdPalGirat;

            grdPalGirat.Children.Add(getTxbNumero());
            grdPalGirat.Children.Add(getTxbPal());

            RelativePanel.SetAlignBottomWithPanel(grdPalGirat, true);
            RelativePanel.SetAlignRightWithPanel(grdPalGirat, true);

            rvpCarta.Children.Add(grdPalGirat);
        }

        private TextBlock getTxbNumero()
        {
            TextBlock txbNumero = new TextBlock();
            txbNumero.Text = EnumDescriptionConverter.getDesc(Carta.Numero);
            txbNumero.HorizontalAlignment = HorizontalAlignment.Center;
            txbNumero.FontWeight = FontWeights.Black;
            txbNumero.FontSize = 50;
            txbNumero.FontFamily = new FontFamily("Times New Roman");
            txbNumero.Foreground = color;

            return txbNumero;
        }

        private TextBlock getTxbPal()
        {
            TextBlock txbPal = new TextBlock();
            txbPal.Text = EnumDescriptionConverter.getDesc(Carta.Pal);
            txbPal.FontSize = 70;
            txbPal.HorizontalAlignment = HorizontalAlignment.Center;
            txbPal.Margin = new Thickness(0, 40, 0, 0);
            txbPal.Foreground = color;

            return txbPal;
        }
    }
}
