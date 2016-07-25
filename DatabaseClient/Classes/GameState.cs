using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient
{
    public class GameState
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Score { get; set; }
        public bool IsRunning { get; set; }
        public string LocationName { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }

    }
}
