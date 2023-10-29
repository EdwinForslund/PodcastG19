using PodcastAppG19.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastAppG19.BLL
{
    public class Catagorycontroller
    {
        public RepositoryCatagory Repositoryforcatagory;
          // Serializer serializeXml = new Serializer();

        public Catagorycontroller()
        {
            Repositoryforcatagory = new RepositoryCatagory();
        }
        public void UppdateKatagory(string newTitle, string oldTitle)
        {
            Repositoryforcatagory.UppdateraKategori(newTitle, oldTitle);
        }
        public void create(String name)
        {
            Category category = new Category(name);
            Repositoryforcatagory.CreateCategory(category);
        }

        public List<Category> GetallaCatagory()
        {
            return Repositoryforcatagory.GetAll();
        }

        public Category GetCategoryByName(string name)
        {
            return Repositoryforcatagory.GetCategoryByName(name);
                   }


        public void RemoveCategory(string category)
        {
            Repositoryforcatagory.DeleteCategoryByName(category);
        }

        public void removeCategorybyindex( int index)
        {
            Repositoryforcatagory.DeleteCategoryByIndex(index);
        }
        public void remove( Category category)
        {
            
            Repositoryforcatagory.removet(category);
        }
    }
}
