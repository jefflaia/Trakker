using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;

namespace Trakker.Infastructure.Validation
{
    public class UriAttribute : ValidationAttribute
    {
        public UriAttribute() : base()
        {
            ErrorMessageResourceType = typeof(Resources.Validation);
            ErrorMessageResourceName = "InvalidUri";
        }

        public override bool IsValid(object uri)
        {
            return Regex.IsMatch(uri.ToString(), @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");           
        }

    }
}
