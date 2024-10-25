//using DL;
//using Pod.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Serialization;

//namespace BL.Controllers
//{
//    public class CategoryController
//    {
//        private Serializer serializer = new Serializer();

//        private List<Category> currentCategories;
//        private List<Feed> currentFeeds;

//        public void CreateCategory(string name)
//        {
//            Category category = new Category(name);
//            serializer.SerializeCategory(category);
//        }

//        public void DeleteCategory(string categoryName)
//        {
//            currentCategories = serializer.DeserializeCategory();

//            currentCategories.RemoveAll(x => x.Name == categoryName);

//            serializer.DeleteAllCategories();
           

//            foreach (Category category in currentCategories)
//            {
//                serializer.SerializeCategory(category);
//            }
//        }

//        public void EditCategory(string oldName, string newName)
//        {
//            DeleteCategory(oldName);
//            CreateCategory(newName);

//            currentFeeds = serializer.Deserialize();

//            foreach (Feed feed in currentFeeds)
//            {
//                if (feed.Category == oldName)
//                {

//                    feed.Category = newName;

//                }
//            }

//            serializer.Serialize(currentFeeds);



//        }

//        public List<Category> GetCategories()
//        {
//            return serializer.DeserializeCategory();
//        }

//        public bool DoesCategoryExist(string categoryName)
//        {
//            bool exists = false;

//            foreach (Category category in GetCategories())
//            {
//                if (category.Name == categoryName)
//                {

//                    exists = true;
//                    break;

//                }
//            }
//            return exists;
//        }

//    }
//}
//}
