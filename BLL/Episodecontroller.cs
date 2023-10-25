using PodcastAppG19.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastAppG19.BLL
{
    public class Episodecontroller
    {

        EpisodeRepository episodeRepository;
        public Episodecontroller()
        {
            episodeRepository = new EpisodeRepository();
        }


        public List<Episode> GetAllEpisodes()
        {
            return episodeRepository.GetAll();
        }


        public void CreateEpisode(string title, string summary)
        {
            Episode episode = new Episode(title, summary);
            episodeRepository.insert(episode);
        }






    }
}
