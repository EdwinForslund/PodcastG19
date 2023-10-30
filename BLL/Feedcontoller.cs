using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PodcastAppG19.DAL;

namespace PodcastAppG19.BLL
{
    public class Feedcontoller
    {
       
        public RepositoryFeed Feedrepos;

        public NewSerailzer newSerailzer;
       

        public   Feedcontoller()
        {
           Feedrepos = new RepositoryFeed();
            newSerailzer = new NewSerailzer();
        }

        public List<Feed> Getallapodcast()
        {
            return Feedrepos.GetAll();
        }
        public void DeleteOnCategory(Category cat)
        {
           
           Feedrepos.DeletePodcastOnCategory(cat);
        }

        public void create(Feed feed) 
        {
            Feedrepos.insert(feed);
        }

        public void UpdateFeedCategory(string oldCategory, string newCategory)
        {
            Feedrepos.UpdateFeedCategory(oldCategory, newCategory);
        }


        internal void DeleteOnCategory(string? selectedCategoryTitle)
        {
            throw new NotImplementedException();
        }
        public void DeleteFeedAndContents(Feed feed)
        {
            Feedrepos.DeleteFeedAndContents(feed);
        }


        public void UpdateFeedName(Feed feed, string newFeedName)
        {
            // Update the feed's name in your data storage (e.g., using RepositoryFeed)
            Feedrepos.UpdateFeedName(feed, newFeedName);

            // Update the feed's name in your data structures
            feed.namn = newFeedName;
        }

        public void FeedSerailizer(List<Feed> feeds)
        {
            newSerailzer.SerializeFeedfodcast(feeds);
        }

    }
}
