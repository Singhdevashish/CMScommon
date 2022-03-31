using Microsoft.AspNetCore.Mvc;
using Policy.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepository repository;
        readonly log4net.ILog log;

        public PoliciesController(IPolicyRepository repository)
        {
            this.repository = repository;
            log = log4net.LogManager.GetLogger(typeof(PoliciesController));
        }

        [HttpGet("GetAllPolicy")]
        public IActionResult GetAllPolicy()
        {
            try
            { 
                log.Info("GetAllPolicy is successful");
                var  allPolicy = repository.GiveListOfAllPolicy();

                if (allPolicy == null) return NotFound();

                return Ok(allPolicy);
            }
            catch (Exception ex)
            {
                log.Info("GetAllPolicy is unsuccessful and Message: " + ex.Message);
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("GetPolicyByPolicyId/{policyId}")]
        public IActionResult GetPolicyByPolicyId(int policyId)
        {
            try
            {
                var policyById = repository.GetPolicyByPolicyId(policyId);

                if (policyById == null) return NotFound();


                return Ok(policyById.First());
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllProviderDetails")]
        public IActionResult GetAllProviderDetails()
        {
            try
            {
                log.Info("GetAllProviderDetails is successful");

                var allProvider = repository.GiveAllProviderDetail();

                if (allProvider == null) return NotFound();

                return Ok(allProvider);
            }
            catch (Exception ex)
            {
                log.Info("GetAllProviderDetails is unsuccessful and Message:" + ex.Message);

                return BadRequest();
            }
        }

        

        [HttpGet]
        [Route("GetPolicyId/{memberId}")]
        public int GetPolicyId(int memberId)
        {
            try
            {
                log.Info("GetPolicyId is successful");
                int policyId = repository.ReceivePolicyId(memberId);
                return policyId;
            }
            catch(Exception ex)
            {
                log.Info("GetPolicyId is unsuccessful and Message: " + ex.Message);
                return 0;
            }
            
        }


        [HttpGet]
        [Route("GetEligibleClaimAmount/{policyId}")]
        public int GetEligibleClaimAmount(int policyId)
        {
            try
            {
                log.Info("GetEligibleClaimAmount is successful");
                double amount = repository.GivePolicyAmount(policyId);
                return (int)(amount);
            }
            catch (Exception ex)
            {
                log.Info("GetEligibleClaimAmount is unsuccessful and Message: " + ex.Message);
                return 0;
            }
            
        }
    }
}
