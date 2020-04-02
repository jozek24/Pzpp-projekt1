using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;

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
        /// Returns RssChannel list from dataBase.
        /// </summary>
        /// <returns></returns>
        public List<RssChannel> GetChannels()
        {
            var rssChannel = _articlesStorage.LoadRecords<RssChannel>("RssChannel");

            return rssChannel;
        }

        public static string HtmlToArticlesText(string articlesHtml)
        {
            if (string.IsNullOrEmpty(articlesHtml))
                return "";

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(articlesHtml);

            var resultText = "";
            if (htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-lead']/text()") != null)
            {
                resultText += htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-lead']/text()").InnerText
                    .Trim();
            }

            if (htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-lead no-img']/text()") != null)
            {
                resultText += htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-lead no-img']/text()").InnerText
                    .Trim();
            }

            if (htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-body bbtext']/text()") != null)
            {
                resultText += htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-body bbtext']/text()")
                 .InnerText.Trim();
            }

            if (String.IsNullOrEmpty(resultText))
                resultText = "Could not find any text.";

            return resultText;

        }
    }
}
