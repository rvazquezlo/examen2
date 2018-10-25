using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace examen2 {
  class Conexion {

    /**
        * Metodo que se utiliza para abir conexion con sql
        */
    public static SqlConnection agregarConexion() {
      SqlConnection conexion;

      try {
        conexion = new SqlConnection("Data Source=CC101-24;Initial Catalog=datosCursos;Persist Security Info=True;User ID=sa;Password=sqladmin");
        conexion.Open();
        MessageBox.Show("conectado");
      }
      catch (Exception e) {
        conexion = null;
        MessageBox.Show("no conectado" + e);
      }
      return conexion;
    }

    /**
     * Llena el combo box de los estados
     */
    public static void llenarComboEstados(ComboBox cb) {
      SqlCommand comando;
      SqlDataReader lector;
      SqlConnection conexion;

      conexion = Conexion.agregarConexion();
      try {
        comando = new SqlCommand(String.Format("select nombre from estado"), conexion);
        lector = comando.ExecuteReader();
        while (lector.Read())
          cb.Items.Add(lector["nombre"].ToString());//Lo que esta en columna nombre se mete al combo
        lector.Close();
      }
      catch (Exception e) {
        MessageBox.Show("Error. No se pudo llenar el combo " + e);
      }
      conexion.Close();//se cierra conexion por seguridad
    }

    /**
     * Llena el combo box de los estados
     */
    public static void llenarComboIds(ComboBox cb) {
      SqlCommand comando;
      SqlDataReader lector;
      SqlConnection conexion;

      conexion = Conexion.agregarConexion();
      try {
        comando = new SqlCommand(String.Format("select idCurso from curso"), conexion);
        lector = comando.ExecuteReader();
        while (lector.Read())
          cb.Items.Add(lector.GetInt32(0).ToString());
        lector.Close();
      }
      catch (Exception e) {
        MessageBox.Show("Error. No se pudo llenar el combo " + e);
      }
      conexion.Close();//se cierra conexion por seguridad
    }


  }
}
