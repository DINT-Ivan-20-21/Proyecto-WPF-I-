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
            Ciencia_Ficción
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
