using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakker.Infastructure.UI
{
    public static class JQueryDatePickerFormatTranslator
    {
        private static IDictionary<string, string> _monthFormats = new Dictionary<string, string>
        {
            {"MMMM", "MM"},
            {"MMM", "MM"},
            {"MM", "mm"},
            {"M", "m"}
        };

        private static IDictionary<string, string> _dayFormats = new Dictionary<string, string>
        {
            {"dddd", "DD"},
            {"ddd", "D"}
        };

        private static IDictionary<string, string> _yearFormats = new Dictionary<string, string>
        {
            {"yyyy", "yy"},
            {"yy", "y"}
        };


        public static string Translate(string formating)
        {
            formating = Convert(ref formating, _monthFormats);
            formating = Convert(ref formating, _dayFormats);
            formating = Convert(ref formating, _yearFormats);


            return formating;
            
        }

        private static string Convert(ref string format, IDictionary<string, string> formatMaps)
        {

            //TODO:: update this to deal with mutliple formats in the same string. This will only work if we construct date formats that actually make sense
            // Example this will not work correctly: ddd M dddd
            // the dddd will not be changed
            foreach (KeyValuePair<string, string> map in formatMaps)
            {
                if (format.Contains(map.Key))
                {
                    format = format.Replace(map.Key, map.Value);
                    break;
                }
            }

            return format;
        }
    }
}
