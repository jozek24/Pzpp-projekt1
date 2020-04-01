using System;
using System.Collections.Generic;
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
            HtmlToArticlesText(rssChannel);

            return rssChannel;
        }

        private void HtmlToArticlesText(List<RssChannel> rssChannel)
        {
            foreach (var channel in rssChannel)
            {
                foreach (var article in channel.Articles)
                {
                    if (article.Text == null)
                        continue;

                    var html = article.Text;
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    var fullText = "";
                    if (htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-lead']/text()") != null)
                    {
                        fullText += htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-lead']/text()").InnerText
                            .Trim();
                    }

                    if (htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-body bbtext']/text()") != null)
                    {
                        if (fullText != "")
                            fullText += Environment.NewLine;

                        fullText += htmlDoc.DocumentNode.SelectSingleNode("//*[@class='news-body bbtext']/text()").InnerText.Trim();
                    }

                    if (fullText == "")
                        fullText = "Could not find any text.";

                    article.Text = fullText;
                }
            }
        }
    }
}
