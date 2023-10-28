using PodcastAppG19.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PodcastAppG19.DAL
{
 
        public class EpisodeRepository : FeedIFRepository<Episode>
        {
            List<Episode> lista = new List<Episode>();

            public void insert(Episode episode)
            {
                lista.Add(episode);
            }

            public List<Episode> GetAll()
            {
                return lista;
            }

        void FeedIFRepository<Episode>.delete(Episode t)
        {
            throw new NotImplementedException();
        }

        List<Episode> FeedIFRepository<Episode>.GetAll()
        {
            throw new NotImplementedException();
        }

      
      

        int FeedIFRepository<Episode>.ItemCounter(string t)
        {
            throw new NotImplementedException();
        }

       

        void FeedIFRepository<Episode>.update(Episode t)
        {
            throw new NotImplementedException();
        }

        void FeedIFRepository<Episode>.Save()
        {
            throw new NotImplementedException();
        }
    }

    }


