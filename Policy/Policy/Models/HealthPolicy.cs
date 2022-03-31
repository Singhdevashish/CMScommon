using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Models
{
    public class HealthPolicy
    {
        public int PolicyId { get; set; }

        public string PolicyName { get; set; }

        public int HospitalId { get; set; }

        public double PremiumAmount { get; set; }

        public int Tenure { get; set; }
    }
}
