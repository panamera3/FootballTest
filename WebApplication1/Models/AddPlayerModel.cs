using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class AddPlayerModel
    {
        public Player Player { get; set; }

        public List<Team> Teams { get; set; }
    }
}
