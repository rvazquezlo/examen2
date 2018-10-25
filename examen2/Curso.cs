using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace examen2 {
  class Curso {
    public int idCurso;
    public String nombre;
    public int horas;

    public Curso() {

    }

    public Curso(int id, String nombre, int horas) {
      this.idCurso = id;
      this.nombre = nombre;
      this.horas = horas;
    }

    public int altaCurso(String nombre, int horas, int idEstado) {
      int agregado, id;
      SqlCommand comando;
      SqlConnection conexion;
      SqlDataReader lector;

      try {
        conexion = Conexion.agregarConexion();
        comando = new SqlCommand("select max(idCurso) from curso", conexion);
        lector = comando.ExecuteReader();
        try//este try catch se utiliza en caso de que no hayan cursos.
        {
          lector.Read();
          id = lector.GetInt32(0) + 1;

        }
        catch (Exception ex) {
          id = 1; //El primer curso
        }
        lector.Close();
        comando = new SqlCommand(String.Format
            ("insert into curso (idCurso, nombre, horas, idEdo) values({0}, '{1}', {2}, {3})",id, nombre, horas, idEstado), conexion);
        agregado = comando.ExecuteNonQuery();
        conexion.Close();//se cierra por seguridad
      }
      catch (Exception ex) {
        agregado = 0;
        MessageBox.Show("error en agrega curso: " + ex);
      }

      return agregado;
    }

    public int modificaHoras(int idCurso, int horas) {
      int modificado;
      SqlCommand comando;
      SqlConnection conexion;

      try {
        conexion = Conexion.agregarConexion();
        comando = new SqlCommand(String.Format
            ("update curso set horas = {0} where idCurso = {1}", horas, idCurso), conexion);
        modificado = comando.ExecuteNonQuery();
        conexion.Close();//se cierra por seguridad
      }
      catch (Exception ex) {
        modificado = 0;
        MessageBox.Show("error en modifica curso: " + ex);
      }


      return modificado;
    }

    public List<Curso> encuentraCursosPorEstado(int idEstado) {
      List<Curso> cursos;
      Curso curso;
      SqlCommand comando;
      SqlConnection conexion;
      SqlDataReader lector;

      cursos = new List<Curso>();
      try {
        conexion = Conexion.agregarConexion();
        comando = new SqlCommand(String.Format("select idCurso, nombre, horas from curso where idEdo = {0}", idEstado), conexion);
        lector = comando.ExecuteReader();
        while (lector.Read()) {
          curso = new Curso(lector.GetInt32(0), lector.GetString(1), lector.GetInt32(2));
          cursos.Add(curso);
        }
        lector.Close();
        conexion.Close();//se cierra por seguridad
      }
      catch (Exception ex) {
        MessageBox.Show("error en busca cursos: " + ex);
      }
      return cursos;
    }


  }
}
