using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models.Registration
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter the correct Contact numbers")]
        [StringLength(10)]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Gender has to be selected")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "The type of password should be atleast minimum 8 characters atleast contain 1 capital letter,1 small letter,1 special character ")]
        [DataType(DataType.Password)]
        [MinLength(6)]

        public string Password { get; set; }
        [DataType(DataType.Password)]

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string SecretQuestions { get; set; }

        [Required]
        public string Answer { get; set; }

    }
}
