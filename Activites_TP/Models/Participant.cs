using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activites_TP.Models
{
    public class Participant
    {
        public int id { get; set; }
        public string nom_participant { get; set; }
        public string adresse_participant { get; set; }
        public int id_activite { get; set; }

        public Participant()
        {

        }

        public Participant(int id, string nom_participant, string adresse_participant, int id_activite)
        {
            this.id = id;
            this.nom_participant = nom_participant;
            this.adresse_participant = adresse_participant;
            this.id_activite = id_activite;
        }
        public Participant(string nom_participant, string adresse_participant, int id_activite)
        {

            this.nom_participant = nom_participant;
            this.adresse_participant = adresse_participant;
            this.id_activite = id_activite;
        }
    }

}
