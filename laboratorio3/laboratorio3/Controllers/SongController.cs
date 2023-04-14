using laboratorio3.Models;
using Microsoft.AspNetCore.Mvc;
namespace laboratorio3.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Index()
        {
            var songs = GetListSongs();
            ViewBag.MainTitle = "Mis canciones favoritas: Jason Mrillo Madrigal";
            return View(songs);
        }
        
        private List<SongModel> GetListSongs()
        {
            List<SongModel> songs = new List<SongModel>();
            songs.Add(new SongModel
            { 
                Id = 1,
                Name = "Comfortably Numb: ",
                Genre = "Rock",
                Group = "Pink Floyd"

            });

            songs.Add(new SongModel
            {
                Id = 2,
                Name = "Thunder Road",
                Genre = "Rock",
                Group = "Bruce Springsteen & The E Street Band"

            });
            songs.Add(new SongModel
            {
                Id = 2,
                Name = "Whole Lotta Love",
                Genre = "Rock",
                Group = "Led Zeppelin"

            });
            songs.Add(new SongModel
            {
                Id = 2,
                Name = "Highway Star",
                Genre = "Rock",
                Group = "Deep Purple"

            });

            return songs; 
        }

    }
}
