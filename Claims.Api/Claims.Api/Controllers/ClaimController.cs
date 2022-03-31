using Microsoft.AspNetCore.Mvc;
using Claim.Api.Repository;
using Claim.Api.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Claim.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimController : ControllerBase
    {
        private IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpPost("CreateClaimRequest")]
        public async Task<IActionResult> CreateClaimRequest([FromBody] ClaimRequest claimRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _claimService.CreateClaimRequest(claimRequest);
                    return Ok(response);
                }
                catch (System.Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
        
        [HttpGet("GetAllClaimRequests")]
        public async Task<IActionResult> GetAllClaimRequests()
        {
            try
            {
                var claimRequests = await _claimService.GetAllClaimRequests();

                if (claimRequests == null) return NotFound();

                return Ok(claimRequests);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpGet("GetAllProccessedClaimedRequests")]
        public async Task<IActionResult> GetAllProccessedClaimedRequests()
        {
            try
            {
                var processedClaimRequests = await _claimService.GetAllProccessedClaimedRequests();

                if (processedClaimRequests == null) return NotFound();

                return Ok(processedClaimRequests);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        
        [HttpGet]
        [Route("GetClaimsRequestedByMember/{memberId}")]
        public async Task<IActionResult> GetClaimsRequestedByMember(int memberId)
        {
            try
            {
                var claimRequestsByMember = await _claimService.GetClaimsRequestedByMember(memberId);

                if (claimRequestsByMember == null) return NotFound();

                return Ok(claimRequestsByMember);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetClaimsRequestedByClaimId/{claimId}")]
        public async Task<IActionResult> GetClaimsRequestedByClaimId(string claimId)
        {
            try
            {
                var claimRequestsByClaimId = await _claimService.GetClaimsRequestedByClaimId(claimId);

                if (claimRequestsByClaimId == null) return NotFound();
                

                return Ok(claimRequestsByClaimId.First());
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetProccessedClaimRequestsOfMember/{memberId}")]
        public async Task<IActionResult> GetProccessedClaimRequestsOfMember(int memberId)
        {
            try
            {
                var processedClaimRequestsByMember = await _claimService.GetProccessedClaimRequestsOfMember(memberId);

                if (processedClaimRequestsByMember == null) return NotFound();

                return Ok(processedClaimRequestsByMember);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("EditClaimRequest")]
        public async Task<IActionResult> EditClaimRequest([FromBody] ClaimRequest claimRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _claimService.EditClaimRequest(claimRequest);
                    return Ok(response);
                }
                catch (System.Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
