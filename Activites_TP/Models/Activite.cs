using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Activites_TP.Models
{
    public class Activite
    {
        public int Id_activite { get; set; }
        public string Nom_activite { get; set; }
        public int Duree { get; set; }
        public int Cout { get; set; }
        public int Nombre_vote { get; set; }
        

        public Activite()
        {

        }

        public Activite(int id_activite, string nom_activite, int duree, int cout, int nombre_vote)
        {
            Id_activite = id_activite;
            Nom_activite = nom_activite;
            Duree = duree;
            Cout = cout;
            Nombre_vote = nombre_vote;
        }
    }
}
