using Policy.Models;
using System;
using System.Collections.Generic;

namespace Policy.Data
{
    public class PolicyData
    {

        public static List<HealthPolicy> healthPoliciesList = new List<HealthPolicy>()
       {
           new HealthPolicy()
           {
              PolicyId = 1,
              PolicyName = "Jeevan Sathi",
              HospitalId = 1,
              PremiumAmount = 10000.0,
              Tenure = 2
           },
           new HealthPolicy()
           {
              PolicyId = 2,
              PolicyName = "Yojna",
              HospitalId = 2,
              PremiumAmount = 40000.0,
              Tenure = 2
           },
           new HealthPolicy()
           {
              PolicyId = 3,
              PolicyName = "Yojna",
              HospitalId = 1,
              PremiumAmount = 40000.0,
              Tenure = 2
           },
           new HealthPolicy()
           {
              PolicyId = 4,
              PolicyName = "Yojna",
              HospitalId = 2,
              PremiumAmount = 40000.0,
              Tenure = 2
           }
       };


        public static List<ProviderPolicy> providerPoliciesList = new List<ProviderPolicy>()
        {
            new ProviderPolicy()
            {
                HospitalId = 1,
                HospitalName = "AIIMS",
                Location = "Delhi"
            },
            new ProviderPolicy()
            {
                HospitalId = 2,
                HospitalName = "Apollo",
                Location = "Mumbai"
            }
        };


        public static List<MemberPolicy> memberPoliciesList = new List<MemberPolicy>()
        {
            new MemberPolicy
            {
                MemberId =1,
                Name = "Devashish",
                PolicyId = 1,
                HospitalId = 1,
                HospitalName = "AIIMS",
                Location = "Delhi",
                SubscriptionDate = new DateTime(2022,1,1)
            },
            new MemberPolicy
            {
                MemberId =2,
                Name = "Devashish",
                PolicyId = 2,
                HospitalId = 2,
                HospitalName = "Apollo",
                Location = "Mumbai",
                SubscriptionDate = new DateTime(2022,1,1)
            },
            new MemberPolicy
            {
                MemberId =3,
                Name = "Devashish",
                PolicyId = 3,
                HospitalId = 2,
                HospitalName = "Apollo",
                Location = "Mumbai",
                SubscriptionDate = new DateTime(2022,1,1)
            },
            new MemberPolicy
            {
                MemberId =4,
                Name = "Devashish",
                PolicyId = 4,
                HospitalId = 1,
                HospitalName = "AIIMS",
                Location = "Delhi",
                SubscriptionDate = new DateTime(2022,1,1),
            }
        };
    }
}
