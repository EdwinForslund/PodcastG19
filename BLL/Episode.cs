using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastAppG19.BLL
{
    internal class Episode
    {


        public string Namn { get; set; }
        public string Beskrivning { get; set; }

        public Episode(string namn, string beskrivning)
        {
            Namn = namn;
            Beskrivning = beskrivning;
        }


        public Episode()
        {
            

        }
    }
}
