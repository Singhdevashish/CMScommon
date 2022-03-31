using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Models
{
    public class MemberPolicy
    {
        public int MemberId { get; set; }

        public string Name { get; set; }

        public int PolicyId { get; set; }

        public int HospitalId { get; set; }

        public string HospitalName { get; set; }

        public string Location { get; set; }

        public DateTime SubscriptionDate { get; set; }


    }
}
