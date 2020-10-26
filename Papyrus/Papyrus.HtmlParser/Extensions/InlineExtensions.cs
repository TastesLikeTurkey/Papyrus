﻿using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace Papyrus.HtmlParser.Extensions
{
    internal static class InlineExtensions
    {
        public static void ApplyStyle(this Inline inline, Style style)
        {
            inline.FontSize = style.FontSize.Value;
            inline.FontStyle = style.FontStyle.Value;
            inline.FontWeight = style.FontWeight.Value;
            inline.Foreground = style.Foreground != null ? new SolidColorBrush(style.Foreground.Value) : null;
            inline.TextDecorations = style.TextDecoration.Value;
        }
    }
}