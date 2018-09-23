using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fully_Fuzzy_LPP
{
    // The Class that handles Generating the Tableaus
    class tableGrid
    {
        // Class properties
        public int off { get; set; }
        public StackPanel stack { get; set; }

        // The Class constructor
        public tableGrid(StackPanel _stack, int _off)
        {
            off = _off; stack = _stack;
        }

        // This draws the Grids( i.e Tables) in the Stackpanel
        public void draw1(float[,,] tab, string comm1, string comm2, int pos, string[] side)
        {

            // The Tableau in Grid form May be no need for the grid again
            Grid grd = new Grid();
            grd.HorizontalAlignment = HorizontalAlignment.Left;
            grd.Margin = new Thickness(10, off, 0, 0);
            grd.Height = 300; grd.Width = 1000;
            grd.Background = Brushes.WhiteSmoke;

            Rectangle rec = new Rectangle();
            rec.Height = 300; rec.Width = 1000;
            rec.Margin = new Thickness(0); rec.Stroke = Brushes.Black;

            // verticals
            Separator sep1 = new Separator();
            sep1.HorizontalAlignment = HorizontalAlignment.Left;
            sep1.VerticalAlignment = VerticalAlignment.Top;
            sep1.Margin = new Thickness(50, 60, 0, 0);
            sep1.RenderTransform = new RotateTransform(90);
            sep1.Background = Brushes.Black; sep1.Width = 240;

            Separator sep2 = new Separator();
            sep2.HorizontalAlignment = HorizontalAlignment.Left;
            sep2.VerticalAlignment = VerticalAlignment.Top;
            sep2.Margin = new Thickness(240, 60, 0, 0);
            sep2.RenderTransform = new RotateTransform(90);
            sep2.Background = Brushes.Black; sep2.Width = 240;

            Separator sep3 = new Separator();
            sep3.HorizontalAlignment = HorizontalAlignment.Left;
            sep3.VerticalAlignment = VerticalAlignment.Top;
            sep3.Margin = new Thickness(430, 60, 0, 0);
            sep3.RenderTransform = new RotateTransform(90);
            sep3.Background = Brushes.Black; sep3.Width = 240;

            Separator sep4 = new Separator();
            sep4.HorizontalAlignment = HorizontalAlignment.Left;
            sep4.VerticalAlignment = VerticalAlignment.Top;
            sep4.Margin = new Thickness(620, 60, 0, 0);
            sep4.RenderTransform = new RotateTransform(90);
            sep4.Background = Brushes.Black; sep4.Width = 240;

            Separator sep5 = new Separator();
            sep5.HorizontalAlignment = HorizontalAlignment.Left;
            sep5.VerticalAlignment = VerticalAlignment.Top;
            sep5.Margin = new Thickness(810, 60, 0, 0);
            sep5.RenderTransform = new RotateTransform(90);
            sep5.Background = Brushes.Black; sep5.Width = 240;

            Separator sep10 = new Separator();
            sep10.HorizontalAlignment = HorizontalAlignment.Left;
            sep10.VerticalAlignment = VerticalAlignment.Top;
            sep10.Margin = new Thickness(810, 110, 0, 0);
            sep10.RenderTransform = new RotateTransform(90);
            sep10.Background = Brushes.Black; sep10.Width = 240;

            //horizontals
            Separator sep6 = new Separator();
            sep6.RenderTransformOrigin = new Point(0.5, 0.5);
            sep6.Margin = new Thickness(0, 60, 0, 0);
            sep6.VerticalAlignment = VerticalAlignment.Top;
            sep6.RenderTransform = new RotateTransform(180);
            sep6.Background = Brushes.Black; sep6.Width = 1000;

            Separator sep7 = new Separator();
            sep7.RenderTransformOrigin = new Point(0.5, 0.5);
            sep7.Margin = new Thickness(0, 120, 0, 0);
            sep7.VerticalAlignment = VerticalAlignment.Top;
            sep7.RenderTransform = new RotateTransform(180);
            sep7.Background = Brushes.Black; sep7.Width = 1000;

            Separator sep8 = new Separator();
            sep8.RenderTransformOrigin = new Point(0.5, 0.5);
            sep8.Margin = new Thickness(0, 180, 0, 0);
            sep8.VerticalAlignment = VerticalAlignment.Top;
            sep8.RenderTransform = new RotateTransform(180);
            sep8.Background = Brushes.Black; sep8.Width = 1000;

            Separator sep9 = new Separator();
            sep9.RenderTransformOrigin = new Point(0.5, 0.5);
            sep9.Margin = new Thickness(0, 240, 0, 0);
            sep9.VerticalAlignment = VerticalAlignment.Top;
            sep9.RenderTransform = new RotateTransform(180);
            sep9.Background = Brushes.Black; sep9.Width = 1000;

            // Labels 25
            // row 1
            Label lb1 = new Label();
            lb1.Margin = new Thickness(20, 10, 0, 0);
            lb1.HorizontalAlignment = HorizontalAlignment.Left;
            lb1.VerticalAlignment = VerticalAlignment.Top;
            lb1.Content = comm1 + " - " + comm2;
            lb1.Foreground = Brushes.DarkSlateBlue; lb1.FontSize = 20;

            //row2
            Label lb2 = new Label();
            lb2.Margin = new Thickness(7, 70, 0, 0);
            lb2.HorizontalAlignment = HorizontalAlignment.Left;
            lb2.VerticalAlignment = VerticalAlignment.Top;
            lb2.Content = "BV";
            lb2.Foreground = Brushes.DarkSlateBlue; lb2.FontSize = 20;

            Label lb3 = new Label();
            lb3.Margin = new Thickness(60, 70, 0, 0);
            lb3.HorizontalAlignment = HorizontalAlignment.Left;
            lb3.VerticalAlignment = VerticalAlignment.Top;
            lb3.Content = "X1";
            lb3.Foreground = Brushes.DarkSlateBlue; lb3.FontSize = 20;

            Label lb4 = new Label();
            lb4.Margin = new Thickness(240, 70, 0, 0);
            lb4.HorizontalAlignment = HorizontalAlignment.Left;
            lb4.VerticalAlignment = VerticalAlignment.Top;
            lb4.Content = "X2";
            lb4.Foreground = Brushes.DarkSlateBlue; lb4.FontSize = 20;

            Label lb5 = new Label();
            lb5.Margin = new Thickness(430, 70, 0, 0);
            lb5.HorizontalAlignment = HorizontalAlignment.Left;
            lb5.VerticalAlignment = VerticalAlignment.Top;
            lb5.Content = "X3";
            lb5.Foreground = Brushes.DarkSlateBlue; lb5.FontSize = 20;

            Label lb6 = new Label();
            lb6.Margin = new Thickness(620, 70, 0, 0);
            lb6.HorizontalAlignment = HorizontalAlignment.Left;
            lb6.VerticalAlignment = VerticalAlignment.Top;
            lb6.Content = "X4";
            lb6.Foreground = Brushes.DarkSlateBlue; lb6.FontSize = 20;

            Label lb7 = new Label();
            lb7 .Margin = new Thickness(810, 70, 0, 0);
            lb7.HorizontalAlignment = HorizontalAlignment.Left;
            lb7.VerticalAlignment = VerticalAlignment.Top;
            lb7.Content = "RHS";
            lb7.Foreground = Brushes.DarkSlateBlue; lb7.FontSize = 20;
            
            //row3
            Label lb8 = new Label();
            lb8.Margin = new Thickness(7, 130, 0, 0);
            lb8.HorizontalAlignment = HorizontalAlignment.Left;
            lb8.VerticalAlignment = VerticalAlignment.Top;
            lb8.Content = side[0];
            lb8.Foreground = Brushes.DarkSlateBlue; lb8.FontSize = 16;

            Label lb9 = new Label();
            lb9.Margin = new Thickness(50, 130, 0, 0);
            lb9.HorizontalAlignment = HorizontalAlignment.Left;
            lb9.VerticalAlignment = VerticalAlignment.Top;
            //
            lb9.Content = tab[0, 0, 0] + "," + tab[0, 0, 1] + "," + tab[0, 0, 2] + "," + tab[0, 0, 3] + "|"  + tab[0, 0, 4];
            if (pos == 1) {
                lb9.Foreground = Brushes.Goldenrod;
            }
            else {
                lb9.Foreground = Brushes.DarkSlateBlue;
            }
            lb9.FontSize = 16;

            Label lb10 = new Label();
            lb10.Margin = new Thickness(240, 130, 0, 0);
            lb10.HorizontalAlignment = HorizontalAlignment.Left;
            lb10.VerticalAlignment = VerticalAlignment.Top;
            lb10.Content = tab[0, 1, 0] + "," + tab[0, 1, 1] + "," + tab[0, 1, 2] + "," + tab[0, 1, 3] + "|" + tab[0, 1, 4];
            if (pos == 2)
            {
                lb10.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb10.Foreground = Brushes.DarkSlateBlue;
            }
            lb10.FontSize = 16;

            Label lb11 = new Label();
            lb11.Margin = new Thickness(430, 130, 0, 0);
            lb11.HorizontalAlignment = HorizontalAlignment.Left;
            lb11.VerticalAlignment = VerticalAlignment.Top;
            lb11.Content = tab[0, 2, 0] + "," + tab[0, 2, 1] + "," + tab[0, 2, 2] + "," + tab[0, 2, 3] + "|" + tab[0, 2, 4];
            if (pos == 3)
            {
                lb11.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb11.Foreground = Brushes.DarkSlateBlue;
            }
            lb11.FontSize = 16;

            Label lb12 = new Label();
            lb12.Margin = new Thickness(620, 130, 0, 0);
            lb12.HorizontalAlignment = HorizontalAlignment.Left;
            lb12.VerticalAlignment = VerticalAlignment.Top;
            lb12.Content = tab[0, 3, 0] + "," + tab[0, 3, 1] + "," + tab[0, 3, 2] + "," + tab[0, 3, 3] + "|" + tab[0, 3, 4];
            if (pos == 4)
            {
                lb12.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb12.Foreground = Brushes.DarkSlateBlue;
            }
            lb12.FontSize = 16;

            Label lb13 = new Label();
            lb13.Margin = new Thickness(810, 130, 0, 0);
            lb13.HorizontalAlignment = HorizontalAlignment.Left;
            lb13.VerticalAlignment = VerticalAlignment.Top;
            lb13.Content = tab[0, 4, 0] + "," + tab[0, 4, 1] + "," + tab[0, 4, 2] + "," + tab[0, 4, 3] + "|" + tab[0, 4, 4];
            lb13.Foreground = Brushes.DarkSlateBlue; lb13.FontSize = 16;

            //row4
            Label lb14 = new Label();
            lb14.Margin = new Thickness(7, 190, 0, 0);
            lb14.HorizontalAlignment = HorizontalAlignment.Left;
            lb14.VerticalAlignment = VerticalAlignment.Top;
            lb14.Content = side[1];
            lb14.Foreground = Brushes.DarkSlateBlue; lb14.FontSize = 16;

            Label lb15 = new Label();
            lb15.Margin = new Thickness(50, 190, 0, 0);
            lb15.HorizontalAlignment = HorizontalAlignment.Left;
            lb15.VerticalAlignment = VerticalAlignment.Top;
            lb15.Content = tab[1, 0, 0] + "," + tab[1, 0, 1] + "," + tab[1, 0, 2] + "," + tab[1, 0, 3] + "|" + tab[1, 0, 4];
            if (pos == 5)
            {
                lb15.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb15.Foreground = Brushes.DarkSlateBlue;
            }
            lb15.FontSize = 16;

            Label lb16 = new Label();
            lb16.Margin = new Thickness(240, 190, 0, 0);
            lb16.HorizontalAlignment = HorizontalAlignment.Left;
            lb16.VerticalAlignment = VerticalAlignment.Top;
            lb16.Content = tab[1, 1, 0] + "," + tab[1, 1, 1] + "," + tab[1, 1, 2] + "," + tab[1, 1, 3] + "|" + tab[1, 1, 4];
            if (pos == 6)
            {
                lb16.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb16.Foreground = Brushes.DarkSlateBlue;
            }
            lb16.FontSize = 16;

            Label lb17 = new Label();
            lb17.Margin = new Thickness(430, 190, 0, 0);
            lb17.HorizontalAlignment = HorizontalAlignment.Left;
            lb17.VerticalAlignment = VerticalAlignment.Top;
            lb17.Content = tab[1, 2, 0] + "," + tab[1, 2, 1] + "," + tab[1, 2, 2] + "," + tab[1, 2, 3] + "|" + tab[1, 2, 4];
            if (pos == 7)
            {
                lb17.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb17.Foreground = Brushes.DarkSlateBlue;
            }
            lb17.FontSize = 16;

            Label lb18 = new Label();
            lb18.Margin = new Thickness(620, 190, 0, 0);
            lb18.HorizontalAlignment = HorizontalAlignment.Left;
            lb18.VerticalAlignment = VerticalAlignment.Top;
            lb18.Content = tab[1, 3, 0] + "," + tab[1, 3, 1] + "," + tab[1, 3, 2] + "," + tab[1, 3, 3] + "|" + tab[1, 3, 4];
            if (pos == 8)
            {
                lb18.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb18.Foreground = Brushes.DarkSlateBlue;
            }
            lb18.FontSize = 16;

            Label lb19 = new Label();
            lb19.Margin = new Thickness(810, 190, 0, 0);
            lb19.HorizontalAlignment = HorizontalAlignment.Left;
            lb19.VerticalAlignment = VerticalAlignment.Top;
            lb19.Content = tab[1, 4, 0] + "," + tab[1, 4, 1] + "," + tab[1, 4, 2] + "," + tab[1, 4, 3] + "|" + tab[1, 4, 4];
            lb19.Foreground = Brushes.DarkSlateBlue; lb19.FontSize = 16;

            //row5
            Label lb20 = new Label();
            lb20.Margin = new Thickness(7, 250, 0, 0);
            lb20.HorizontalAlignment = HorizontalAlignment.Left;
            lb20.VerticalAlignment = VerticalAlignment.Top;
            lb20.Content = "Z";
            lb20.Foreground = Brushes.DarkSlateBlue; lb20.FontSize = 16;

            Label lb21 = new Label();
            lb21.Margin = new Thickness(50, 250, 0, 0);
            lb21.HorizontalAlignment = HorizontalAlignment.Left;
            lb21.VerticalAlignment = VerticalAlignment.Top;
            lb21.Content = tab[2, 0, 0] + "," + tab[2, 0, 1] + "," + tab[2, 0, 2] + "," + tab[2, 0, 3] + "|" + tab[2, 0, 4];
            lb21.Foreground = Brushes.DarkSlateBlue; lb21.FontSize = 16;

            Label lb22 = new Label();
            lb22.Margin = new Thickness(240, 250, 0, 0);
            lb22.HorizontalAlignment = HorizontalAlignment.Left;
            lb22.VerticalAlignment = VerticalAlignment.Top;
            lb22.Content = tab[2, 1, 0] + "," + tab[2, 1, 1] + "," + tab[2, 1, 2] + "," + tab[2, 1, 3] + "|" + tab[2, 1, 4];
            lb22.Foreground = Brushes.DarkSlateBlue; lb22.FontSize = 16;

            Label lb23 = new Label();
            lb23.Margin = new Thickness(430, 250, 0, 0);
            lb23.HorizontalAlignment = HorizontalAlignment.Left;
            lb23.VerticalAlignment = VerticalAlignment.Top;
            lb23.Content = tab[2, 2, 0] + "," + tab[2, 2, 1] + "," + tab[2, 2, 2] + "," + tab[2, 2, 3] + "|" + tab[2, 2, 4];
            lb23.Foreground = Brushes.DarkSlateBlue; lb23.FontSize = 16;

            Label lb24 = new Label();
            lb24.Margin = new Thickness(620, 250, 0, 0);
            lb24.HorizontalAlignment = HorizontalAlignment.Left;
            lb24.VerticalAlignment = VerticalAlignment.Top;
            lb24.Content = tab[2, 3, 0] + "," + tab[2, 3, 1] + "," + tab[2, 3, 2] + "," + tab[2, 3, 3] + "|" + tab[2, 3, 4];
            lb24.Foreground = Brushes.DarkSlateBlue; lb24.FontSize = 16;

            Label lb25 = new Label();
            lb25.Margin = new Thickness(810, 250, 0, 0);
            lb25.HorizontalAlignment = HorizontalAlignment.Left;
            lb25.VerticalAlignment = VerticalAlignment.Top;
            lb25.Content = tab[2, 4, 0] + "," + tab[2, 4, 1] + "," + tab[2, 4, 2] + "," + tab[2, 4, 3] + "|" + tab[2, 4, 4];
            lb25.Foreground = Brushes.DarkSlateBlue; lb25.FontSize = 16;

            // Add it to Stack Children
            grd.Children.Add(rec);
            grd.Children.Add(sep1); grd.Children.Add(sep2); grd.Children.Add(sep3);
            grd.Children.Add(sep4); grd.Children.Add(sep5); grd.Children.Add(sep6);
            grd.Children.Add(sep7); grd.Children.Add(sep8); grd.Children.Add(sep9);
            grd.Children.Add(sep10);

            grd.Children.Add(lb1); grd.Children.Add(lb2); grd.Children.Add(lb3);
            grd.Children.Add(lb4); grd.Children.Add(lb5); grd.Children.Add(lb6);
            grd.Children.Add(lb7); grd.Children.Add(lb8); grd.Children.Add(lb9);
            grd.Children.Add(lb10); grd.Children.Add(lb11); grd.Children.Add(lb12);
            grd.Children.Add(lb13); grd.Children.Add(lb14); grd.Children.Add(lb15);
            grd.Children.Add(lb16); grd.Children.Add(lb17); grd.Children.Add(lb18);
            grd.Children.Add(lb19); grd.Children.Add(lb20); grd.Children.Add(lb21);
            grd.Children.Add(lb22); grd.Children.Add(lb23); grd.Children.Add(lb24);
            grd.Children.Add(lb25);
            
            stack.Children.Add(grd);
        }

        public void draw2(float[,,] tab, string comm1, string comm2, int pos, string[] side)
        {

            // The Tableau in Grid form May be no need for the grid again
            Grid grd = new Grid();
            grd.HorizontalAlignment = HorizontalAlignment.Left;
            grd.Margin = new Thickness(10, off, 0, 0);
            grd.Height = 300; grd.Width = 1190;
            grd.Background = Brushes.WhiteSmoke;

            Rectangle rec = new Rectangle();
            rec.Height = 300; rec.Width = 1190;
            rec.Margin = new Thickness(0); rec.Stroke = Brushes.Black;

            // verticals
            Separator sep1 = new Separator();
            sep1.HorizontalAlignment = HorizontalAlignment.Left;
            sep1.VerticalAlignment = VerticalAlignment.Top;
            sep1.Margin = new Thickness(50, 60, 0, 0);
            sep1.RenderTransform = new RotateTransform(90);
            sep1.Background = Brushes.Black; sep1.Width = 240;

            Separator sep2 = new Separator();
            sep2.HorizontalAlignment = HorizontalAlignment.Left;
            sep2.VerticalAlignment = VerticalAlignment.Top;
            sep2.Margin = new Thickness(240, 60, 0, 0);
            sep2.RenderTransform = new RotateTransform(90);
            sep2.Background = Brushes.Black; sep2.Width = 240;

            Separator sep3 = new Separator();
            sep3.HorizontalAlignment = HorizontalAlignment.Left;
            sep3.VerticalAlignment = VerticalAlignment.Top;
            sep3.Margin = new Thickness(430, 60, 0, 0);
            sep3.RenderTransform = new RotateTransform(90);
            sep3.Background = Brushes.Black; sep3.Width = 240;

            Separator sep4 = new Separator();
            sep4.HorizontalAlignment = HorizontalAlignment.Left;
            sep4.VerticalAlignment = VerticalAlignment.Top;
            sep4.Margin = new Thickness(620, 60, 0, 0);
            sep4.RenderTransform = new RotateTransform(90);
            sep4.Background = Brushes.Black; sep4.Width = 240;

            Separator sep5 = new Separator();
            sep5.HorizontalAlignment = HorizontalAlignment.Left;
            sep5.VerticalAlignment = VerticalAlignment.Top;
            sep5.Margin = new Thickness(810, 60, 0, 0);
            sep5.RenderTransform = new RotateTransform(90);
            sep5.Background = Brushes.Black; sep5.Width = 240;

            Separator sep10 = new Separator();
            sep10.HorizontalAlignment = HorizontalAlignment.Left;
            sep10.VerticalAlignment = VerticalAlignment.Top;
            sep10.Margin = new Thickness(1000, 60, 0, 0);
            sep10.RenderTransform = new RotateTransform(90);
            sep10.Background = Brushes.Black; sep10.Width = 240;

            Separator sep11 = new Separator();
            sep11.HorizontalAlignment = HorizontalAlignment.Left;
            sep11.VerticalAlignment = VerticalAlignment.Top;
            sep11.Margin = new Thickness(1000, 110, 0, 0);
            sep11.RenderTransform = new RotateTransform(90);
            sep11.Background = Brushes.Black; sep11.Width = 240;

            //horizontals
            Separator sep6 = new Separator();
            sep6.RenderTransformOrigin = new Point(0.5, 0.5);
            sep6.Margin = new Thickness(0, 60, 0, 0);
            sep6.VerticalAlignment = VerticalAlignment.Top;
            sep6.RenderTransform = new RotateTransform(180);
            sep6.Background = Brushes.Black; sep6.Width = 1190;

            Separator sep7 = new Separator();
            sep7.RenderTransformOrigin = new Point(0.5, 0.5);
            sep7.Margin = new Thickness(0, 120, 0, 0);
            sep7.VerticalAlignment = VerticalAlignment.Top;
            sep7.RenderTransform = new RotateTransform(180);
            sep7.Background = Brushes.Black; sep7.Width = 1190;

            Separator sep8 = new Separator();
            sep8.RenderTransformOrigin = new Point(0.5, 0.5);
            sep8.Margin = new Thickness(0, 180, 0, 0);
            sep8.VerticalAlignment = VerticalAlignment.Top;
            sep8.RenderTransform = new RotateTransform(180);
            sep8.Background = Brushes.Black; sep8.Width = 1190;

            Separator sep9 = new Separator();
            sep9.RenderTransformOrigin = new Point(0.5, 0.5);
            sep9.Margin = new Thickness(0, 240, 0, 0);
            sep9.VerticalAlignment = VerticalAlignment.Top;
            sep9.RenderTransform = new RotateTransform(180);
            sep9.Background = Brushes.Black; sep9.Width = 1190;

            // Labels 25
            // row 1
            Label lb1 = new Label();
            lb1.Margin = new Thickness(20, 10, 0, 0);
            lb1.HorizontalAlignment = HorizontalAlignment.Left;
            lb1.VerticalAlignment = VerticalAlignment.Top;
            lb1.Content = comm1 + " - " + comm2;
            lb1.Foreground = Brushes.DarkSlateBlue; lb1.FontSize = 20;

            //row2
            Label lb2 = new Label();
            lb2.Margin = new Thickness(7, 70, 0, 0);
            lb2.HorizontalAlignment = HorizontalAlignment.Left;
            lb2.VerticalAlignment = VerticalAlignment.Top;
            lb2.Content = "BV";
            lb2.Foreground = Brushes.DarkSlateBlue; lb2.FontSize = 20;

            Label lb3 = new Label();
            lb3.Margin = new Thickness(60, 70, 0, 0);
            lb3.HorizontalAlignment = HorizontalAlignment.Left;
            lb3.VerticalAlignment = VerticalAlignment.Top;
            lb3.Content = "X1";
            lb3.Foreground = Brushes.DarkSlateBlue; lb3.FontSize = 20;

            Label lb4 = new Label();
            lb4.Margin = new Thickness(240, 70, 0, 0);
            lb4.HorizontalAlignment = HorizontalAlignment.Left;
            lb4.VerticalAlignment = VerticalAlignment.Top;
            lb4.Content = "X2";
            lb4.Foreground = Brushes.DarkSlateBlue; lb4.FontSize = 20;

            Label lb5 = new Label();
            lb5.Margin = new Thickness(430, 70, 0, 0);
            lb5.HorizontalAlignment = HorizontalAlignment.Left;
            lb5.VerticalAlignment = VerticalAlignment.Top;
            lb5.Content = "X3";
            lb5.Foreground = Brushes.DarkSlateBlue; lb5.FontSize = 20;

            Label lb6 = new Label();
            lb6.Margin = new Thickness(620, 70, 0, 0);
            lb6.HorizontalAlignment = HorizontalAlignment.Left;
            lb6.VerticalAlignment = VerticalAlignment.Top;
            lb6.Content = "X4";
            lb6.Foreground = Brushes.DarkSlateBlue; lb6.FontSize = 20;

            Label lb26 = new Label();
            lb26.Margin = new Thickness(810, 70, 0, 0);
            lb26.HorizontalAlignment = HorizontalAlignment.Left;
            lb26.VerticalAlignment = VerticalAlignment.Top;
            lb26.Content = "X5";
            lb26.Foreground = Brushes.DarkSlateBlue; lb26.FontSize = 20;

            Label lb7 = new Label();
            lb7.Margin = new Thickness(1000, 70, 0, 0);
            lb7.HorizontalAlignment = HorizontalAlignment.Left;
            lb7.VerticalAlignment = VerticalAlignment.Top;
            lb7.Content = "RHS";
            lb7.Foreground = Brushes.DarkSlateBlue; lb7.FontSize = 20;

            //row3
            Label lb8 = new Label();
            lb8.Margin = new Thickness(7, 130, 0, 0);
            lb8.HorizontalAlignment = HorizontalAlignment.Left;
            lb8.VerticalAlignment = VerticalAlignment.Top;
            lb8.Content = side[0];
            lb8.Foreground = Brushes.DarkSlateBlue; lb8.FontSize = 16;

            Label lb9 = new Label();
            lb9.Margin = new Thickness(50, 130, 0, 0);
            lb9.HorizontalAlignment = HorizontalAlignment.Left;
            lb9.VerticalAlignment = VerticalAlignment.Top;
            lb9.Content = tab[0, 0, 0] + "," + tab[0, 0, 1] + "," + tab[0, 0, 2] + "," + tab[0, 0, 3] + "|" + tab[0, 0, 4];
            if (pos == 1)
            {
                lb9.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb9.Foreground = Brushes.DarkSlateBlue;
            }
            lb9.FontSize = 16;

            Label lb10 = new Label();
            lb10.Margin = new Thickness(240, 130, 0, 0);
            lb10.HorizontalAlignment = HorizontalAlignment.Left;
            lb10.VerticalAlignment = VerticalAlignment.Top;
            lb10.Content = tab[0, 1, 0] + "," + tab[0, 1, 1] + "," + tab[0, 1, 2] + "," + tab[0, 1, 3] + "|" + tab[0, 1, 4];
            if (pos == 2)
            {
                lb10.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb10.Foreground = Brushes.DarkSlateBlue;
            }
            lb10.FontSize = 16;

            Label lb11 = new Label();
            lb11.Margin = new Thickness(430, 130, 0, 0);
            lb11.HorizontalAlignment = HorizontalAlignment.Left;
            lb11.VerticalAlignment = VerticalAlignment.Top;
            lb11.Content = tab[0, 2, 0] + "," + tab[0, 2, 1] + "," + tab[0, 2, 2] + "," + tab[0, 2, 3] + "|" + tab[0, 2, 4];
            if (pos == 3)
            {
                lb11.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb11.Foreground = Brushes.DarkSlateBlue;
            }
            lb11.FontSize = 16;

            Label lb12 = new Label();
            lb12.Margin = new Thickness(620, 130, 0, 0);
            lb12.HorizontalAlignment = HorizontalAlignment.Left;
            lb12.VerticalAlignment = VerticalAlignment.Top;
            lb12.Content = tab[0, 3, 0] + "," + tab[0, 3, 1] + "," + tab[0, 3, 2] + "," + tab[0, 3, 3] + "|" + tab[0, 3, 4];
            if (pos == 4)
            {
                lb12.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb12.Foreground = Brushes.DarkSlateBlue;
            }
            lb12.FontSize = 16;

            Label lb27 = new Label();
            lb27.Margin = new Thickness(810, 130, 0, 0);
            lb27.HorizontalAlignment = HorizontalAlignment.Left;
            lb27.VerticalAlignment = VerticalAlignment.Top;
            lb27.Content = tab[0, 4, 0] + "," + tab[0, 4, 1] + "," + tab[0, 4, 2] + "," + tab[0, 4, 3] + "|" + tab[0, 4, 4];
            if (pos == 5)
            {
                lb27.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb27.Foreground = Brushes.DarkSlateBlue;
            }
            lb27.FontSize = 16;

            Label lb13 = new Label();
            lb13.Margin = new Thickness(1000, 130, 0, 0);
            lb13.HorizontalAlignment = HorizontalAlignment.Left;
            lb13.VerticalAlignment = VerticalAlignment.Top;
            lb13.Content = tab[0, 5, 0] + "," + tab[0, 5, 1] + "," + tab[0, 5, 2] + "," + tab[0, 5, 3] + "|" + tab[0, 5, 4];
            lb13.Foreground = Brushes.DarkSlateBlue; lb13.FontSize = 16;

            //row4
            Label lb14 = new Label();
            lb14.Margin = new Thickness(7, 190, 0, 0);
            lb14.HorizontalAlignment = HorizontalAlignment.Left;
            lb14.VerticalAlignment = VerticalAlignment.Top;
            lb14.Content = side[1];
            lb14.Foreground = Brushes.DarkSlateBlue; lb14.FontSize = 16;

            Label lb15 = new Label();
            lb15.Margin = new Thickness(50, 190, 0, 0);
            lb15.HorizontalAlignment = HorizontalAlignment.Left;
            lb15.VerticalAlignment = VerticalAlignment.Top;
            lb15.Content = tab[1, 0, 0] + "," + tab[1, 0, 1] + "," + tab[1, 0, 2] + "," + tab[1, 0, 3] + "|" + tab[1, 0, 4];
            if (pos == 6)
            {
                lb15.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb15.Foreground = Brushes.DarkSlateBlue;
            }
            lb15.FontSize = 16;

            Label lb16 = new Label();
            lb16.Margin = new Thickness(240, 190, 0, 0);
            lb16.HorizontalAlignment = HorizontalAlignment.Left;
            lb16.VerticalAlignment = VerticalAlignment.Top;
            lb16.Content = tab[1, 1, 0] + "," + tab[1, 1, 1] + "," + tab[1, 1, 2] + "," + tab[1, 1, 3] + "|" + tab[1, 1, 4];
            if (pos == 7)
            {
                lb16.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb16.Foreground = Brushes.DarkSlateBlue;
            }
            lb16.FontSize = 16;

            Label lb17 = new Label();
            lb17.Margin = new Thickness(430, 190, 0, 0);
            lb17.HorizontalAlignment = HorizontalAlignment.Left;
            lb17.VerticalAlignment = VerticalAlignment.Top;
            lb17.Content = tab[1, 2, 0] + "," + tab[1, 2, 1] + "," + tab[1, 2, 2] + "," + tab[1, 2, 3] + "|" + tab[1, 2, 4];
            if (pos == 8)
            {
                lb17.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb17.Foreground = Brushes.DarkSlateBlue;
            }
            lb17.FontSize = 16;

            Label lb18 = new Label();
            lb18.Margin = new Thickness(620, 190, 0, 0);
            lb18.HorizontalAlignment = HorizontalAlignment.Left;
            lb18.VerticalAlignment = VerticalAlignment.Top;
            lb18.Content = tab[1, 3, 0] + "," + tab[1, 3, 1] + "," + tab[1, 3, 2] + "," + tab[1, 3, 3] + "|" + tab[1, 3, 4];
            if (pos == 9)
            {
                lb18.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb18.Foreground = Brushes.DarkSlateBlue;
            }
            lb18.FontSize = 16;

            Label lb28 = new Label();
            lb28.Margin = new Thickness(810, 190, 0, 0);
            lb28.HorizontalAlignment = HorizontalAlignment.Left;
            lb28.VerticalAlignment = VerticalAlignment.Top;
            lb28.Content = tab[1, 4, 0] + "," + tab[1, 4, 1] + "," + tab[1, 4, 2] + "," + tab[1, 4, 3] + "|" + tab[1, 4, 4];
            if (pos == 10)
            {
                lb28.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb28.Foreground = Brushes.DarkSlateBlue;
            }
            lb28.FontSize = 16;

            Label lb19 = new Label();
            lb19.Margin = new Thickness(1000, 190, 0, 0);
            lb19.HorizontalAlignment = HorizontalAlignment.Left;
            lb19.VerticalAlignment = VerticalAlignment.Top;
            lb19.Content = tab[1, 5, 0] + "," + tab[1, 5, 1] + "," + tab[1, 5, 2] + "," + tab[1, 5, 3] + "|" + tab[1, 5, 4];
            lb19.Foreground = Brushes.DarkSlateBlue; lb19.FontSize = 16;

            //row5
            Label lb20 = new Label();
            lb20.Margin = new Thickness(7, 250, 0, 0);
            lb20.HorizontalAlignment = HorizontalAlignment.Left;
            lb20.VerticalAlignment = VerticalAlignment.Top;
            lb20.Content = "Z";
            lb20.Foreground = Brushes.DarkSlateBlue; lb20.FontSize = 16;

            Label lb21 = new Label();
            lb21.Margin = new Thickness(50, 250, 0, 0);
            lb21.HorizontalAlignment = HorizontalAlignment.Left;
            lb21.VerticalAlignment = VerticalAlignment.Top;
            lb21.Content = tab[2, 0, 0] + "," + tab[2, 0, 1] + "," + tab[2, 0, 2] + "," + tab[2, 0, 3] + "|" + tab[2, 0, 4];
            lb21.Foreground = Brushes.DarkSlateBlue; lb21.FontSize = 16;

            Label lb22 = new Label();
            lb22.Margin = new Thickness(240, 250, 0, 0);
            lb22.HorizontalAlignment = HorizontalAlignment.Left;
            lb22.VerticalAlignment = VerticalAlignment.Top;
            lb22.Content = tab[2, 1, 0] + "," + tab[2, 1, 1] + "," + tab[2, 1, 2] + "," + tab[2, 1, 3] + "|" + tab[2, 1, 4];
            lb22.Foreground = Brushes.DarkSlateBlue; lb22.FontSize = 16;

            Label lb23 = new Label();
            lb23.Margin = new Thickness(430, 250, 0, 0);
            lb23.HorizontalAlignment = HorizontalAlignment.Left;
            lb23.VerticalAlignment = VerticalAlignment.Top;
            lb23.Content = tab[2, 2, 0] + "," + tab[2, 2, 1] + "," + tab[2, 2, 2] + "," + tab[2, 2, 3] + "|" + tab[2, 2, 4];
            lb23.Foreground = Brushes.DarkSlateBlue; lb23.FontSize = 16;

            Label lb24 = new Label();
            lb24.Margin = new Thickness(620, 250, 0, 0);
            lb24.HorizontalAlignment = HorizontalAlignment.Left;
            lb24.VerticalAlignment = VerticalAlignment.Top;
            lb24.Content = tab[2, 3, 0] + "," + tab[2, 3, 1] + "," + tab[2, 3, 2] + "," + tab[2, 3, 3] + "|" + tab[2, 3, 4];
            lb24.Foreground = Brushes.DarkSlateBlue; lb24.FontSize = 16;

            Label lb29 = new Label();
            lb29.Margin = new Thickness(810, 250, 0, 0);
            lb29.HorizontalAlignment = HorizontalAlignment.Left;
            lb29.VerticalAlignment = VerticalAlignment.Top;
            lb29.Content = tab[2, 4, 0] + "," + tab[2, 4, 1] + "," + tab[2, 4, 2] + "," + tab[2, 4, 3] + "|" + tab[2, 4, 4];
            lb29.Foreground = Brushes.DarkSlateBlue; lb29.FontSize = 16;

            Label lb25 = new Label();
            lb25.Margin = new Thickness(1000, 250, 0, 0);
            lb25.HorizontalAlignment = HorizontalAlignment.Left;
            lb25.VerticalAlignment = VerticalAlignment.Top;
            lb25.Content = tab[2, 5, 0] + "," + tab[2, 5, 1] + "," + tab[2, 5, 2] + "," + tab[2, 5, 3] + "|" + tab[2, 5, 4];
            lb25.Foreground = Brushes.DarkSlateBlue; lb25.FontSize = 16;

            // Add it to Stack Children
            grd.Children.Add(rec);
            grd.Children.Add(sep1); grd.Children.Add(sep2); grd.Children.Add(sep3);
            grd.Children.Add(sep4); grd.Children.Add(sep5); grd.Children.Add(sep6);
            grd.Children.Add(sep7); grd.Children.Add(sep8); grd.Children.Add(sep9);
            grd.Children.Add(sep10); grd.Children.Add(sep11);

            grd.Children.Add(lb1); grd.Children.Add(lb2); grd.Children.Add(lb3);
            grd.Children.Add(lb4); grd.Children.Add(lb5); grd.Children.Add(lb6);
            grd.Children.Add(lb7); grd.Children.Add(lb8); grd.Children.Add(lb9);
            grd.Children.Add(lb10); grd.Children.Add(lb11); grd.Children.Add(lb12);
            grd.Children.Add(lb13); grd.Children.Add(lb14); grd.Children.Add(lb15);
            grd.Children.Add(lb16); grd.Children.Add(lb17); grd.Children.Add(lb18);
            grd.Children.Add(lb19); grd.Children.Add(lb20); grd.Children.Add(lb21);
            grd.Children.Add(lb22); grd.Children.Add(lb23); grd.Children.Add(lb24);
            grd.Children.Add(lb25); grd.Children.Add(lb26); grd.Children.Add(lb27);
            grd.Children.Add(lb28); grd.Children.Add(lb29);

            stack.Children.Add(grd);
        }

        public void draw3(float[,,] tab, string comm1, string comm2, int pos, string[] side)
        {

            // The Tableau in Grid form May be no need for the grid again
            Grid grd = new Grid();
            grd.HorizontalAlignment = HorizontalAlignment.Left;
            grd.Margin = new Thickness(10, off, 0, 0);
            grd.Height = 360; grd.Width = 1190;
            grd.Background = Brushes.WhiteSmoke;

            Rectangle rec = new Rectangle();
            rec.Height = 360; rec.Width = 1190;
            rec.Margin = new Thickness(0); rec.Stroke = Brushes.Black;

            // verticals
            Separator sep1 = new Separator();
            sep1.HorizontalAlignment = HorizontalAlignment.Left;
            sep1.VerticalAlignment = VerticalAlignment.Top;
            sep1.Margin = new Thickness(50, 60, 0, 0);
            sep1.RenderTransform = new RotateTransform(90);
            sep1.Background = Brushes.Black; sep1.Width = 300;

            Separator sep2 = new Separator();
            sep2.HorizontalAlignment = HorizontalAlignment.Left;
            sep2.VerticalAlignment = VerticalAlignment.Top;
            sep2.Margin = new Thickness(240, 60, 0, 0);
            sep2.RenderTransform = new RotateTransform(90);
            sep2.Background = Brushes.Black; sep2.Width = 300;

            Separator sep3 = new Separator();
            sep3.HorizontalAlignment = HorizontalAlignment.Left;
            sep3.VerticalAlignment = VerticalAlignment.Top;
            sep3.Margin = new Thickness(430, 60, 0, 0);
            sep3.RenderTransform = new RotateTransform(90);
            sep3.Background = Brushes.Black; sep3.Width = 300;

            Separator sep4 = new Separator();
            sep4.HorizontalAlignment = HorizontalAlignment.Left;
            sep4.VerticalAlignment = VerticalAlignment.Top;
            sep4.Margin = new Thickness(620, 60, 0, 0);
            sep4.RenderTransform = new RotateTransform(90);
            sep4.Background = Brushes.Black; sep4.Width = 300;

            Separator sep5 = new Separator();
            sep5.HorizontalAlignment = HorizontalAlignment.Left;
            sep5.VerticalAlignment = VerticalAlignment.Top;
            sep5.Margin = new Thickness(810, 60, 0, 0);
            sep5.RenderTransform = new RotateTransform(90);
            sep5.Background = Brushes.Black; sep5.Width = 300;

            Separator sep10 = new Separator();
            sep10.HorizontalAlignment = HorizontalAlignment.Left;
            sep10.VerticalAlignment = VerticalAlignment.Top;
            sep10.Margin = new Thickness(1000, 60, 0, 0);
            sep10.RenderTransform = new RotateTransform(90);
            sep10.Background = Brushes.Black; sep10.Width = 300;

            Separator sep12 = new Separator();
            sep12.HorizontalAlignment = HorizontalAlignment.Left;
            sep12.VerticalAlignment = VerticalAlignment.Top;
            sep12.Margin = new Thickness(1000, 170, 0, 0);
            sep12.RenderTransform = new RotateTransform(90);
            sep12.Background = Brushes.Black; sep12.Width = 300;

            //horizontals
            Separator sep6 = new Separator();
            sep6.RenderTransformOrigin = new Point(0.5, 0.5);
            sep6.Margin = new Thickness(0, 60, 0, 0);
            sep6.VerticalAlignment = VerticalAlignment.Top;
            sep6.RenderTransform = new RotateTransform(180);
            sep6.Background = Brushes.Black; sep6.Width = 1190;

            Separator sep7 = new Separator();
            sep7.RenderTransformOrigin = new Point(0.5, 0.5);
            sep7.Margin = new Thickness(0, 120, 0, 0);
            sep7.VerticalAlignment = VerticalAlignment.Top;
            sep7.RenderTransform = new RotateTransform(180);
            sep7.Background = Brushes.Black; sep7.Width = 1190;

            Separator sep8 = new Separator();
            sep8.RenderTransformOrigin = new Point(0.5, 0.5);
            sep8.Margin = new Thickness(0, 180, 0, 0);
            sep8.VerticalAlignment = VerticalAlignment.Top;
            sep8.RenderTransform = new RotateTransform(180);
            sep8.Background = Brushes.Black; sep8.Width = 1190;

            Separator sep9 = new Separator();
            sep9.RenderTransformOrigin = new Point(0.5, 0.5);
            sep9.Margin = new Thickness(0, 240, 0, 0);
            sep9.VerticalAlignment = VerticalAlignment.Top;
            sep9.RenderTransform = new RotateTransform(180);
            sep9.Background = Brushes.Black; sep9.Width = 1190;

            Separator sep11 = new Separator();
            sep11.RenderTransformOrigin = new Point(0.5, 0.5);
            sep11.Margin = new Thickness(0, 300, 0, 0);
            sep11.VerticalAlignment = VerticalAlignment.Top;
            sep11.RenderTransform = new RotateTransform(180);
            sep11.Background = Brushes.Black; sep11.Width = 1190;

            // Labels 25
            // row 1
            Label lb1 = new Label();
            lb1.Margin = new Thickness(20, 10, 0, 0);
            lb1.HorizontalAlignment = HorizontalAlignment.Left;
            lb1.VerticalAlignment = VerticalAlignment.Top;
            lb1.Content = comm1 + " - " + comm2;
            lb1.Foreground = Brushes.DarkSlateBlue; lb1.FontSize = 20;

            //row2
            Label lb2 = new Label();
            lb2.Margin = new Thickness(7, 70, 0, 0);
            lb2.HorizontalAlignment = HorizontalAlignment.Left;
            lb2.VerticalAlignment = VerticalAlignment.Top;
            lb2.Content = "BV";
            lb2.Foreground = Brushes.DarkSlateBlue; lb2.FontSize = 20;

            Label lb3 = new Label();
            lb3.Margin = new Thickness(60, 70, 0, 0);
            lb3.HorizontalAlignment = HorizontalAlignment.Left;
            lb3.VerticalAlignment = VerticalAlignment.Top;
            lb3.Content = "X1";
            lb3.Foreground = Brushes.DarkSlateBlue; lb3.FontSize = 20;

            Label lb4 = new Label();
            lb4.Margin = new Thickness(240, 70, 0, 0);
            lb4.HorizontalAlignment = HorizontalAlignment.Left;
            lb4.VerticalAlignment = VerticalAlignment.Top;
            lb4.Content = "X2";
            lb4.Foreground = Brushes.DarkSlateBlue; lb4.FontSize = 20;

            Label lb5 = new Label();
            lb5.Margin = new Thickness(430, 70, 0, 0);
            lb5.HorizontalAlignment = HorizontalAlignment.Left;
            lb5.VerticalAlignment = VerticalAlignment.Top;
            lb5.Content = "X3";
            lb5.Foreground = Brushes.DarkSlateBlue; lb5.FontSize = 20;

            Label lb6 = new Label();
            lb6.Margin = new Thickness(620, 70, 0, 0);
            lb6.HorizontalAlignment = HorizontalAlignment.Left;
            lb6.VerticalAlignment = VerticalAlignment.Top;
            lb6.Content = "X4";
            lb6.Foreground = Brushes.DarkSlateBlue; lb6.FontSize = 20;

            Label lb26 = new Label();
            lb26.Margin = new Thickness(810, 70, 0, 0);
            lb26.HorizontalAlignment = HorizontalAlignment.Left;
            lb26.VerticalAlignment = VerticalAlignment.Top;
            lb26.Content = "X5";
            lb26.Foreground = Brushes.DarkSlateBlue; lb26.FontSize = 20;

            Label lb7 = new Label();
            lb7.Margin = new Thickness(1000, 70, 0, 0);
            lb7.HorizontalAlignment = HorizontalAlignment.Left;
            lb7.VerticalAlignment = VerticalAlignment.Top;
            lb7.Content = "RHS";
            lb7.Foreground = Brushes.DarkSlateBlue; lb7.FontSize = 20;

            //row3
            Label lb8 = new Label();
            lb8.Margin = new Thickness(7, 130, 0, 0);
            lb8.HorizontalAlignment = HorizontalAlignment.Left;
            lb8.VerticalAlignment = VerticalAlignment.Top;
            lb8.Content = side[0];
            lb8.Foreground = Brushes.DarkSlateBlue; lb8.FontSize = 16;

            Label lb9 = new Label();
            lb9.Margin = new Thickness(50, 130, 0, 0);
            lb9.HorizontalAlignment = HorizontalAlignment.Left;
            lb9.VerticalAlignment = VerticalAlignment.Top;
            //
            lb9.Content = tab[0, 0, 0] + "," + tab[0, 0, 1] + "," + tab[0, 0, 2] + "," + tab[0, 0, 3] + "|" + tab[0, 0, 4];
            if (pos == 1)
            {
                lb9.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb9.Foreground = Brushes.DarkSlateBlue;
            }
            lb9.FontSize = 16;

            Label lb10 = new Label();
            lb10.Margin = new Thickness(240, 130, 0, 0);
            lb10.HorizontalAlignment = HorizontalAlignment.Left;
            lb10.VerticalAlignment = VerticalAlignment.Top;
            lb10.Content = tab[0, 1, 0] + "," + tab[0, 1, 1] + "," + tab[0, 1, 2] + "," + tab[0, 1, 3] + "|" + tab[0, 1, 4];
            if (pos == 2)
            {
                lb10.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb10.Foreground = Brushes.DarkSlateBlue;
            }
            lb10.FontSize = 16;

            Label lb11 = new Label();
            lb11.Margin = new Thickness(430, 130, 0, 0);
            lb11.HorizontalAlignment = HorizontalAlignment.Left;
            lb11.VerticalAlignment = VerticalAlignment.Top;
            lb11.Content = tab[0, 2, 0] + "," + tab[0, 2, 1] + "," + tab[0, 2, 2] + "," + tab[0, 2, 3] + "|" + tab[0, 2, 4];
            if (pos == 3)
            {
                lb11.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb11.Foreground = Brushes.DarkSlateBlue;
            }
            lb11.FontSize = 16;

            Label lb12 = new Label();
            lb12.Margin = new Thickness(620, 130, 0, 0);
            lb12.HorizontalAlignment = HorizontalAlignment.Left;
            lb12.VerticalAlignment = VerticalAlignment.Top;
            lb12.Content = tab[0, 3, 0] + "," + tab[0, 3, 1] + "," + tab[0, 3, 2] + "," + tab[0, 3, 3] + "|" + tab[0, 3, 4];
            if (pos == 4)
            {
                lb12.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb12.Foreground = Brushes.DarkSlateBlue;
            }
            lb12.FontSize = 16;

            Label lb27 = new Label();
            lb27.Margin = new Thickness(810, 130, 0, 0);
            lb27.HorizontalAlignment = HorizontalAlignment.Left;
            lb27.VerticalAlignment = VerticalAlignment.Top;
            lb27.Content = tab[0, 4, 0] + "," + tab[0, 4, 1] + "," + tab[0, 4, 2] + "," + tab[0, 4, 3] + "|" + tab[0, 4, 4];
            if (pos == 5)
            {
                lb27.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb27.Foreground = Brushes.DarkSlateBlue;
            }
            lb27.FontSize = 16;

            Label lb13 = new Label();
            lb13.Margin = new Thickness(1000, 130, 0, 0);
            lb13.HorizontalAlignment = HorizontalAlignment.Left;
            lb13.VerticalAlignment = VerticalAlignment.Top;
            lb13.Content = tab[0, 5, 0] + "," + tab[0, 5, 1] + "," + tab[0, 5, 2] + "," + tab[0, 5, 3] + "|" + tab[0, 5, 4];
            lb13.Foreground = Brushes.DarkSlateBlue; lb13.FontSize = 16;

            //row4
            Label lb14 = new Label();
            lb14.Margin = new Thickness(7, 190, 0, 0);
            lb14.HorizontalAlignment = HorizontalAlignment.Left;
            lb14.VerticalAlignment = VerticalAlignment.Top;
            lb14.Content = side[1];
            lb14.Foreground = Brushes.DarkSlateBlue; lb14.FontSize = 16;

            Label lb15 = new Label();
            lb15.Margin = new Thickness(50, 190, 0, 0);
            lb15.HorizontalAlignment = HorizontalAlignment.Left;
            lb15.VerticalAlignment = VerticalAlignment.Top;
            lb15.Content = tab[1, 0, 0] + "," + tab[1, 0, 1] + "," + tab[1, 0, 2] + "," + tab[1, 0, 3] + "|" + tab[1, 0, 4];
            if (pos == 6)
            {
                lb15.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb15.Foreground = Brushes.DarkSlateBlue;
            }
            lb15.FontSize = 16;

            Label lb16 = new Label();
            lb16.Margin = new Thickness(240, 190, 0, 0);
            lb16.HorizontalAlignment = HorizontalAlignment.Left;
            lb16.VerticalAlignment = VerticalAlignment.Top;
            lb16.Content = tab[1, 1, 0] + "," + tab[1, 1, 1] + "," + tab[1, 1, 2] + "," + tab[1, 1, 3] + "|" + tab[1, 1, 4];
            if (pos == 7)
            {
                lb16.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb16.Foreground = Brushes.DarkSlateBlue;
            }
            lb16.FontSize = 16;

            Label lb17 = new Label();
            lb17.Margin = new Thickness(430, 190, 0, 0);
            lb17.HorizontalAlignment = HorizontalAlignment.Left;
            lb17.VerticalAlignment = VerticalAlignment.Top;
            lb17.Content = tab[1, 2, 0] + "," + tab[1, 2, 1] + "," + tab[1, 2, 2] + "," + tab[1, 2, 3] + "|" + tab[1, 2, 4];
            if (pos == 8)
            {
                lb17.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb17.Foreground = Brushes.DarkSlateBlue;
            }
            lb17.FontSize = 16;

            Label lb18 = new Label();
            lb18.Margin = new Thickness(620, 190, 0, 0);
            lb18.HorizontalAlignment = HorizontalAlignment.Left;
            lb18.VerticalAlignment = VerticalAlignment.Top;
            lb18.Content = tab[1, 3, 0] + "," + tab[1, 3, 1] + "," + tab[1, 3, 2] + "," + tab[1, 3, 3] + "|" + tab[1, 3, 4];
            if (pos == 9)
            {
                lb18.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb18.Foreground = Brushes.DarkSlateBlue;
            }
            lb18.FontSize = 16;

            Label lb28 = new Label();
            lb28.Margin = new Thickness(810, 190, 0, 0);
            lb28.HorizontalAlignment = HorizontalAlignment.Left;
            lb28.VerticalAlignment = VerticalAlignment.Top;
            lb28.Content = tab[1, 4, 0] + "," + tab[1, 4, 1] + "," + tab[1, 4, 2] + "," + tab[1, 4, 3] + "|" + tab[1, 4, 4];
            if (pos == 10)
            {
                lb28.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb28.Foreground = Brushes.DarkSlateBlue;
            }
            lb28.FontSize = 16;

            Label lb19 = new Label();
            lb19.Margin = new Thickness(1000, 190, 0, 0);
            lb19.HorizontalAlignment = HorizontalAlignment.Left;
            lb19.VerticalAlignment = VerticalAlignment.Top;
            lb19.Content = tab[1, 5, 0] + "," + tab[1, 5, 1] + "," + tab[1, 5, 2] + "," + tab[1, 5, 3] + "|" + tab[1, 5, 4];
            lb19.Foreground = Brushes.DarkSlateBlue; lb19.FontSize = 16;

            //row5
            Label lb30 = new Label();
            lb30.Margin = new Thickness(7, 250, 0, 0);
            lb30.HorizontalAlignment = HorizontalAlignment.Left;
            lb30.VerticalAlignment = VerticalAlignment.Top;
            lb30.Content = side[2];
            lb30.Foreground = Brushes.DarkSlateBlue; lb30.FontSize = 16;

            Label lb31 = new Label();
            lb31.Margin = new Thickness(50, 250, 0, 0);
            lb31.HorizontalAlignment = HorizontalAlignment.Left;
            lb31.VerticalAlignment = VerticalAlignment.Top;
            lb31.Content = tab[2, 0, 0] + "," + tab[2, 0, 1] + "," + tab[2, 0, 2] + "," + tab[2, 0, 3] + "|" + tab[2, 0, 4];
            if (pos == 11)
            {
                lb31.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb31.Foreground = Brushes.DarkSlateBlue;
            }
            lb31.FontSize = 16;

            Label lb32 = new Label();
            lb32.Margin = new Thickness(240, 250, 0, 0);
            lb32.HorizontalAlignment = HorizontalAlignment.Left;
            lb32.VerticalAlignment = VerticalAlignment.Top;
            lb32.Content = tab[2, 1, 0] + "," + tab[2, 1, 1] + "," + tab[2, 1, 2] + "," + tab[2, 1, 3] + "|" + tab[2, 1, 4];
            if (pos == 12)
            {
                lb32.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb32.Foreground = Brushes.DarkSlateBlue;
            }
            lb32.FontSize = 16;

            Label lb33 = new Label();
            lb33.Margin = new Thickness(430, 250, 0, 0);
            lb33.HorizontalAlignment = HorizontalAlignment.Left;
            lb33.VerticalAlignment = VerticalAlignment.Top;
            lb33.Content = tab[2, 2, 0] + "," + tab[2, 2, 1] + "," + tab[2, 2, 2] + "," + tab[2, 2, 3] + "|" + tab[2, 2, 4];
            if (pos == 13)
            {
                lb33.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb33.Foreground = Brushes.DarkSlateBlue;
            }
            lb33.FontSize = 16;

            Label lb34 = new Label();
            lb34.Margin = new Thickness(620, 250, 0, 0);
            lb34.HorizontalAlignment = HorizontalAlignment.Left;
            lb34.VerticalAlignment = VerticalAlignment.Top;
            lb34.Content = tab[2, 3, 0] + "," + tab[2, 3, 1] + "," + tab[2, 3, 2] + "," + tab[2, 3, 3] + "|" + tab[2, 3, 4];
            if (pos == 14)
            {
                lb34.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb34.Foreground = Brushes.DarkSlateBlue;
            }
            lb34.FontSize = 16;

            Label lb35 = new Label();
            lb35.Margin = new Thickness(810, 250, 0, 0);
            lb35.HorizontalAlignment = HorizontalAlignment.Left;
            lb35.VerticalAlignment = VerticalAlignment.Top;
            lb35.Content = tab[2, 4, 0] + "," + tab[2, 4, 1] + "," + tab[2, 4, 2] + "," + tab[2, 4, 3] + "|" + tab[2, 4, 4];
            if (pos == 15)
            {
                lb35.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb35.Foreground = Brushes.DarkSlateBlue;
            }
            lb35.FontSize = 16;

            Label lb36 = new Label();
            lb36.Margin = new Thickness(1000, 250, 0, 0);
            lb36.HorizontalAlignment = HorizontalAlignment.Left;
            lb36.VerticalAlignment = VerticalAlignment.Top;
            lb36.Content = tab[2, 5, 0] + "," + tab[2, 5, 1] + "," + tab[2, 5, 2] + "," + tab[2, 5, 3] + "|" + tab[2, 5, 4];
            lb36.Foreground = Brushes.DarkSlateBlue; lb36.FontSize = 16;

            //row6
            Label lb20 = new Label();
            lb20.Margin = new Thickness(7, 310, 0, 0);
            lb20.HorizontalAlignment = HorizontalAlignment.Left;
            lb20.VerticalAlignment = VerticalAlignment.Top;
            lb20.Content = "Z";
            lb20.Foreground = Brushes.DarkSlateBlue; lb20.FontSize = 16;

            Label lb21 = new Label();
            lb21.Margin = new Thickness(50, 310, 0, 0);
            lb21.HorizontalAlignment = HorizontalAlignment.Left;
            lb21.VerticalAlignment = VerticalAlignment.Top;
            lb21.Content = tab[3, 0, 0] + "," + tab[3, 0, 1] + "," + tab[3, 0, 2] + "," + tab[3, 0, 3] + "|" + tab[3, 0, 4];
            lb21.Foreground = Brushes.DarkSlateBlue; lb21.FontSize = 16;

            Label lb22 = new Label();
            lb22.Margin = new Thickness(240, 310, 0, 0);
            lb22.HorizontalAlignment = HorizontalAlignment.Left;
            lb22.VerticalAlignment = VerticalAlignment.Top;
            lb22.Content = tab[3, 1, 0] + "," + tab[3, 1, 1] + "," + tab[3, 1, 2] + "," + tab[3, 1, 3] + "|" + tab[3, 1, 4];
            lb22.Foreground = Brushes.DarkSlateBlue; lb22.FontSize = 16;

            Label lb23 = new Label();
            lb23.Margin = new Thickness(430, 310, 0, 0);
            lb23.HorizontalAlignment = HorizontalAlignment.Left;
            lb23.VerticalAlignment = VerticalAlignment.Top;
            lb23.Content = tab[3, 2, 0] + "," + tab[3, 2, 1] + "," + tab[3, 2, 2] + "," + tab[3, 2, 3] + "|" + tab[3, 2, 4];
            lb23.Foreground = Brushes.DarkSlateBlue; lb23.FontSize = 16;

            Label lb24 = new Label();
            lb24.Margin = new Thickness(620, 310, 0, 0);
            lb24.HorizontalAlignment = HorizontalAlignment.Left;
            lb24.VerticalAlignment = VerticalAlignment.Top;
            lb24.Content = tab[3, 3, 0] + "," + tab[3, 3, 1] + "," + tab[3, 3, 2] + "," + tab[3, 3, 3] + "|" + tab[3, 3, 4];
            lb24.Foreground = Brushes.DarkSlateBlue; lb24.FontSize = 16;

            Label lb29 = new Label();
            lb29.Margin = new Thickness(810, 310, 0, 0);
            lb29.HorizontalAlignment = HorizontalAlignment.Left;
            lb29.VerticalAlignment = VerticalAlignment.Top;
            lb29.Content = tab[3, 4, 0] + "," + tab[3, 4, 1] + "," + tab[3, 4, 2] + "," + tab[3, 4, 3] + "|" + tab[3, 4, 4];
            lb29.Foreground = Brushes.DarkSlateBlue; lb29.FontSize = 16;

            Label lb25 = new Label();
            lb25.Margin = new Thickness(1000, 310, 0, 0);
            lb25.HorizontalAlignment = HorizontalAlignment.Left;
            lb25.VerticalAlignment = VerticalAlignment.Top;
            lb25.Content = tab[3, 5, 0] + "," + tab[3, 5, 1] + "," + tab[3, 5, 2] + "," + tab[3, 5, 3] + "|" + tab[3, 5, 4];
            lb25.Foreground = Brushes.DarkSlateBlue; lb25.FontSize = 16;

            // Add it to Stack Children
            grd.Children.Add(rec);
            grd.Children.Add(sep1); grd.Children.Add(sep2); grd.Children.Add(sep3);
            grd.Children.Add(sep4); grd.Children.Add(sep5); grd.Children.Add(sep6);
            grd.Children.Add(sep7); grd.Children.Add(sep8); grd.Children.Add(sep9);
            grd.Children.Add(sep10); grd.Children.Add(sep11); grd.Children.Add(sep12);

            grd.Children.Add(lb1); grd.Children.Add(lb2); grd.Children.Add(lb3);
            grd.Children.Add(lb4); grd.Children.Add(lb5); grd.Children.Add(lb6);
            grd.Children.Add(lb7); grd.Children.Add(lb8); grd.Children.Add(lb9);
            grd.Children.Add(lb10); grd.Children.Add(lb11); grd.Children.Add(lb12);
            grd.Children.Add(lb13); grd.Children.Add(lb14); grd.Children.Add(lb15);
            grd.Children.Add(lb16); grd.Children.Add(lb17); grd.Children.Add(lb18);
            grd.Children.Add(lb19); grd.Children.Add(lb20); grd.Children.Add(lb21);
            grd.Children.Add(lb22); grd.Children.Add(lb23); grd.Children.Add(lb24);
            grd.Children.Add(lb25); grd.Children.Add(lb26); grd.Children.Add(lb27);
            grd.Children.Add(lb28); grd.Children.Add(lb29); grd.Children.Add(lb30);
            grd.Children.Add(lb31); grd.Children.Add(lb32); grd.Children.Add(lb33);
            grd.Children.Add(lb34); grd.Children.Add(lb35); grd.Children.Add(lb36);

            stack.Children.Add(grd);
        }

        public void draw4(float[,,] tab, string comm1, string comm2, int pos, string[] side)
        {

            // The Tableau in Grid form May be no need for the grid again
            Grid grd = new Grid();
            grd.HorizontalAlignment = HorizontalAlignment.Left;
            grd.Margin = new Thickness(10, off, 0, 0);
            grd.Height = 360; grd.Width = 1380;
            grd.Background = Brushes.WhiteSmoke;

            Rectangle rec = new Rectangle();
            rec.Height = 360; rec.Width = 1380;
            rec.Margin = new Thickness(0); rec.Stroke = Brushes.Black;

            // verticals
            Separator sep1 = new Separator();
            sep1.HorizontalAlignment = HorizontalAlignment.Left;
            sep1.VerticalAlignment = VerticalAlignment.Top;
            sep1.Margin = new Thickness(50, 60, 0, 0);
            sep1.RenderTransform = new RotateTransform(90);
            sep1.Background = Brushes.Black; sep1.Width = 300;

            Separator sep2 = new Separator();
            sep2.HorizontalAlignment = HorizontalAlignment.Left;
            sep2.VerticalAlignment = VerticalAlignment.Top;
            sep2.Margin = new Thickness(240, 60, 0, 0);
            sep2.RenderTransform = new RotateTransform(90);
            sep2.Background = Brushes.Black; sep2.Width = 300;

            Separator sep3 = new Separator();
            sep3.HorizontalAlignment = HorizontalAlignment.Left;
            sep3.VerticalAlignment = VerticalAlignment.Top;
            sep3.Margin = new Thickness(430, 60, 0, 0);
            sep3.RenderTransform = new RotateTransform(90);
            sep3.Background = Brushes.Black; sep3.Width = 300;

            Separator sep4 = new Separator();
            sep4.HorizontalAlignment = HorizontalAlignment.Left;
            sep4.VerticalAlignment = VerticalAlignment.Top;
            sep4.Margin = new Thickness(620, 60, 0, 0);
            sep4.RenderTransform = new RotateTransform(90);
            sep4.Background = Brushes.Black; sep4.Width = 300;

            Separator sep5 = new Separator();
            sep5.HorizontalAlignment = HorizontalAlignment.Left;
            sep5.VerticalAlignment = VerticalAlignment.Top;
            sep5.Margin = new Thickness(810, 60, 0, 0);
            sep5.RenderTransform = new RotateTransform(90);
            sep5.Background = Brushes.Black; sep5.Width = 300;

            Separator sep10 = new Separator();
            sep10.HorizontalAlignment = HorizontalAlignment.Left;
            sep10.VerticalAlignment = VerticalAlignment.Top;
            sep10.Margin = new Thickness(1000, 60, 0, 0);
            sep10.RenderTransform = new RotateTransform(90);
            sep10.Background = Brushes.Black; sep10.Width = 300;

            Separator sep12 = new Separator();
            sep12.HorizontalAlignment = HorizontalAlignment.Left;
            sep12.VerticalAlignment = VerticalAlignment.Top;
            sep12.Margin = new Thickness(1190, 60, 0, 0);
            sep12.RenderTransform = new RotateTransform(90);
            sep12.Background = Brushes.Black; sep12.Width = 300;

            Separator sep13 = new Separator();
            sep13.HorizontalAlignment = HorizontalAlignment.Left;
            sep13.VerticalAlignment = VerticalAlignment.Top;
            sep13.Margin = new Thickness(1190, 170, 0, 0);
            sep13.RenderTransform = new RotateTransform(90);
            sep13.Background = Brushes.Black; sep13.Width = 300;

            //horizontals
            Separator sep6 = new Separator();
            sep6.RenderTransformOrigin = new Point(0.5, 0.5);
            sep6.Margin = new Thickness(0, 60, 0, 0);
            sep6.VerticalAlignment = VerticalAlignment.Top;
            sep6.RenderTransform = new RotateTransform(180);
            sep6.Background = Brushes.Black; sep6.Width = 1380;

            Separator sep7 = new Separator();
            sep7.RenderTransformOrigin = new Point(0.5, 0.5);
            sep7.Margin = new Thickness(0, 120, 0, 0);
            sep7.VerticalAlignment = VerticalAlignment.Top;
            sep7.RenderTransform = new RotateTransform(180);
            sep7.Background = Brushes.Black; sep7.Width = 1380;

            Separator sep8 = new Separator();
            sep8.RenderTransformOrigin = new Point(0.5, 0.5);
            sep8.Margin = new Thickness(0, 180, 0, 0);
            sep8.VerticalAlignment = VerticalAlignment.Top;
            sep8.RenderTransform = new RotateTransform(180);
            sep8.Background = Brushes.Black; sep8.Width = 1380;

            Separator sep9 = new Separator();
            sep9.RenderTransformOrigin = new Point(0.5, 0.5);
            sep9.Margin = new Thickness(0, 240, 0, 0);
            sep9.VerticalAlignment = VerticalAlignment.Top;
            sep9.RenderTransform = new RotateTransform(180);
            sep9.Background = Brushes.Black; sep9.Width = 1380;

            Separator sep11 = new Separator();
            sep11.RenderTransformOrigin = new Point(0.5, 0.5);
            sep11.Margin = new Thickness(0, 300, 0, 0);
            sep11.VerticalAlignment = VerticalAlignment.Top;
            sep11.RenderTransform = new RotateTransform(180);
            sep11.Background = Brushes.Black; sep11.Width = 1380;

            // Labels 25
            // row 1
            Label lb1 = new Label();
            lb1.Margin = new Thickness(20, 10, 0, 0);
            lb1.HorizontalAlignment = HorizontalAlignment.Left;
            lb1.VerticalAlignment = VerticalAlignment.Top;
            lb1.Content = comm1 + " - " + comm2;
            lb1.Foreground = Brushes.DarkSlateBlue; lb1.FontSize = 20;

            //row2
            Label lb2 = new Label();
            lb2.Margin = new Thickness(7, 70, 0, 0);
            lb2.HorizontalAlignment = HorizontalAlignment.Left;
            lb2.VerticalAlignment = VerticalAlignment.Top;
            lb2.Content = "BV";
            lb2.Foreground = Brushes.DarkSlateBlue; lb2.FontSize = 20;

            Label lb3 = new Label();
            lb3.Margin = new Thickness(60, 70, 0, 0);
            lb3.HorizontalAlignment = HorizontalAlignment.Left;
            lb3.VerticalAlignment = VerticalAlignment.Top;
            lb3.Content = "X1";
            lb3.Foreground = Brushes.DarkSlateBlue; lb3.FontSize = 20;

            Label lb4 = new Label();
            lb4.Margin = new Thickness(240, 70, 0, 0);
            lb4.HorizontalAlignment = HorizontalAlignment.Left;
            lb4.VerticalAlignment = VerticalAlignment.Top;
            lb4.Content = "X2";
            lb4.Foreground = Brushes.DarkSlateBlue; lb4.FontSize = 20;

            Label lb5 = new Label();
            lb5.Margin = new Thickness(430, 70, 0, 0);
            lb5.HorizontalAlignment = HorizontalAlignment.Left;
            lb5.VerticalAlignment = VerticalAlignment.Top;
            lb5.Content = "X3";
            lb5.Foreground = Brushes.DarkSlateBlue; lb5.FontSize = 20;

            Label lb6 = new Label();
            lb6.Margin = new Thickness(620, 70, 0, 0);
            lb6.HorizontalAlignment = HorizontalAlignment.Left;
            lb6.VerticalAlignment = VerticalAlignment.Top;
            lb6.Content = "X4";
            lb6.Foreground = Brushes.DarkSlateBlue; lb6.FontSize = 20;

            Label lb26 = new Label();
            lb26.Margin = new Thickness(810, 70, 0, 0);
            lb26.HorizontalAlignment = HorizontalAlignment.Left;
            lb26.VerticalAlignment = VerticalAlignment.Top;
            lb26.Content = "X5";
            lb26.Foreground = Brushes.DarkSlateBlue; lb26.FontSize = 20;

            Label lb37 = new Label();
            lb37.Margin = new Thickness(1000, 70, 0, 0);
            lb37.HorizontalAlignment = HorizontalAlignment.Left;
            lb37.VerticalAlignment = VerticalAlignment.Top;
            lb37.Content = "X6";
            lb37.Foreground = Brushes.DarkSlateBlue; lb37.FontSize = 20;

            Label lb7 = new Label();
            lb7.Margin = new Thickness(1190, 70, 0, 0);
            lb7.HorizontalAlignment = HorizontalAlignment.Left;
            lb7.VerticalAlignment = VerticalAlignment.Top;
            lb7.Content = "RHS";
            lb7.Foreground = Brushes.DarkSlateBlue; lb7.FontSize = 20;

            //row3
            Label lb8 = new Label();
            lb8.Margin = new Thickness(7, 130, 0, 0);
            lb8.HorizontalAlignment = HorizontalAlignment.Left;
            lb8.VerticalAlignment = VerticalAlignment.Top;
            lb8.Content = side[0];
            lb8.Foreground = Brushes.DarkSlateBlue; lb8.FontSize = 16;

            Label lb9 = new Label();
            lb9.Margin = new Thickness(50, 130, 0, 0);
            lb9.HorizontalAlignment = HorizontalAlignment.Left;
            lb9.VerticalAlignment = VerticalAlignment.Top;
            //
            lb9.Content = tab[0, 0, 0] + "," + tab[0, 0, 1] + "," + tab[0, 0, 2] + "," + tab[0, 0, 3] + "|" + tab[0, 0, 4];
            if (pos == 1)
            {
                lb9.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb9.Foreground = Brushes.DarkSlateBlue;
            }
            lb9.FontSize = 16;

            Label lb10 = new Label();
            lb10.Margin = new Thickness(240, 130, 0, 0);
            lb10.HorizontalAlignment = HorizontalAlignment.Left;
            lb10.VerticalAlignment = VerticalAlignment.Top;
            lb10.Content = tab[0, 1, 0] + "," + tab[0, 1, 1] + "," + tab[0, 1, 2] + "," + tab[0, 1, 3] + "|" + tab[0, 1, 4];
            if (pos == 2)
            {
                lb10.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb10.Foreground = Brushes.DarkSlateBlue;
            }
            lb10.FontSize = 16;

            Label lb11 = new Label();
            lb11.Margin = new Thickness(430, 130, 0, 0);
            lb11.HorizontalAlignment = HorizontalAlignment.Left;
            lb11.VerticalAlignment = VerticalAlignment.Top;
            lb11.Content = tab[0, 2, 0] + "," + tab[0, 2, 1] + "," + tab[0, 2, 2] + "," + tab[0, 2, 3] + "|" + tab[0, 2, 4];
            if (pos == 3)
            {
                lb11.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb11.Foreground = Brushes.DarkSlateBlue;
            }
            lb11.FontSize = 16;

            Label lb12 = new Label();
            lb12.Margin = new Thickness(620, 130, 0, 0);
            lb12.HorizontalAlignment = HorizontalAlignment.Left;
            lb12.VerticalAlignment = VerticalAlignment.Top;
            lb12.Content = tab[0, 3, 0] + "," + tab[0, 3, 1] + "," + tab[0, 3, 2] + "," + tab[0, 3, 3] + "|" + tab[0, 3, 4];
            if (pos == 4)
            {
                lb12.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb12.Foreground = Brushes.DarkSlateBlue;
            }
            lb12.FontSize = 16;

            Label lb27 = new Label();
            lb27.Margin = new Thickness(810, 130, 0, 0);
            lb27.HorizontalAlignment = HorizontalAlignment.Left;
            lb27.VerticalAlignment = VerticalAlignment.Top;
            lb27.Content = tab[0, 4, 0] + "," + tab[0, 4, 1] + "," + tab[0, 4, 2] + "," + tab[0, 4, 3] + "|" + tab[0, 4, 4];
            if (pos == 5)
            {
                lb27.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb27.Foreground = Brushes.DarkSlateBlue;
            }
            lb27.FontSize = 16;

            Label lb38 = new Label();
            lb38.Margin = new Thickness(1000, 130, 0, 0);
            lb38.HorizontalAlignment = HorizontalAlignment.Left;
            lb38.VerticalAlignment = VerticalAlignment.Top;
            lb38.Content = tab[0, 5, 0] + "," + tab[0, 5, 1] + "," + tab[0, 5, 2] + "," + tab[0, 5, 3] + "|" + tab[0, 5, 4];
            if (pos == 6)
            {
                lb38.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb38.Foreground = Brushes.DarkSlateBlue;
            }
            lb38.FontSize = 16;

            Label lb13 = new Label();
            lb13.Margin = new Thickness(1190, 130, 0, 0);
            lb13.HorizontalAlignment = HorizontalAlignment.Left;
            lb13.VerticalAlignment = VerticalAlignment.Top;
            lb13.Content = tab[0, 6, 0] + "," + tab[0, 6, 1] + "," + tab[0, 6, 2] + "," + tab[0, 6, 3] + "|" + tab[0, 6, 4];
            lb13.Foreground = Brushes.DarkSlateBlue; lb13.FontSize = 16;

            //row4
            Label lb14 = new Label();
            lb14.Margin = new Thickness(7, 190, 0, 0);
            lb14.HorizontalAlignment = HorizontalAlignment.Left;
            lb14.VerticalAlignment = VerticalAlignment.Top;
            lb14.Content = side[1];
            lb14.Foreground = Brushes.DarkSlateBlue; lb14.FontSize = 16;

            Label lb15 = new Label();
            lb15.Margin = new Thickness(50, 190, 0, 0);
            lb15.HorizontalAlignment = HorizontalAlignment.Left;
            lb15.VerticalAlignment = VerticalAlignment.Top;
            lb15.Content = tab[1, 0, 0] + "," + tab[1, 0, 1] + "," + tab[1, 0, 2] + "," + tab[1, 0, 3] + "|" + tab[1, 0, 4];
            if (pos == 7)
            {
                lb15.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb15.Foreground = Brushes.DarkSlateBlue;
            }
            lb15.FontSize = 16;

            Label lb16 = new Label();
            lb16.Margin = new Thickness(240, 190, 0, 0);
            lb16.HorizontalAlignment = HorizontalAlignment.Left;
            lb16.VerticalAlignment = VerticalAlignment.Top;
            lb16.Content = tab[1, 1, 0] + "," + tab[1, 1, 1] + "," + tab[1, 1, 2] + "," + tab[1, 1, 3] + "|" + tab[1, 1, 4];
            if (pos == 8)
            {
                lb16.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb16.Foreground = Brushes.DarkSlateBlue;
            }
            lb16.FontSize = 16;

            Label lb17 = new Label();
            lb17.Margin = new Thickness(430, 190, 0, 0);
            lb17.HorizontalAlignment = HorizontalAlignment.Left;
            lb17.VerticalAlignment = VerticalAlignment.Top;
            lb17.Content = tab[1, 2, 0] + "," + tab[1, 2, 1] + "," + tab[1, 2, 2] + "," + tab[1, 2, 3] + "|" + tab[1, 2, 4];
            if (pos == 9)
            {
                lb17.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb17.Foreground = Brushes.DarkSlateBlue;
            }
            lb17.FontSize = 16;

            Label lb18 = new Label();
            lb18.Margin = new Thickness(620, 190, 0, 0);
            lb18.HorizontalAlignment = HorizontalAlignment.Left;
            lb18.VerticalAlignment = VerticalAlignment.Top;
            lb18.Content = tab[1, 3, 0] + "," + tab[1, 3, 1] + "," + tab[1, 3, 2] + "," + tab[1, 3, 3] + "|" + tab[1, 3, 4];
            if (pos == 10)
            {
                lb18.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb18.Foreground = Brushes.DarkSlateBlue;
            }
            lb18.FontSize = 16;

            Label lb28 = new Label();
            lb28.Margin = new Thickness(810, 190, 0, 0);
            lb28.HorizontalAlignment = HorizontalAlignment.Left;
            lb28.VerticalAlignment = VerticalAlignment.Top;
            lb28.Content = tab[1, 4, 0] + "," + tab[1, 4, 1] + "," + tab[1, 4, 2] + "," + tab[1, 4, 3] + "|" + tab[1, 4, 4];
            if (pos == 11)
            {
                lb28.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb28.Foreground = Brushes.DarkSlateBlue;
            }
            lb28.FontSize = 16;

            Label lb39 = new Label();
            lb39.Margin = new Thickness(1000, 190, 0, 0);
            lb39.HorizontalAlignment = HorizontalAlignment.Left;
            lb39.VerticalAlignment = VerticalAlignment.Top;
            lb39.Content = tab[1, 5, 0] + "," + tab[1, 5, 1] + "," + tab[1, 5, 2] + "," + tab[1, 5, 3] + "|" + tab[1, 5, 4];
            if (pos == 12)
            {
                lb39.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb39.Foreground = Brushes.DarkSlateBlue;
            }
            lb39.FontSize = 16;

            Label lb19 = new Label();
            lb19.Margin = new Thickness(1190, 190, 0, 0);
            lb19.HorizontalAlignment = HorizontalAlignment.Left;
            lb19.VerticalAlignment = VerticalAlignment.Top;
            lb19.Content = tab[1, 6, 0] + "," + tab[1, 6, 1] + "," + tab[1, 6, 2] + "," + tab[1, 6, 3] + "|" + tab[1, 6, 4];
            lb19.Foreground = Brushes.DarkSlateBlue; lb19.FontSize = 16;

            //row5
            Label lb30 = new Label();
            lb30.Margin = new Thickness(7, 250, 0, 0);
            lb30.HorizontalAlignment = HorizontalAlignment.Left;
            lb30.VerticalAlignment = VerticalAlignment.Top;
            lb30.Content = side[2];
            lb30.Foreground = Brushes.DarkSlateBlue; lb30.FontSize = 16;

            Label lb31 = new Label();
            lb31.Margin = new Thickness(50, 250, 0, 0);
            lb31.HorizontalAlignment = HorizontalAlignment.Left;
            lb31.VerticalAlignment = VerticalAlignment.Top;
            lb31.Content = tab[2, 0, 0] + "," + tab[2, 0, 1] + "," + tab[2, 0, 2] + "," + tab[2, 0, 3] + "|" + tab[2, 0, 4];
            if (pos == 13)
            {
                lb31.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb31.Foreground = Brushes.DarkSlateBlue;
            }
            lb31.FontSize = 16;

            Label lb32 = new Label();
            lb32.Margin = new Thickness(240, 250, 0, 0);
            lb32.HorizontalAlignment = HorizontalAlignment.Left;
            lb32.VerticalAlignment = VerticalAlignment.Top;
            lb32.Content = tab[2, 1, 0] + "," + tab[2, 1, 1] + "," + tab[2, 1, 2] + "," + tab[2, 1, 3] + "|" + tab[2, 1, 4];
            if (pos == 14)
            {
                lb32.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb32.Foreground = Brushes.DarkSlateBlue;
            }
            lb32.FontSize = 16;

            Label lb33 = new Label();
            lb33.Margin = new Thickness(430, 250, 0, 0);
            lb33.HorizontalAlignment = HorizontalAlignment.Left;
            lb33.VerticalAlignment = VerticalAlignment.Top;
            lb33.Content = tab[2, 2, 0] + "," + tab[2, 2, 1] + "," + tab[2, 2, 2] + "," + tab[2, 2, 3] + "|" + tab[2, 2, 4];
            if (pos == 15)
            {
                lb33.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb33.Foreground = Brushes.DarkSlateBlue;
            }
            lb33.FontSize = 16;

            Label lb34 = new Label();
            lb34.Margin = new Thickness(620, 250, 0, 0);
            lb34.HorizontalAlignment = HorizontalAlignment.Left;
            lb34.VerticalAlignment = VerticalAlignment.Top;
            lb34.Content = tab[2, 3, 0] + "," + tab[2, 3, 1] + "," + tab[2, 3, 2] + "," + tab[2, 3, 3] + "|" + tab[2, 3, 4];
            if (pos == 16)
            {
                lb34.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb34.Foreground = Brushes.DarkSlateBlue;
            }
            lb34.FontSize = 16;

            Label lb35 = new Label();
            lb35.Margin = new Thickness(810, 250, 0, 0);
            lb35.HorizontalAlignment = HorizontalAlignment.Left;
            lb35.VerticalAlignment = VerticalAlignment.Top;
            lb35.Content = tab[2, 4, 0] + "," + tab[2, 4, 1] + "," + tab[2, 4, 2] + "," + tab[2, 4, 3] + "|" + tab[2, 4, 4];
            if (pos == 17)
            {
                lb35.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb35.Foreground = Brushes.DarkSlateBlue;
            }
            lb35.FontSize = 16;

            Label lb40 = new Label();
            lb40.Margin = new Thickness(1000, 250, 0, 0);
            lb40.HorizontalAlignment = HorizontalAlignment.Left;
            lb40.VerticalAlignment = VerticalAlignment.Top;
            lb40.Content = tab[2, 5, 0] + "," + tab[2, 5, 1] + "," + tab[2, 5, 2] + "," + tab[2, 5, 3] + "|" + tab[2, 5, 4];
            if (pos == 18)
            {
                lb40.Foreground = Brushes.Goldenrod;
            }
            else
            {
                lb40.Foreground = Brushes.DarkSlateBlue;
            }
            lb40.FontSize = 16;

            Label lb36 = new Label();
            lb36.Margin = new Thickness(1190, 250, 0, 0);
            lb36.HorizontalAlignment = HorizontalAlignment.Left;
            lb36.VerticalAlignment = VerticalAlignment.Top;
            lb36.Content = tab[2, 6, 0] + "," + tab[2, 6, 1] + "," + tab[2, 6, 2] + "," + tab[2, 6, 3] + "|" + tab[2, 6, 4];
            lb36.Foreground = Brushes.DarkSlateBlue; lb36.FontSize = 16;

            //row6
            Label lb20 = new Label();
            lb20.Margin = new Thickness(7, 310, 0, 0);
            lb20.HorizontalAlignment = HorizontalAlignment.Left;
            lb20.VerticalAlignment = VerticalAlignment.Top;
            lb20.Content = "Z";
            lb20.Foreground = Brushes.DarkSlateBlue; lb20.FontSize = 16;

            Label lb21 = new Label();
            lb21.Margin = new Thickness(50, 310, 0, 0);
            lb21.HorizontalAlignment = HorizontalAlignment.Left;
            lb21.VerticalAlignment = VerticalAlignment.Top;
            lb21.Content = tab[3, 0, 0] + "," + tab[3, 0, 1] + "," + tab[3, 0, 2] + "," + tab[3, 0, 3] + "|" + tab[3, 0, 4];
            lb21.Foreground = Brushes.DarkSlateBlue; lb21.FontSize = 16;

            Label lb22 = new Label();
            lb22.Margin = new Thickness(240, 310, 0, 0);
            lb22.HorizontalAlignment = HorizontalAlignment.Left;
            lb22.VerticalAlignment = VerticalAlignment.Top;
            lb22.Content = tab[3, 1, 0] + "," + tab[3, 1, 1] + "," + tab[3, 1, 2] + "," + tab[3, 1, 3] + "|" + tab[3, 1, 4];
            lb22.Foreground = Brushes.DarkSlateBlue; lb22.FontSize = 16;

            Label lb23 = new Label();
            lb23.Margin = new Thickness(430, 310, 0, 0);
            lb23.HorizontalAlignment = HorizontalAlignment.Left;
            lb23.VerticalAlignment = VerticalAlignment.Top;
            lb23.Content = tab[3, 2, 0] + "," + tab[3, 2, 1] + "," + tab[3, 2, 2] + "," + tab[3, 2, 3] + "|" + tab[3, 2, 4];
            lb23.Foreground = Brushes.DarkSlateBlue; lb23.FontSize = 16;

            Label lb24 = new Label();
            lb24.Margin = new Thickness(620, 310, 0, 0);
            lb24.HorizontalAlignment = HorizontalAlignment.Left;
            lb24.VerticalAlignment = VerticalAlignment.Top;
            lb24.Content = tab[3, 3, 0] + "," + tab[3, 3, 1] + "," + tab[3, 3, 2] + "," + tab[3, 3, 3] + "|" + tab[3, 3, 4];
            lb24.Foreground = Brushes.DarkSlateBlue; lb24.FontSize = 16;

            Label lb29 = new Label();
            lb29.Margin = new Thickness(810, 310, 0, 0);
            lb29.HorizontalAlignment = HorizontalAlignment.Left;
            lb29.VerticalAlignment = VerticalAlignment.Top;
            lb29.Content = tab[3, 4, 0] + "," + tab[3, 4, 1] + "," + tab[3, 4, 2] + "," + tab[3, 4, 3] + "|" + tab[3, 4, 4];
            lb29.Foreground = Brushes.DarkSlateBlue; lb29.FontSize = 16;

            Label lb41 = new Label();
            lb41.Margin = new Thickness(1000, 310, 0, 0);
            lb41.HorizontalAlignment = HorizontalAlignment.Left;
            lb41.VerticalAlignment = VerticalAlignment.Top;
            lb41.Content = tab[3, 5, 0] + "," + tab[3, 5, 1] + "," + tab[3, 5, 2] + "," + tab[3, 5, 3] + "|" + tab[3, 5, 4];
            lb41.Foreground = Brushes.DarkSlateBlue; lb41.FontSize = 16;

            Label lb25 = new Label();
            lb25.Margin = new Thickness(1190, 310, 0, 0);
            lb25.HorizontalAlignment = HorizontalAlignment.Left;
            lb25.VerticalAlignment = VerticalAlignment.Top;
            lb25.Content = tab[3, 6, 0] + "," + tab[3, 6, 1] + "," + tab[3, 6, 2] + "," + tab[3, 6, 3] + "|" + tab[3, 6, 4];
            lb25.Foreground = Brushes.DarkSlateBlue; lb25.FontSize = 16;

            // Add it to Stack Children
            grd.Children.Add(rec);
            grd.Children.Add(sep1); grd.Children.Add(sep2); grd.Children.Add(sep3);
            grd.Children.Add(sep4); grd.Children.Add(sep5); grd.Children.Add(sep6);
            grd.Children.Add(sep7); grd.Children.Add(sep8); grd.Children.Add(sep9);
            grd.Children.Add(sep10); grd.Children.Add(sep11); grd.Children.Add(sep12);
            grd.Children.Add(sep13);

            grd.Children.Add(lb1); grd.Children.Add(lb2); grd.Children.Add(lb3);
            grd.Children.Add(lb4); grd.Children.Add(lb5); grd.Children.Add(lb6);
            grd.Children.Add(lb7); grd.Children.Add(lb8); grd.Children.Add(lb9);
            grd.Children.Add(lb10); grd.Children.Add(lb11); grd.Children.Add(lb12);
            grd.Children.Add(lb13); grd.Children.Add(lb14); grd.Children.Add(lb15);
            grd.Children.Add(lb16); grd.Children.Add(lb17); grd.Children.Add(lb18);
            grd.Children.Add(lb19); grd.Children.Add(lb20); grd.Children.Add(lb21);
            grd.Children.Add(lb22); grd.Children.Add(lb23); grd.Children.Add(lb24);
            grd.Children.Add(lb25); grd.Children.Add(lb26); grd.Children.Add(lb27);
            grd.Children.Add(lb28); grd.Children.Add(lb29); grd.Children.Add(lb30);
            grd.Children.Add(lb31); grd.Children.Add(lb32); grd.Children.Add(lb33);
            grd.Children.Add(lb34); grd.Children.Add(lb35); grd.Children.Add(lb36);
            grd.Children.Add(lb37); grd.Children.Add(lb38); grd.Children.Add(lb39);
            grd.Children.Add(lb40); grd.Children.Add(lb41);

            stack.Children.Add(grd);
        }

        // This clears the stackpanel
        public void clear()
        {
            stack.Children.Clear();
        }

        // This adds the statement of solution to the stackpanel
        public void statement(string val) {
            Label stat = new Label();
            stat.Margin = new Thickness(7, 20, 0, 20);
            stat.HorizontalAlignment = HorizontalAlignment.Left;
            stat.VerticalAlignment = VerticalAlignment.Top;
            stat.Content = "The Statement of the Result is\n"+val;
            stat.Foreground = Brushes.DarkSlateBlue; stat.FontSize = 16;

            stack.Children.Add(stat);
        }

    }
}