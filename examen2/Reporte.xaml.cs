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
using System.Windows.Shapes;

namespace examen2 {
  /// <summary>
  /// Lógica de interacción para Reporte.xaml
  /// </summary>
  public partial class Reporte : Window {
    public Reporte() {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      Conexion.llenarComboEstados(cbEstado);
    }

    private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      Curso curso;

      try {
        curso = new Curso();
        dgCursos.ItemsSource = curso.encuentraCursosPorEstado(cbEstado.SelectedIndex);
      }
      catch (Exception ex) {
        MessageBox.Show("error: " + ex);
      }
    }

    private void btModificar_Click(object sender, RoutedEventArgs e) {
      Modificar ventana = new Modificar();
      this.Close();
      ventana.Show();
    }

    private void btAlta_Click(object sender, RoutedEventArgs e) {
      MainWindow ventana = new MainWindow();
      this.Close();
      ventana.Show();
    }
  }
}
