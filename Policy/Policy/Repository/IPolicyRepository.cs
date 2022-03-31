using Policy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Repository
{
    public interface IPolicyRepository
    {

        public List<ProviderPolicy> GiveAllProviderDetail();

        public double GivePolicyAmount(int policyId);

        public List<HealthPolicy> GiveListOfAllPolicy();

        public List<MemberPolicy> GiveAllMemberPolicy();

        public int ReceivePolicyId(int memberId);

        public List<HealthPolicy> GetPolicyByPolicyId(int policyId);


    }
}
