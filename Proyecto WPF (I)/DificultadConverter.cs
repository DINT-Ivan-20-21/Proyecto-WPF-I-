using System;
using System.Globalization;
using System.Windows.Data;

namespace Proyecto_WPF__I_
{
    class DificultadConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Pelicula.Dificultad dificultad = (Pelicula.Dificultad)Enum.Parse(typeof(Pelicula.Dificultad), value.ToString());
            return int.Parse(parameter.ToString()) == (int)dificultad;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.GetValues(typeof(Pelicula.Dificultad)).GetValue(int.Parse(parameter.ToString()));
        }
    }
}
