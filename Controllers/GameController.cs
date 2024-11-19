using GameCRUD.RequestResponse;
using GameCRUD.Context;
using GameCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameCRUD.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private readonly GameContext _context;
        public GameController()
        {
            _context = new GameContext();
        }

        [HttpPost]
        [Route("addgame")]
        public async Task<string> AddGame(Response game)
        {
            GameEntity obj = new GameEntity()
            {
                Id = game.GameId,
                Name = game.GameName,
                Price = game.GamePrice,
            };
            _context.Games.Add(obj);
            await _context.SaveChangesAsync();
            return "Added";
        }

        [HttpGet]
        [Route("getgames")]
        public async Task<List<Response>> GetGames()
        {
            var res = await _context.Games.Select(item => new Response
            {
                GameId = item.Id,
                GameName = item.Name,
                GamePrice = item.Price
            }).ToListAsync();
            return res;
        }

        [HttpGet]
        [Route("getgamebyid")]
        public async Task<Response> GetGameById(int id)
        {
            var res = await _context.Games.Where(item => item.Id == id).Select(item => new Response
            {
                GameId = item.Id,
                GameName = item.Name,
                GamePrice = item.Price
            }).FirstOrDefaultAsync();
            return res;
        }

        [HttpDelete]
        [Route("deletegamebyid")]
        public async Task<string> DeleteGameById(int id)
        {
            var res = await _context.Games.Where(item => item.Id == id).FirstOrDefaultAsync();
            if (res != null)
            {
                _context.Games.Remove(res);
                await _context.SaveChangesAsync();
                return "Deleted";
            }
            return null;
        }

        [HttpPut]
        [Route("updategame")]
        public async Task<string> UpdateGame(int id, Response game)
        {
            var res = await _context.Games.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (res != null)
            {
                res.Name = game.GameName;
                res.Price = game.GamePrice;

                //_context.Games.AddOrUpdate(res);
                await _context.SaveChangesAsync();
                return "Updated";
            }
            return null;
        }
    }
}
