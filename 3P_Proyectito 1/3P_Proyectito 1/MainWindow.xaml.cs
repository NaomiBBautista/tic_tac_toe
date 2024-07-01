//Main Window
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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media.Animation;

namespace _3P_Proyectito_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conectateSQL;
        public MainWindow()
        {
            InitializeComponent();

            string conectarseBD = ConfigurationManager.ConnectionStrings["_3P_Proyectito_1.Properties.Settings.POEV_3P_Proyectito1ConnectionString"].ConnectionString;
            conectateSQL = new SqlConnection(conectarseBD);
            MostrarContenido();
            Fade(bor, 0, 0.1);
            Fade(nvoId, 0, 0.1);
            Fade(nvoNombre, 0, 0.1);
            Fade(nvoPuntaje, 0, 0.1);
            Fade(txtId, 0, 0.1);
            Fade(txtNombre, 0, 0.1);
            Fade(txtPuntaje, 0, 0.1);
            Fade(btnActualizar, 0, 0.1);

            Fade(bor2, 0, 0.1);
            Fade(nvoId2, 0, 0.1);
            Fade(nvoNombre2, 0, 0.1);
            Fade(nvoPuntaje2, 0, 0.1);
            Fade(txtId2, 0, 0.1);
            Fade(txtNombre2, 0, 0.1);
            Fade(txtPuntaje2, 0, 0.1);
            Fade(btnActualizar2, 0, 0.1);

        }

        private void Fade(object sender, double opacity, double seconds)
        {
            switch(sender.GetType().Name) 
            {
                case "Border":
                    Border bor = (Border)sender;
                    DoubleAnimation animbor = new DoubleAnimation(opacity, TimeSpan.FromSeconds(seconds));
                    bor.BeginAnimation(Border.OpacityProperty, animbor);
                    break;

                case "Button":
                    Button but = (Button)sender;
                    DoubleAnimation animbut = new DoubleAnimation(opacity, TimeSpan.FromSeconds(seconds));
                    but.BeginAnimation(Border.OpacityProperty, animbut);
                    break;

                case "Label":
                    Label lb = (Label)sender;
                    DoubleAnimation animlb = new DoubleAnimation(opacity, TimeSpan.FromSeconds(seconds));
                    lb.BeginAnimation(Border.OpacityProperty, animlb);
                    break;

                case "TextBox":
                    TextBox txbox = (TextBox)sender;
                    DoubleAnimation animtxbox = new DoubleAnimation(opacity, TimeSpan.FromSeconds(seconds));
                    txbox.BeginAnimation(Border.OpacityProperty, animtxbox);
                    break;

                default:
                    break;
            }
        }

        private void MostrarContenido()
        {
            try
            {
                string consulta = "SELECT * FROM jugador1";
                SqlDataAdapter adaptadorSQL = new SqlDataAdapter(consulta, conectateSQL);
                using (adaptadorSQL)
                {
                    DataTable tablaUsuarios = new DataTable();
                    adaptadorSQL.Fill(tablaUsuarios);
                    losUsuarios.DisplayMemberPath = "jugador1";
                    losUsuarios.SelectedValuePath = "id";
                    losUsuarios.ItemsSource = tablaUsuarios.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string consulta = "SELECT * FROM jugador1";
                SqlDataAdapter adaptadorSQL = new SqlDataAdapter(consulta, conectateSQL);
                using (adaptadorSQL)
                {
                    DataTable tablaUsuarios = new DataTable();
                    adaptadorSQL.Fill(tablaUsuarios);
                    ptsJuga1.DisplayMemberPath = "puntos";
                    ptsJuga1.SelectedValuePath = "id";
                    ptsJuga1.ItemsSource = tablaUsuarios.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string consulta = "SELECT * FROM jugador2";
                SqlDataAdapter adaptadorSQL = new SqlDataAdapter(consulta, conectateSQL);
                using (adaptadorSQL)
                {
                    DataTable tablaUsuarios = new DataTable();
                    adaptadorSQL.Fill(tablaUsuarios);
                    losUsuarios2.DisplayMemberPath = "jugador2";
                    losUsuarios2.SelectedValuePath = "id";
                    losUsuarios2.ItemsSource = tablaUsuarios.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string consulta = "SELECT * FROM jugador2";
                SqlDataAdapter adaptadorSQL = new SqlDataAdapter(consulta, conectateSQL);
                using (adaptadorSQL)
                {
                    DataTable tablaUsuarios = new DataTable();
                    adaptadorSQL.Fill(tablaUsuarios);
                    ptsJuga2.DisplayMemberPath = "puntos";
                    ptsJuga2.SelectedValuePath = "id";
                    ptsJuga2.ItemsSource = tablaUsuarios.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "DELETE FROM jugador1 WHERE id = @elid";
            SqlCommand miComandoSQL = new SqlCommand(consulta, conectateSQL);
            conectateSQL.Open();
            miComandoSQL.Parameters.AddWithValue("@elid", losUsuarios.SelectedValue);
            miComandoSQL.ExecuteNonQuery();
            conectateSQL.Close();
            MostrarContenido();

        }

        private void btnBorrar2_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "DELETE FROM jugador2 WHERE id = @elid";
            SqlCommand miComandoSQL = new SqlCommand(consulta, conectateSQL);
            conectateSQL.Open();
            miComandoSQL.Parameters.AddWithValue("@elid", losUsuarios2.SelectedValue);
            miComandoSQL.ExecuteNonQuery();
            conectateSQL.Close();
            MostrarContenido();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "INSERT INTO jugador1 (id, jugador1, puntos) VALUES (@idusr, @nombreusr, 0)";
            SqlCommand miComandoI = new SqlCommand(consulta, conectateSQL);
            conectateSQL.Open();
            miComandoI.Parameters.AddWithValue("@idusr", idUsr.Text);
            miComandoI.Parameters.AddWithValue("@nombreusr", altUsr.Text);
            miComandoI.ExecuteNonQuery();
            conectateSQL.Close();
            MostrarContenido();
            altUsr.Text = "";
            idUsr.Text = "";
        }

        private void btnGuardar2_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "INSERT INTO jugador2 (id, jugador2,puntos) VALUES (@idusr, @nombreusr, 0)";
            SqlCommand miComandoI = new SqlCommand(consulta, conectateSQL);
            conectateSQL.Open();
            miComandoI.Parameters.AddWithValue("@idusr", idUsr1.Text);
            miComandoI.Parameters.AddWithValue("@nombreusr", altUsr2.Text);
            miComandoI.ExecuteNonQuery();
            conectateSQL.Close();
            MostrarContenido();
            altUsr.Text = "";
            idUsr.Text = "";
        }

        private void actualizarUsr_Click(object sender, RoutedEventArgs e)
        {
            Fade(bor, 100, 0.1);
            Fade(nvoId, 100, 0.1);
            Fade(nvoNombre, 100, 0.1);
            Fade(nvoPuntaje, 100, 0.1);
            Fade(txtId, 100, 0.1);
            Fade(txtNombre, 100, 0.1);
            Fade(txtPuntaje, 100, 0.1);
            Fade(btnActualizar, 100, 0.1);
           
        }

        private void actualizarUsr2_Click(object sender, RoutedEventArgs e)
        {
            Fade(bor2, 100, 0.1);
            Fade(nvoId2, 100, 0.1);
            Fade(nvoNombre2, 100, 0.1);
            Fade(nvoPuntaje2, 100, 0.1);
            Fade(txtId2, 100, 0.1);
            Fade(txtNombre2, 100, 0.1);
            Fade(txtPuntaje2, 100, 0.1);
            Fade(btnActualizar2, 100, 0.1);
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "UPDATE jugador1 SET jugador1 = @nombreusr," +
                " id = @idusr, puntos =@puntajeusr WHERE id = @elId";
            SqlCommand miCommandI = new SqlCommand(consulta, conectateSQL);
            conectateSQL.Open();
            miCommandI.Parameters.AddWithValue("@elid", losUsuarios.SelectedValue);
            miCommandI.Parameters.AddWithValue("@nombreusr", nvoNombre.Text);
            miCommandI.Parameters.AddWithValue("@idusr", nvoId.Text);
            miCommandI.Parameters.AddWithValue("@puntajeusr", nvoPuntaje.Text);
            miCommandI.ExecuteNonQuery();
            conectateSQL.Close();
            MostrarContenido();
            Fade(bor, 0, 0.1);
            Fade(nvoId, 0, 0.1);
            Fade(nvoNombre, 0, 0.1);
            Fade(nvoPuntaje, 0, 0.1);
            Fade(txtId, 0, 0.1);
            Fade(txtNombre, 0, 0.1);
            Fade(txtPuntaje, 0, 0.1);
            Fade(btnActualizar, 0, 0.1);

        }

        private void btnActualizar2_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "UPDATE jugador2 SET jugador2 = @nombreusr," +
            " id = @idusr, puntos = @puntajeusr WHERE id = @elId";
            SqlCommand miCommandI = new SqlCommand(consulta, conectateSQL);
            conectateSQL.Open();
            miCommandI.Parameters.AddWithValue("@elid", losUsuarios2.SelectedValue);
            miCommandI.Parameters.AddWithValue("@nombreusr", nvoNombre2.Text);
            miCommandI.Parameters.AddWithValue("@idusr", nvoId2.Text);
            miCommandI.Parameters.AddWithValue("@puntajeusr", nvoPuntaje2.Text);
            miCommandI.ExecuteNonQuery();
            conectateSQL.Close();
            MostrarContenido();
            Fade(bor2, 0, 0.1);
            Fade(nvoId2, 0, 0.1);
            Fade(nvoNombre2, 0, 0.1);
            Fade(nvoPuntaje2, 0, 0.1);
            Fade(txtId2, 0, 0.1);
            Fade(txtNombre2, 0, 0.1);
            Fade(txtPuntaje2, 0, 0.1);
            Fade(btnActualizar2, 0, 0.1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tic_Tac_Toe ventanaJuego = new Tic_Tac_Toe();
            ventanaJuego.Show();
        }

        
    }
}
