using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Proyecto_WPF__I_
{
    class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = null;

            Pelicula.Dificultad dificultad = (Pelicula.Dificultad)Enum.Parse(typeof(Pelicula.Dificultad), value.ToString());
            switch (dificultad)
            {
                case Pelicula.Dificultad.Facil:
                    brush = new SolidColorBrush(Colors.PaleGreen);
                    break;
                case Pelicula.Dificultad.Medio:
                    brush = new SolidColorBrush(Colors.LemonChiffon);
                    break;
                case Pelicula.Dificultad.Díficil:
                    brush = new SolidColorBrush(Colors.IndianRed);
                    break;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
