using SegundoParcialVictorPalma.BLL;
using SegundoParcialVictorPalma.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SegundoParcialVictorPalma.UI.Registro
{
    /// <summary>
    /// Interaction logic for rRegistro.xaml
    /// </summary>
    public partial class rProyecto : Window
    {
        private Proyectos Proyecto = new Proyectos();
        Tareas tarea;
        public rProyecto()
        {
            InitializeComponent();

            this.DataContext = Proyecto;
            //Llenamos TipoTareaComboBox
            TipoTareaComboBox.ItemsSource = TareasBLL.GetTareas();
            TipoTareaComboBox.SelectedValuePath = "Tareas";
            TipoTareaComboBox.DisplayMemberPath = "TipoTarea";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyecto = ProyectosBLL.Buscar(int.Parse(ProyectoIdTextBox.Text));
            Cargar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            var detalle = new ProyectoDetalle
            {
                ProyectoId = int.Parse(ProyectoIdTextBox.Text),
                TipoId = tarea.TareaId,
                Tarea = tarea,
                Requerimiento = RequerimientoTextBox.Text,
                TiempoMinutos = int.Parse(TiempoTextBox.Text)
            };

            Cargar();
            Proyecto.ProyectoDetalles.Add(detalle);
            TipoTareaComboBox.SelectedIndex = -1;
            RequerimientoTextBox.Clear();
            TiempoTextBox.Clear();
            RequerimientoTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.SelectedIndex < 0)
                return;

            Proyecto.ProyectoDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);

            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Guardar(Proyecto))
            {
                Limpiar();
                MessageBox.Show("Guardado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Eliminar(int.Parse(ProyectoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TipoTareaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tarea = ((Tareas)TipoTareaComboBox.SelectedItem);
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Proyecto;
        }

        public void Limpiar()
        {
            this.Proyecto = new Proyectos();
            this.DataContext = Proyecto;
            
        }

        
    }
}
