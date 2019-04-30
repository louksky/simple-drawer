using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ex1Grafics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Point[] par;
        int i;
        static int NUMOFPOINTS = 4 ;
        int shapeFlag = 0; // 1 - circule , 2 - line , 3 - curve 
        public MainWindow()
        {
            InitializeComponent();


            par = new System.Windows.Point[4];
            for (int i = 0; i < par.Length; ++i) par[i] = new System.Windows.Point();

            canvas.DefaultDrawingAttributes.Color = Colors.White;
            canvas.UseCustomCursor = true;
            i = 0;
        }

        private void circule_clicked(object sender, RoutedEventArgs e)
        {
            shapeFlag = 1;
        }

        private void line_clicked(object sender, RoutedEventArgs e)
        {
           
            shapeFlag = 2;
        }

        private void curve_clicked(object sender, RoutedEventArgs e)
        {
            shapeFlag = 3;
        }

        private void preview_mousedown(object sender, MouseButtonEventArgs e)
        {
            if(shapeFlag < 3)
            {
              
                par[0] = Mouse.GetPosition(canvas); 

            }
            else
            {
               
                    if (i == 4) i = 0;
                    par[i] = Mouse.GetPosition(canvas);
                    i++;
                   
                
               
            }
        }

        private void preview_mouseup(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (shapeFlag < 3)
                {

                    par[1] = Mouse.GetPosition(canvas);

                }
                else
                {

                }
                switch (shapeFlag)
                {

                    case 1:

                        Ellipse ell = new Ellipse();
                        if (par[0].X < par[1].X)
                        {
                            ell.Width = par[1].X - par[0].X;
                            ell.Height = par[1].Y - par[0].Y;
                            InkCanvas.SetTop(ell, par[0].Y);
                            InkCanvas.SetLeft(ell, par[0].X);
                        }
                        else
                        {
                            ell.Width = par[0].X - par[1].X;
                            ell.Height = par[0].Y - par[1].Y;
                            InkCanvas.SetTop(ell, par[1].Y);
                            InkCanvas.SetLeft(ell, par[1].X);
                        }
                        ell.StrokeThickness = 4;
                        ell.Fill = System.Windows.Media.Brushes.Transparent;
                        ell.Stroke = System.Windows.Media.Brushes.LightSteelBlue;

                        canvas.Children.Add(ell);

                        break;
                    case 2:
                        Line l = new Line();

                        l.X1 = par[0].X;
                        l.Y1 = par[0].Y;
                        l.X2 = par[1].X;
                        l.Y2 = par[1].Y;

                        l.StrokeThickness = 4;
                        l.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                        canvas.Children.Add(l);
                        break;
                    case 3:
                        if (i == 4)
                        {
                           // ZeichneBezier(6,new System.Drawing.Point((int)par[0].X, (int)par[0].Y), new System.Drawing.Point((int)par[1].X, (int)par[1].Y), new System.Drawing.Point((int)par[2].X, (int)par[2].Y), e, true);
                            for (int j = 0; j < NUMOFPOINTS - 1; ++j)
                          {
                               canvas.Children.Add(nline(par[j], par[j + 1]));
                          }
                        }
                        break;
                }
                    }catch(Exception) { return; }
        }
        //private void ZeichneBezier(int n, System.Drawing.Point P1, System.Drawing.Point P2, System.Drawing.Point P3, bool initial)
        //{
        //    Graphics g = canvas.Graphics;
        //    System.Drawing.Pen bkStift = new System.Drawing.Pen(System.Drawing.Color.Red, 2);
        //    System.Drawing.Pen kpStift = new System.Drawing.Pen(System.Drawing.Color.Black, 3);

        //    if (initial)
        //    {
        //        g.DrawLine(kpStift, P1, P2);
        //        g.DrawLine(kpStift, P2, P3);
        //    }

        //    if (n > 0)
        //    {
        //        System.Drawing.Point P12 = new System.Drawing.Point((P1.X + P2.X) / 2, (P1.Y + P2.Y) / 2);
        //        System.Drawing.Point P23 = new System.Drawing.Point((P2.X + P3.X) / 2, (P2.Y + P3.Y) / 2);
        //        System.Drawing.Point P123 = new System.Drawing.Point((P12.X + P23.X) / 2, (P12.Y + P23.Y) / 2);

        //        ZeichneBezier(n - 1, P1, P12, P123, pva, false);
        //        ZeichneBezier(n - 1, P123, P23, P3, pva, false);
        //    }
        //    else
        //    {
        //        g.DrawLine(bkStift, P1, P2);
        //        g.DrawLine(bkStift, P2, P3);
        //    }
        //}

        public Line nline(System.Windows.Point p1, System.Windows.Point p2)
        {

            Line l = new Line();
            l.X1 = p1.X;
            l.Y1 = p1.Y;
            l.X2 = p2.X;
            l.Y2 = p2.Y;

            l.StrokeThickness = 4;
            l.Stroke = System.Windows.Media.Brushes.PowderBlue;
            return l; 

        }
    }
}
