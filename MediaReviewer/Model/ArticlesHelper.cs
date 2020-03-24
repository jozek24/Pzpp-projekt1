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
        public List<RssChannel> GetChannels()
        {
            var rssChannel = _articlesStorage.LoadRecords<RssChannel>("RssChannel");

            return rssChannel;
        }
    }
}
