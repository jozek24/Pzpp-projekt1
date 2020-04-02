using System;
using System.Collections.Generic;
using System.Linq;
using MediaReviewer.Model;
using MediaReviewer.Tests.Resources;
using Moq;
using NUnit.Framework;

namespace MediaReviewer.Tests.ModelTests
{
    [TestFixture]
    public class ArticlesHelperTests
    {
        private Mock<IArticlesStorage> _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IArticlesStorage>();
            _storage.Setup(s => s.LoadRecords<RssChannel>("RssChannel"))
                .Returns(new List<RssChannel>
                {new RssChannel()
                    {
                        Articles = new List<Article>()
                        {
                            new Article()
                            {
                                Title = "a"
                            },
                            new Article()
                            {
                                Title = "b"
                            }
                        },

                    }
                });
        }

        [Test]
        public void GetChannels_WhenCalled_ReturnRssChannelObject()
        {
            //Arrange
            var articlesHelper = new ArticlesHelper("databaseName", _storage.Object);

            //Act
            var result = articlesHelper.GetChannels();

            //Assert
            Assert.That(result.First().Articles.First().Title, Is.EqualTo("a"));
        }

        [Test]
        public void GetChannels_WhenCalled_ReturnsAnyObject()
        {
            //Arrange
            var articlesHelper = new ArticlesHelper("databaseName", _storage.Object);

            //Act
            var result = articlesHelper.GetChannels();

            //Assert
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [TestCase(HtmlString.HtmlArticlesLead, "Text in news-lead class")]
        [TestCase(HtmlString.HtmlArticlesBody, "Text in news-body class.")]
        [TestCase(HtmlString.HtmlNoLeadAndBody, "Could not find any text.")]
        [TestCase(HtmlString.HtmlClassNewsLeadNoImg, "Could not find any text.")]
        public void HtmlToArticlesText_WhenCalled_ChangesHtmlToProperString(string htmlText,string value)
        {
            var result = ArticlesHelper.HtmlToArticlesText(htmlText);

            Assert.That(result, Does.Contain(value).IgnoreCase);
        }
    }
}

