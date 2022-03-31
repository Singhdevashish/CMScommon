using Claim.Api.Models;
using Claim.Api.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Claim.Api.Repository
{
    public interface IClaimService
    {
        Task<ResponseModel> CreateClaimRequest(ClaimRequest claimRequest);

        Task<List<ClaimRequest>> GetAllClaimRequests();

        Task<List<ClaimRequest>> GetAllProccessedClaimedRequests();

        Task<List<ClaimRequest>> GetClaimsRequestedByMember(int memberId);

        Task<List<ClaimRequest>> GetClaimsRequestedByClaimId(string claimId);

        Task<List<ClaimRequest>> GetProccessedClaimRequestsOfMember(int memberId);
        
        Task<ResponseModel> EditClaimRequest(ClaimRequest claimRequest);
    }
}
