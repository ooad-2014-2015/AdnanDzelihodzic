using DAL;
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

namespace PrimjerRFID
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Baza baza = new Baza();
        public MainWindow()
        {
            InitializeComponent();
            //pokretanje čitača kartica
            RFID citac = new RFID();  
        }
        private void btnUcitaj_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource uposlenikViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uposlenikViewSource")));
            uposlenikViewSource.Source = baza.Uposlenici.ToList();
        }
    }
}
