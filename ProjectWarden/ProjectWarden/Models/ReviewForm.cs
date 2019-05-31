using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
