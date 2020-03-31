using MediaReviewer.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaReviewer.ViewModel
{
    class MediaReviewerVM : BindableBase
    {
        private ObservableCollection<RssChannel> _rssChannels = new ObservableCollection<RssChannel>();


        public ObservableCollection<RssChannel> RssChannels
        {

            get => _rssChannels;
            set
            {
                SetProperty(ref _rssChannels, value);

            }
        }
        private List<RssChannel> _rssChannelsList = new List<RssChannel>();
        public List<RssChannel> RssChannelsList
        {

            get => _rssChannelsList;
            set
            {
                SetProperty(ref _rssChannelsList, value);

            }

        }
        public ICommand RefreschCommand
        {
            get;
        }
        public MediaReviewerVM()
        {
            RefreschCommand = new DelegateCommand(RefreschListOfChannels);
          
        }

        private void RefreschListOfChannels()
        {
            RssChannels.Clear();
            RssChannelsList.Clear();
            var articlesHelper = new ArticlesHelper("NowaBaza");
            
            RssChannelsList = articlesHelper.GetChannels();
            foreach (var item in RssChannelsList)
            {
                RssChannels.Add(item);
            }
          
        }

    }
}
