using Policy.Data;
using Policy.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        readonly log4net.ILog log;

        public PolicyRepository()
        {
            log = log4net.LogManager.GetLogger(typeof(PolicyRepository));
        }
        public List<HealthPolicy> GetPolicyByPolicyId(int policyId)
        {
            List<HealthPolicy> policies;

            try
            {
                policies = PolicyData.healthPoliciesList.Where(p => p.PolicyId == policyId).ToList();
            }
            catch (System.Exception ex)
            {
                log.Info("GetPolicyByPolicyId is unsuccessful and Message: " + ex.Message);

                return null;
            }

            return policies;
        }

        public List<MemberPolicy> GiveAllMemberPolicy()
        {
            return PolicyData.memberPoliciesList;
        }

        public List<ProviderPolicy> GiveAllProviderDetail()
        {
            return PolicyData.providerPoliciesList;
        }

        public List<HealthPolicy> GiveListOfAllPolicy()
        {
            return PolicyData.healthPoliciesList;
        }

        public double GivePolicyAmount(int policyId)
        {
            foreach(var item in PolicyData.healthPoliciesList)
            {
                if (item.PolicyId == policyId)
                {
                    return item.PremiumAmount;
                }
                    
            }

            return 0;
        }

        public int ReceivePolicyId(int memberId)
        {
           
            foreach(var item in PolicyData.memberPoliciesList)
            {
                if(item.MemberId == memberId)
                {
                    int m = item.PolicyId;
                    return m;
                }
                
            }

            return 0;
        }
    }
}
