using PodcastAppG19.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastAppG19.DAL
{
    internal interface CatagoryIFRepository <T> where T : Category
    {

        Category GetCategoryByName(string name);
        void UpdateCategoryByName(string name, string newName);
        void DeleteCategoryByName(string name);

        void DeleteAllCategories();
        void ChangeCategory(Category category);

        public void Save();
        public List<T> GetAll();
    }
}


