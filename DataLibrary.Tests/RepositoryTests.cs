using DataLibrary.Interfaces;
using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataLibrary.Tests
{
    public class RepositoryTests
    {
        private IRepository _repository = new Repository();
        private IJSONDataAccess _jSONDataAccess = new JSONDataAccess();
        private IMongoCRUD _mongoCRUD = new MongoCRUD("NowaBaza");

        [Theory]
        [InlineData("rssChannels")]
        public void AddNewRssChannels_InValid(string param)
        {
            Assert.Throws<ArgumentException>(param, () => _repository.AddNewRssChannels(new List<Model.RssChannel>()));
        }
    }
}
