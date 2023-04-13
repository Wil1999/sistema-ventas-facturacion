using SISTEMA_PUNTO_VENTAS.CONTROLADOR;
using SISTEMA_PUNTO_VENTAS.MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_PUNTO_VENTAS.LOGICA
{
    class UsuarioL
    {
        public void guardar_usuarios(UsuarioM usuario) {
            try
            {
                ConexionDB.Open();
                SqlCommand cmd = new SqlCommand("insertar_usuario", ConexionDB.connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombres", usuario.NombresApellidos);
                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.Parameters.AddWithValue("@password", usuario.Password);
                cmd.Parameters.AddWithValue("@icono", usuario.Icono);
                cmd.Parameters.AddWithValue("@icono_nombre", usuario.IconoNombre);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@estado", "ACTIVO");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                ConexionDB.Close();
            }
        }

        public void editar_usuarios(UsuarioM usuario)
        {
            try
            {
                ConexionDB.Open();
                SqlCommand cmd = new SqlCommand("editar_usuario", ConexionDB.connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@nombres", usuario.NombresApellidos);
                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.Parameters.AddWithValue("@password", usuario.Password);
                cmd.Parameters.AddWithValue("@icono", usuario.Icono);
                cmd.Parameters.AddWithValue("@icono_nombre", usuario.IconoNombre);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionDB.Close();
            }
        }

        public void eliminar_usuarios(UsuarioM usuario)
        {
            try
            {
                ConexionDB.Open();
                SqlCommand cmd = new SqlCommand("eliminar_usuario", ConexionDB.connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionDB.Close();
            }
        }
        public void mostrar_usuarios(ref DataTable dt) {
            try
            {
                ConexionDB.Open();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_usuario", ConexionDB.connect);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                ConexionDB.Close();
            }
        }

        public void buscar_usuarios(ref DataTable dt,string letra)
        {
            try
            {
                ConexionDB.Open();
                SqlDataAdapter da = new SqlDataAdapter("buscar_usuario", ConexionDB.connect);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", letra);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionDB.Close();
            }
        }
    }
}
