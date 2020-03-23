using System.Collections.Generic;
using System.Linq;
using MediaReviewer.Model;
using Moq;
using NUnit.Framework;

namespace MediaReviewer.Tests.ModelTests
{
    [TestFixture]
    public class ArticlesHelperTests
    {
        [Test]
        public void GetArticles_WhenCalled_ReturnRootObject()
        {
            //Arrange
            var storage = new Mock<IArticlesStorage>();
            storage.Setup(s => s.LoadRecords<RootObject>("RootObject"))
                .Returns(new List<RootObject>
                {
                    new RootObject
                    {
                        Rss = new Rss
                        {
                            Channel = new Channel
                            {
                                Item = new List<Item>
                                {
                                    new Item
                                    {
                                        Title = "a",
                                        HTML = new HTML
                                        {
                                            Text = "b"
                                        },
                                        Link = "c",
                                        PubDate = "d",
                                        }
                                }
                            }
                        }
                    }
                });

            var articlesHelper = new ArticlesHelper("databaseName",storage.Object);

            //Act
            var result = articlesHelper.GetArticles();

            //Assert
            Assert.That(result.First().Rss.Channel.Item.First().Title, Is.EqualTo("a"));
        }
    }
}