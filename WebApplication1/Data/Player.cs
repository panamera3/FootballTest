using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class Player
    {
		[Key]
		public uint ID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public DateOnly BirthDate { get; set; }

        public Country Country { get; set; }

		[ForeignKey(nameof(Team))]
		public uint TeamID { get; set; }

		public Team Team { get; set; }
	}
}
