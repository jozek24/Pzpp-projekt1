using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MediaReviewer.Model
{
    public class ArticlesHelper
    {
        private IArticlesStorage _articlesStorage;
        public ArticlesHelper(string databaseName, IArticlesStorage articlesStorage = null)
        {
            _articlesStorage = articlesStorage ?? new ArticlesStorage(databaseName);
        }

        public List<RootObject> GetArticles()
        {
            var rootObject =  _articlesStorage.LoadRecords<RootObject>("RootObject");

            return rootObject;
        }
    }
}
