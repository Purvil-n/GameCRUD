using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameCRUD.RequestResponse
{
    public class Response
    {
        public int GameId { get; set; } = 0; //same fieldname as StudentEntity or different like this
        public string GameName { get; set; } = string.Empty;
        public int GamePrice { get; set; } = 0;
    }
}