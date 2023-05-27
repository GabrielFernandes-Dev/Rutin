using System.Globalization;

namespace Rutin.Converters;

public class BooleanToNotificacaoMarginConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Verifica se o valor é um booleano
        if (value is bool isExpanded)
        {
            return isExpanded ? new Thickness(12, -40, 0, 0) : new Thickness(11, -8, 0, 0);
        }

        // Se o valor não for um booleano, retorna o tamanho padrão
        return 75;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Não precisamos converter de volta neste caso, então simplesmente lança uma exceção
        throw new NotImplementedException();
    }
}
