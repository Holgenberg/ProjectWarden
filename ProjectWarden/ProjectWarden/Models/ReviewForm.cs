using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectWarden.Models
{
    class ReviewForm
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CityTown { get; set; }
        public string CountyRegionState { get; set; }
        public string Postcode { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public bool SadOrSmileyClicked { get; set; }

        public bool ValidUKPostcode()
        {
            var ukPostcodePattern = @"(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY]))))\s?[0-9][A-Z-[CIKMOV]]{2})";
            var ukPostRegex = new Regex(ukPostcodePattern, RegexOptions.IgnoreCase);

            if (ukPostRegex.IsMatch(Postcode))
            {
                return true;
            }

            else return false;
        }
    }
}
