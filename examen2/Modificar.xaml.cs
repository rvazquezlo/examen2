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
  /// Lógica de interacción para Modificar.xaml
  /// </summary>
  public partial class Modificar : Window {
    public Modificar() {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      Conexion.llenarComboIds(cbIds);
    }

    private void btModificar_Click(object sender, RoutedEventArgs e) {
      Curso curso;

      try {
        curso = new Curso();
        if (curso.modificaHoras(cbIds.SelectedIndex, int.Parse(txtHoras.Text)) == 1)
          MessageBox.Show("modificacion exitosa");
        else
          MessageBox.Show("modificacion fallida");
      }
      catch (Exception ex) {
        MessageBox.Show("error: " + ex);
      }
    }

    private void btRegistra_Click(object sender, RoutedEventArgs e) {
      MainWindow ventana = new MainWindow();
      this.Close();
      ventana.Show();
    }

    private void btReportes_Click(object sender, RoutedEventArgs e) {
      Reporte ventana = new Reporte();
      this.Close();
      ventana.Show();
    }
  }
}
