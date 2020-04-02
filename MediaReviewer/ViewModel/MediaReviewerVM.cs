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
        public int count;


        public ObservableCollection<RssChannel> RssChannels
        {

            get => _rssChannels;
            set
            {
                SetProperty(ref _rssChannels, value);

            }
        }

        private ObservableCollection<Article> _article = new ObservableCollection<Article>();
        public ObservableCollection<Article> Articles
        {
            get => _article;
            set
            {
                SetProperty(ref _article, value);
            }
        }
        private string _htmlText;
        public string HtmlText
        {
            get => _htmlText;

            set
            {
                SetProperty(ref _htmlText, value);
            }
        }
        private Article _selectedArticle;
        public Article SelectedArticle
        {
            get => _selectedArticle;
            set
            {
                SetProperty(ref _selectedArticle, value);
                DisplayArticleText();

            }
        }



        public ICommand RefreschCommand
        {
            get;
        }
        public ICommand ShowTextCommand
        {
            get;
        }



        public MediaReviewerVM()
        {
            RefreschCommand = new DelegateCommand(RefreschListOfChannels);
            AddArticleCommand = new DelegateCommand<RssChannel>(AddArticleButton);
            ShowTextCommand = new DelegateCommand(DisplayArticleText);

        }

        private void DisplayArticleText()
        {
            try
            {
                HtmlText = ArticlesHelper.HtmlToArticlesText(SelectedArticle.Text);
            }
            catch (Exception e)
            {
                HtmlText = "";
            }
        }

        private void AddArticleButton(RssChannel rssChannel)
        {
            Articles.Clear();
            foreach (var item in rssChannel.Articles)
            {
                Articles.Add(item);
            }
        }

        private void RefreschListOfChannels()
        {
            List<RssChannel> rssChannelsList = new List<RssChannel>();
            RssChannels.Clear();

            var articlesHelper = new ArticlesHelper("ChannelsFromMedia2");

            rssChannelsList = articlesHelper.GetChannels();
            foreach (var item in rssChannelsList)
            {
                RssChannels.Add(item);
            }

        }


        public ICommand AddArticleCommand
        {
            get;
            private set;
        }

    }
}
