using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Models
{
    public class FootbalTeam
    {
        public int Id { get; set; }
        public string NameTeam { get; set; }
        public string City { get; set; }
        public int CountWon { get; set; }
        public int CountDraw { get; set; }
        public int CountLose { get; set; }
        public int CountHeadsGoals { get; set; }
        public int CountMissedGoals { get; set; }

    }
}
