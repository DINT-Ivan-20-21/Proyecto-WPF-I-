using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Proyecto_WPF__I_
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pelicula> peliculas;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void LeePeliculasJSON(string path)
        {
            peliculas = JsonConvert.DeserializeObject<List<Pelicula>>(File.ReadAllText(path));
        }

        public void EscribePeliculasJSON(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(peliculas));
        }
    }
}
