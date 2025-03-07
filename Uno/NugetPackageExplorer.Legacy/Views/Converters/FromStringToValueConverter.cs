﻿using Microsoft.UI.Xaml.Data;

namespace NupkgExplorer.Views.Converters
{
    public partial class FromStringToValueConverter : IValueConverter
    {
        public enum CheckMethod { IsNullOrEmpty, IsNullOrWhitespace }


        public CheckMethod Check { get; set; }

        public object TrueValue { get; set; } = null!;

        public object FalseValue { get; set; } = null!;

        public object Convert(object value, Type targetType, object parameter, string language) =>
            !(value is string text) || (Check == CheckMethod.IsNullOrEmpty ? string.IsNullOrEmpty(text) : string.IsNullOrWhiteSpace(text))
                ? TrueValue
                : FalseValue;

        public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotSupportedException("Only one-way conversion is supported.");
    }
}
