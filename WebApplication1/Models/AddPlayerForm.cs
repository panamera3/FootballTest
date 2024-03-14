using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class AddPlayerForm
    {

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required]
        public uint TeamID { get; set; }

        [Required]
        public Country Country { get; set; }

        public string NewTeamName { get; set; }

	}
}
