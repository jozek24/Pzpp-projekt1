using System.Collections.Generic;

namespace MediaReviewer.Model
{
    public class ArticlesHelper
    {
        private readonly IArticlesStorage _articlesStorage;
        public ArticlesHelper(string databaseName, IArticlesStorage articlesStorage = null)
        {
            _articlesStorage = articlesStorage ?? new ArticlesStorage(databaseName);
        }

        public List<RootObject> GetArticles()
        {
            var rootObject = _articlesStorage.LoadRecords<RootObject>("RootObject");

            return rootObject;
        }
    }
}
