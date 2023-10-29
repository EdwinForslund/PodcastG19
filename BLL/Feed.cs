
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using PodcastAppG19.DAL;

namespace PodcastAppG19.BLL
{
    [DataContract]
    public class Feed
    {

      //  private Serializer serializer;
        private NewSerailzer se; 
        public string namn { get; set; }

        public string url { get; set; }

        public DateTime uppdatera { get; set; }

        public int uppdateringsfrekvens { get; set; }

        public Category category { get; set; }


        private RepositoryFeed repositoryFeed;

        public Feed(string namn, string url, int frekvens, Category category)
        {

            se = new NewSerailzer();
          //  serializer = new Serializer();
            this.namn = namn;
            this.url = url;
            uppdateringsfrekvens = 10;
            this.category = category;
            uppdateringsfrekvens = frekvens;
            repositoryFeed = new RepositoryFeed();
            getEpisodes();


        }

        public Feed()
        {
            // Tom
        }



        public string DisplayInfo()
        {
            Console.WriteLine("The following link will be opened:");
            return "Namn: " + namn + ", URL: " + url + ", Update Frequency: " + uppdateringsfrekvens + "\n\n";
        }

        

        public async Task<string> GetFeedTitleAsync()
        {
            try
            {
                string title = await repositoryFeed.GetFeedTitleAsync(this.url);
                return title;
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public int getEpisodeNumber()
        {

            int EpisodeNumber = episodes.Count();//repositoryFeed.ItemCounter(this.url);
            return EpisodeNumber;

        }

        public void getEpisodes()
        {
            episodes = repositoryFeed.GetEpisodes(this.url);
        }


        public void FeedSerailizer(List<Feed> feeds)
        {
            se.SerializeFeedfodcast(feeds);
        }

        public List<Episode> episodes { get; set; } = new List<Episode>();

        public void AddEpisode(string namn, string beskrivning)
        {
            episodes.Add(new Episode(namn, beskrivning));
        }

    }
}
