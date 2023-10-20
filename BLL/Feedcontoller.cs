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
       

      public   Feedcontoller()
        {

            
            Feedrepos = new RepositoryFeed();
            

        }

        public List<Feed> Getallapodcast()
        {
            return Feedrepos.GetAll();
        }
        public void DeleteOnCategory(Category cat)
        {
           
           Feedrepos.DeletePodcastOnCategory(cat);
        }




        public void UpdateFeedCategory(string oldCategory, string newCategory)
        {
            Feedrepos.UpdateFeedCategory(oldCategory, newCategory);
        }


        internal void DeleteOnCategory(string? selectedCategoryTitle)
        {
            throw new NotImplementedException();
        }

    }
}
