using System;
using System.Globalization;
using System.Windows.Controls;

namespace CarAuctionScraper.WPF.Validators
{
    public class UrlValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return Uri.TryCreate($"{value}", UriKind.Absolute, out var uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                ? ValidationResult.ValidResult
                : new ValidationResult(false, "Podaj poprawny url (http/https)");
        }
    }
}
