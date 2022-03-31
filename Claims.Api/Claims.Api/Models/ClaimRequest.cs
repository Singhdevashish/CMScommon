namespace Claim.Api.Models
{
    public class ClaimRequest
    {
        public string ClaimId { get; set; }

        public int MemberId { get; set; }

        public int PolicyId { get; set; }

        public float ClaimAmount { get; set; }

        public string ClaimStatus { get; set; }
    }
}
