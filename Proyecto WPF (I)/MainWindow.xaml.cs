using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto_WPF__I_
{
    public partial class MainWindow : Window
    {
        Partida partida;
        Pelicula pelicula;
        ObservableCollection<Pelicula> peliculas;

        public MainWindow()
        {
            pelicula = new Pelicula();
            peliculas = new ObservableCollection<Pelicula>();
            partida = Partida.CreaPlaceholder();
            InitializeComponent();

            jugarTabItem.DataContext = partida;
            gestionarTabItem.DataContext = pelicula;
            peliculasListBox.ItemsSource = peliculas;
            generoComboBox.ItemsSource = Enum.GetValues(typeof(Pelicula.Genero));
        }

        #region Jugar
        private void nuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            if (peliculas.Count >= 5)
            {
                partida = Partida.CreaPartida(new List<Pelicula>(peliculas));
                jugarTabItem.DataContext = partida;
            }
            else
            {
                MessageBox.Show("Necesitas al menos 5 películas", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void validarButton_Click(object sender, RoutedEventArgs e)
        {
            bool validacion = partida.Valida(respuestaTextBox.Text);
            MessageBox.Show(validacion ? "Acertaste" : "No acertaste", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void cambiarPelicula_Click(object sender, RoutedEventArgs e)
        {
                partida.Indice += int.Parse((sender as Button).Tag.ToString());
        }
        #endregion

        #region Gestionar
        private void añadirButton_Click(object sender, RoutedEventArgs e)
        {
            if (pelicula.Titulo == default)
            {
                MessageBox.Show("Falta el nombre de la película", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (pelicula.Imagen == default)
            {
                MessageBox.Show("Falta la imagen", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (pelicula.Pista == default)
            {
                MessageBox.Show("Falta la pista de la película", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                peliculas.Add(new Pelicula(pelicula));
                pelicula = new Pelicula();
                gestionarTabItem.DataContext = pelicula;
                MessageBox.Show("La película se añadio correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (peliculasListBox.SelectedItem != null)
            {
                peliculas.Remove(peliculasListBox.SelectedItem as Pelicula);
                pelicula = new Pelicula();
                gestionarTabItem.DataContext = pelicula;
                MessageBox.Show("La película se elimino correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cargarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialogo = new OpenFileDialog();
                dialogo.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                if (dialogo.ShowDialog() == true)
                {
                    peliculas.Clear();
                    foreach (Pelicula item in JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(File.ReadAllText(dialogo.FileName)))
                    {
                        peliculas.Add(item);
                    }
                    MessageBox.Show("Tus películas se cargaron correctamente", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("No se pudo cargar el fichero", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sucedio un error inesperado: " + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dialogo = new SaveFileDialog();
                dialogo.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                if (dialogo.ShowDialog() == true)
                {
                    using (StreamWriter stream = new StreamWriter(dialogo.OpenFile()))
                    {
                        stream.Write(JsonConvert.SerializeObject(peliculas));
                    }
                    MessageBox.Show("Tus películas se guardaron correctamente", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("No se pudo guardar el fichero", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sucedio un error inesperado: " + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void examinarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialogo = new OpenFileDialog();
                if (dialogo.ShowDialog() == true)
                {
                    pelicula.Imagen = dialogo.FileName;
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("No se pudo cargar la imagen", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sucedio un error inesperado: " + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void peliculasListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            pelicula = (Pelicula)peliculasListBox.SelectedItem;
            gestionarTabItem.DataContext = pelicula;
        }

        #endregion

    }
}
