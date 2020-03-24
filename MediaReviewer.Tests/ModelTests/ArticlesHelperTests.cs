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
            storage.Setup(s => s.LoadRecords<RssChannel>("RssChannel"))
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

            var articlesHelper = new ArticlesHelper("databaseName",storage.Object);

            //Act
            var result = articlesHelper.GetChannels();

            //Assert
            Assert.That(result.First().Articles.First().Title, Is.EqualTo("a"));
        }
    }
}

