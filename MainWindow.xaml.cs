using SegundoParcialVictorPalma.UI.Consultas;
using SegundoParcialVictorPalma.UI.Registro;
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

namespace SegundoParcialVictorPalma
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProyecto rRegistro = new rProyecto();
            rRegistro.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ConsultaProyecto consultaRegistro = new ConsultaProyecto();
            consultaRegistro.Show();
        }
    }
}
