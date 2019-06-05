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

        public bool ValidUKPostcode()
        {
            var ukPostcodePattern = "^([A-Z]{1,2})([0-9][0-9A-Z]?) ([0-9])([ABDEFGHJLNPQRSTUWXYZ]{2})$";
            var ukPostRegex = new Regex(ukPostcodePattern, RegexOptions.IgnoreCase);

            if (ukPostRegex.IsMatch(Postcode))
            {
                return true;
            }

            else return false;
        }
    }
}
