using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastAppG19.BLL
{

    public class Category
    {

        public string Title{ get; set; }

        public Category(string name)
        {
            Title = name;
        }

        public Category()
        {
            
        }

        public void changeTitle(string newTitle) 
        {
            Title = newTitle;
        }
    }
}
