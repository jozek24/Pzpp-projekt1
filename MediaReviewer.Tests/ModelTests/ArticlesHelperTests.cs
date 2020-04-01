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

        [Test]
        public void GetChannels_InHtmlWasLeadAndBodyText_HtmlToOnlyTextString()
        {
            _storage.Setup(s => s.LoadRecords<RssChannel>("RssChannel"))
                .Returns(new List<RssChannel>
                {new RssChannel()
                    {
                        Articles = new List<Article>()
                        {
                            new Article()
                            {
                                Title = "a",
                                Text = HtmlString.HtmlLeadAndBody
                            }
                        },

                    }
                });

            var articlesHelper = new ArticlesHelper("databaseName", _storage.Object);

            var result = articlesHelper.GetChannels();

            Assert.That(result.First().Articles.First().Text, Is.EqualTo("Text in news-lead class"+ Environment.NewLine +"Text in news-body class."));
        }

        [Test]
        public void GetChannels_InHtmlWasOnlyLeadText_HtmlToOnlyLeadString()
        {
            _storage.Setup(s => s.LoadRecords<RssChannel>("RssChannel"))
                .Returns(new List<RssChannel>
                {new RssChannel()
                    {
                        Articles = new List<Article>()
                        {
                            new Article()
                            {
                                Title = "a",
                                Text = HtmlString.HtmlArticlesLead
                            }
                        },

                    }
                });

            var articlesHelper = new ArticlesHelper("databaseName", _storage.Object);

            var result = articlesHelper.GetChannels();

            Assert.That(result.First().Articles.First().Text, Is.EqualTo("Text in news-lead class"));

        }

        [Test]
        public void GetChannels_InHtmlWasOnlyArticlesBodyText_HtmlToOnlyBodyString()
        {
            _storage.Setup(s => s.LoadRecords<RssChannel>("RssChannel"))
                .Returns(new List<RssChannel>
                {new RssChannel()
                    {
                        Articles = new List<Article>()
                        {
                            new Article()
                            {
                                Title = "a",
                                Text = HtmlString.HtmlArticlesBody
                            }
                        },

                    }
                });

            var articlesHelper = new ArticlesHelper("databaseName", _storage.Object);

            var result = articlesHelper.GetChannels();

            Assert.That(result.First().Articles.First().Text, Is.EqualTo("Text in news-body class."));

        }

        [Test]
        public void GetChannels_CouldNotFoundArticlesText_HtmlsToInformationString()
        {
            _storage.Setup(s => s.LoadRecords<RssChannel>("RssChannel"))
                .Returns(new List<RssChannel>
                {new RssChannel()
                    {
                        Articles = new List<Article>()
                        {
                            new Article()
                            {
                                Title = "a",
                                Text = HtmlString.HtmlNoLeadAndBody
                            }
                        },

                    }
                });

            var articlesHelper = new ArticlesHelper("databaseName", _storage.Object);

            var result = articlesHelper.GetChannels();

            Assert.That(result.First().Articles.First().Text, Is.EqualTo("Could not find any text."));
        }


    }
}

