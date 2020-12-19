using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_WPF__I_
{
    class Partida : INotifyPropertyChanged
    {
        public int numeroPeliculas { get => Peliculas.Count; }

        private ObservableCollection<Pelicula> Peliculas { get; }

        private int _puntos;
        public int Puntos
        {
            get => _puntos;
            set
            {
                _puntos = value;
                this.NotifyPropertyChanged("Puntos");

            }
        }

        private int _indice;
        public int Indice
        {
            get => _indice;
            set
            {
                if (value <= numeroPeliculas && value >= 1)
                {
                    _indice = value;
                    PeliculaActual = Peliculas[_indice - 1];
                    this.NotifyPropertyChanged("Indice");
                }
            }
        }

        private Pelicula _peliculaActual;
        public Pelicula PeliculaActual
        {
            get => _peliculaActual;
            set
            {
                _peliculaActual = value;
                this.NotifyPropertyChanged("PeliculaActual");
            }
        }
        private Partida(ObservableCollection<Pelicula> peliculas)
        {
            Peliculas = peliculas;
            Indice = 1;
            Puntos = 0;
        }

        public bool Valida(string respuesta)
        {
            PeliculaActual.EstaValidada = PeliculaActual.Titulo.ToLower() == respuesta.ToLower();

            if (PeliculaActual.EstaValidada)
            {
                Action<object> cuenta = (object cantidad) =>
                    {
                        int total = Puntos + (int)cantidad;
                        while (Puntos <= total)
                        {
                            Puntos += 5;
                            Thread.Sleep(100);
                        }
                    };
                Task t1 = new Task(cuenta, PeliculaActual.CalculaPuntos());
                t1.Start();
            }

            return PeliculaActual.EstaValidada;
        }

        public static Partida CreaPartida(List<Pelicula> peliculas)
        {
            Random rnd = new Random();
            ObservableCollection<Pelicula> peliculasAleatorias = new ObservableCollection<Pelicula>();
            for (int i = 0; i < 5; i++)
            {
                int indice = rnd.Next(0, peliculas.Count);
                peliculasAleatorias.Add(new Pelicula(peliculas[indice]));
                peliculas.RemoveAt(indice);
            }

            return new Partida(peliculasAleatorias);
        }

        public static Partida CreaPlaceholder()
        {
            ObservableCollection<Pelicula> ejemplo = new ObservableCollection<Pelicula>();
            Pelicula pelicula = new Pelicula();
            pelicula.Imagen = "assets/placeholder.bmp";
            pelicula.EstaValidada = true;
            ejemplo.Add(pelicula);
            return new Partida(ejemplo);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
