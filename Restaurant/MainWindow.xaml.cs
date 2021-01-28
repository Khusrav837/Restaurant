using Restaurant.Moels;
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

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //TODO: Please use meaningful name for your variables.
        Employee em = new Employee();
        //TODO: You don;t need to create new instance of ChickenOrder or EggOrder in this class.
        ChickenOrder ch;
        EggOrder egg;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var q = int.Parse(qtity.Text);
                if (Chiken.IsChecked == true)
                {
                    ch = (ChickenOrder)em.NewRequest(q, "chiken");
                    var r = em.Inspect(ch);
                    Results.Items.Add(r);
                }
                else
                {
                    egg = (EggOrder)em.NewRequest(q);
                    var r = em.Inspect(egg);
                    Results.Items.Add(r);
                    eggq.Content = "Egg quality: " + r;

                }
            }
            catch (Exception th)
            {
                Results.Items.Add(th.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var o = em.CopyRequest();
                var r = em.Inspect(o);
                Results.Items.Add(r);
            }
            catch (Exception th)
            {
                Results.Items.Add(th.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Chiken.IsChecked == true)
                {
                    var r = em.PrepareFood(ch);
                    Results.Items.Add(r);
                }
                else
                {
                    var r = em.PrepareFood(egg);
                    Results.Items.Add(r);
                }
            }
            catch (Exception th)
            {
                Results.Items.Add(th.Message);
            }
        }
    }
}
