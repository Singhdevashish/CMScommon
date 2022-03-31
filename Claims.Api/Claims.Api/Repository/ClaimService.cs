using Claim.Api.Models;
using Claim.Api.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claim.Api.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Claim.Api.Repository
{
    public class ClaimService : IClaimService
    {
        private ClaimDbContext _claimDbContext;

        public ClaimService(ClaimDbContext claimDbContext)
        {
            _claimDbContext = claimDbContext;
        }

        public async Task<ResponseModel> CreateClaimRequest (ClaimRequest claimRequest)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                await _claimDbContext.ClaimRequests.AddAsync(claimRequest);
                await _claimDbContext.SaveChangesAsync();
                responseModel.isSuccess = true;
                responseModel.Message = "Claim Requested Successfully";
            }
            catch (System.Exception e)
            {
                responseModel.isSuccess = false;
                responseModel.Message = $"Error Occured {e.Message}";
            }

            return responseModel;
        }

        public async Task<List<ClaimRequest>> GetAllClaimRequests()
        {
            List<ClaimRequest> claimRequests;

            try
            {
                claimRequests = await _claimDbContext.ClaimRequests.Where(claimRequest => claimRequest.ClaimStatus == "INPROCESS").ToListAsync();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }

            return claimRequests;
        }

        public async Task<List<ClaimRequest>> GetAllProccessedClaimedRequests()
        {
            List<ClaimRequest> processedClaimRequests;

            try
            {
                processedClaimRequests = await _claimDbContext.ClaimRequests.Where(claimRequest => claimRequest.ClaimStatus != "INPROCESS").ToListAsync();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }

            return processedClaimRequests;
        }

        public async Task<List<ClaimRequest>> GetClaimsRequestedByMember(int memberId)
        {
            List<ClaimRequest> claimRequestsByMember;

            try
            {
                claimRequestsByMember = await _claimDbContext.ClaimRequests.Where(claimRequest => claimRequest.ClaimStatus == "INPROCESS" && claimRequest.MemberId == memberId).ToListAsync();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }

            return claimRequestsByMember;
        }

        public async Task<List<ClaimRequest>> GetProccessedClaimRequestsOfMember(int memberId)
        {
            List<ClaimRequest> processedClaimRequestsByMember;

            try
            {
                processedClaimRequestsByMember = await _claimDbContext.ClaimRequests.Where(claimRequest => claimRequest.ClaimStatus != "INPROCESS" && claimRequest.MemberId == memberId).ToListAsync();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }

            return processedClaimRequestsByMember;
        }

        public async Task<ResponseModel> EditClaimRequest(ClaimRequest claimRequest)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                _claimDbContext.ClaimRequests.Update(claimRequest);
                await _claimDbContext.SaveChangesAsync();
                responseModel.isSuccess = true;
                responseModel.Message = "Claim Request Updated";
            }
            catch (System.Exception e)
            {
                responseModel.isSuccess = false;
                responseModel.Message = $"Error Occured {e.Message}";
            }

            return responseModel;
        }

        public async Task<List<ClaimRequest>> GetClaimsRequestedByClaimId(string claimId)
        {
            List<ClaimRequest> claimRequestsByClaim;

            try
            {
                claimRequestsByClaim = await _claimDbContext.ClaimRequests.Where(claimRequest => claimRequest.ClaimStatus == "INPROCESS" && claimRequest.ClaimId == claimId).ToListAsync();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }

            return claimRequestsByClaim;
        }
    }
}
