using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activites_TP.Models
{
    public class Vote
    {
        public string Participant { get; set; }
        public string Activite { get; set; }

        public Vote()
        {

        }

        public Vote(string participant, string activite)
        {
            Participant = participant;
            Activite = activite;
        }
    }
   
}
