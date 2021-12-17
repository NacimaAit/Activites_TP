using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activites_TP.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Nom_participant { get; set; }
        public string Adresse_participant { get; set; }
        public int Id_activite { get; set; }

        public Participant()
        {

        }

        public Participant(int id, string nom_participant, string adresse_participant, int id_activite)
        {
            Id = id;
            Nom_participant = nom_participant;
            Adresse_participant = adresse_participant;
            Id_activite = id_activite;
        }
    }

}
