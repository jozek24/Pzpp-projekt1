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

        /// <summary>
        /// Returns List of objects from dataBase
        /// </summary>
        /// <returns></returns>
        public List<Article> GetArticles()
        {
            var article = _articlesStorage.LoadRecords<Article>("Article");

            return article;
        }
    }
}
