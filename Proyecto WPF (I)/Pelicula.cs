using System.ComponentModel;

namespace Proyecto_WPF__I_
{
    class Pelicula : INotifyPropertyChanged
    {
        public enum Dificultad
        {
            Facil,
            Medio,
            Díficil
        }
        public enum Genero
        {
            Comedia,
            Drama,
            Acción,
            Terror,
            CienciaFicción
        }

        private string _imagen;
        public string Imagen
        {
            get { return this._imagen; }
            set
            {
                if (this._imagen != value)
                {
                    this._imagen = value;
                    this.NotifyPropertyChanged("Imagen");
                }
            }
        }
        private string _titulo;
        public string Titulo
        {
            get { return this._titulo; }
            set
            {
                if (this._titulo != value)
                {
                    this._titulo = value;
                    this.NotifyPropertyChanged("Titulo");
                }
            }
        }
        private string _pista;
        public string Pista
        {
            get { return this._pista; }
            set
            {
                if (this._pista != value)
                {
                    this._pista = value;
                    this.NotifyPropertyChanged("Pista");
                }
            }
        }
        private Dificultad _dificultad;

        public Dificultad _Dificultad
        {
            get { return this._dificultad; }
            set
            {
                if (this._dificultad != value)
                {
                    this._dificultad = value;
                    this.NotifyPropertyChanged("_Dificultad");
                }
            }
        }

        private Genero _genero;

        public Genero _Genero
        {
            get { return this._genero; }
            set
            {
                if (this._genero != value)
                {
                    this._genero = value;
                    this.NotifyPropertyChanged("_Genero");
                }
            }
        }

        private bool _pistaMostrada;

        public bool PistaMostrada
        {
            get { return this._pistaMostrada; }
            set
            {
                if (this._pistaMostrada != value)
                {
                    this._pistaMostrada = value;
                    this.NotifyPropertyChanged("PistaMostrada");
                }
            }
        }

        private bool _estaValidada;

        public bool EstaValidada
        {
            get { return this._estaValidada; }
            set
            {
                if (this._estaValidada != value)
                {
                    this._estaValidada = value;
                    this.NotifyPropertyChanged("EstaValidada");
                }
            }
        }

        public Pelicula()
        {
            Imagen = default;
            Titulo = default;
            Pista = default;
            _Dificultad = Dificultad.Facil;
            _Genero = Genero.Comedia;
            PistaMostrada = false;
            EstaValidada = false;
        }

        public Pelicula(Pelicula pelicula)
        {
            Imagen = pelicula.Imagen;
            Titulo = pelicula.Titulo;
            Pista = pelicula.Pista;
            _Dificultad = pelicula._Dificultad;
            _Genero = pelicula._Genero;
            PistaMostrada = pelicula.PistaMostrada;
            EstaValidada = pelicula.EstaValidada;
        }

        public int CalculaPuntos()
        {
            int puntos = 0;
            switch (_Dificultad)
            {
                case Dificultad.Facil:
                    puntos = 10;
                    break;
                case Dificultad.Medio:
                    puntos = 30;
                    break;
                case Dificultad.Díficil:
                    puntos = 50;
                    break;
            }

            return PistaMostrada ? puntos / 2 : puntos;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
