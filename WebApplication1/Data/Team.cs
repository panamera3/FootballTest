using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class Team
    {
		[Key]
		public uint ID { get; set; }

        public string Name { get; set; }
    }
}
