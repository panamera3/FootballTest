using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PlayersController : Controller
    {
        private readonly DataContext _dataContext;

        public PlayersController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var players = _dataContext.Players
                .Include(x => x.Team)
                .ToList();

            return View(players);
        }

        private AddPlayerModel GetAddPlayer()
        {
            return new AddPlayerModel
            {
                Teams = _dataContext.Teams.ToList()
            };
        }

        [HttpGet]
        public IActionResult AddPlayer()
        {
            var viewModel = GetAddPlayer();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddPlayer(AddPlayerForm model)
        {
            if (ModelState.IsValid)
            {
                var player = new Player
                {
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    TeamID = model.TeamID,
                    Country = model.Country
                };

                _dataContext.Players.Add(player);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            if(model.TeamID == 0)
            {
                var newTeam = new Team
                {
                    Name = model.NewTeamName
                };

				_dataContext.Teams.Add(newTeam);
				_dataContext.SaveChanges();

				var player = new Player
				{
					LastName = model.LastName,
					FirstName = model.FirstName,
					Gender = model.Gender,
					BirthDate = model.BirthDate,
					TeamID = newTeam.ID,
					Country = model.Country
				};

				_dataContext.Players.Add(player);
				_dataContext.SaveChanges();
				return RedirectToAction("Index");
			}

            return View(GetAddPlayer());
        }

        private EditPlayerModel GetEditPlayer(Player player)
        {
            return new EditPlayerModel
            {
                Teams = _dataContext.Teams.ToList(),
                Player = player
            };
        }

        [HttpGet]
        public IActionResult EditPlayer(uint playerID)
        {
            var player = _dataContext.Players.FirstOrDefault(x => x.ID == playerID);

            if (player == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = GetEditPlayer(player);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditPlayer(EditPlayerForm model)
        {
            var player = _dataContext.Players.FirstOrDefault(x => x.ID == model.ID);

            if (player == null)
            {
                return RedirectToAction("Index");
            }

			if (ModelState.IsValid)
            {
                player.LastName = model.LastName;
                player.FirstName = model.FirstName;
                player.Gender = model.Gender;
                player.BirthDate = model.BirthDate;
                player.TeamID = model.TeamID;
                player.Country = model.Country;

                _dataContext.Players.Update(player);
                _dataContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(GetEditPlayer(player));
        }

		public IActionResult RemovePlayer(int playerId)
		{
			var player = _dataContext.Players.FirstOrDefault(x => x.ID == playerId);

			if (player != null)
			{
				_dataContext.Players.Remove(player);
				_dataContext.SaveChanges();
			}

			return RedirectToAction("Index");
		}
	}
}
