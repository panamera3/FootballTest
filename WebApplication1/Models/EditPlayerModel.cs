using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class EditPlayerModel
    {
        public Player Player { get; set; }

        public EditPlayerForm EditPlayerForm { get; set; }

        public List<Team> Teams { get; set; }
    }
}
