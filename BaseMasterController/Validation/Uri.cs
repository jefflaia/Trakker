using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;

namespace Trakker.Core
{
    public class UriAttribute : ValidationAttribute
    {
        public UriAttribute() : base()
        {}

        public override bool IsValid(object uri)
        {
            return Regex.IsMatch(uri.ToString(), @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");           
        }

    }
}
