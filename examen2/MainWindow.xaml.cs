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

namespace examen2 {
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void Registro_Loaded(object sender, RoutedEventArgs e) {
      Conexion.llenarComboEstados(cbEstado);

    }

    private void btRegistra_Click(object sender, RoutedEventArgs e) {
      Curso curso;

      try {
        curso = new examen2.Curso();
        if (curso.altaCurso(txtNombre.Text, int.Parse(txtHoras.Text), cbEstado.SelectedIndex) == 1)
          MessageBox.Show("alta exitosa");
        else
          MessageBox.Show("alta fallida");
      }
      catch(Exception ex) {
        MessageBox.Show("error: " + ex);
      }
    }

    private void btModificar_Click(object sender, RoutedEventArgs e) {
      Modificar ventana = new Modificar();
      this.Hide();
      ventana.Show();
    }

    private void btReportes_Click(object sender, RoutedEventArgs e) {
      Reporte ventana = new Reporte();
      this.Hide();
      ventana.Show();
    }
  }
}
