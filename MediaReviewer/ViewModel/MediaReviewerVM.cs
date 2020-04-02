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
        private int _defaultArticle;
        public int DefaultArticle
        {
            get => _defaultArticle;
            set => SetProperty(ref _defaultArticle, value);

        }
        private string _publicationDate;
        
        public string PublicationDate
        {
            get => _publicationDate;

            set => SetProperty(ref _publicationDate, value);
        }
        private string _countOfCannals;
        public string CountOfCannals
        {
            get => _countOfCannals;
            set => SetProperty(ref _countOfCannals, value);
        }

        public ICommand RefreschCommand
        {
            get;
        }
        
        public ICommand ShowTextCommand
        {
            get;
        }
       public ICommand NextArticleCommand
        {
            get;
        }
        public ICommand PreviousArticleCommand
        {
            get;
        }


        public MediaReviewerVM()
        {
            RefreschCommand = new DelegateCommand(RefreschListOfChannels);
            AddArticleCommand = new DelegateCommand<RssChannel>(AddArticleButton);
            ShowTextCommand = new DelegateCommand(DisplayArticleText);
            NextArticleCommand = new DelegateCommand(DisplayNextArticle);
            PreviousArticleCommand = new DelegateCommand(DisplayPreviousArticle);
        }

        private void DisplayNextArticle()
        {
            if (DefaultArticle != Articles.Count -1)          
            SelectedArticle = Articles[DefaultArticle + 1];
        }
        private void DisplayPreviousArticle()
        {
            if(DefaultArticle != 0)
                SelectedArticle = Articles[DefaultArticle - 1];

        }

        private void DisplayArticleText()
        {
            try
            {

                HtmlText = ArticlesHelper.HtmlToArticlesText(SelectedArticle.Text);
                PublicationDate = "Publication date: " + SelectedArticle.PubDate;
            }
            catch (Exception e)
            {
                HtmlText = "";
            }
        }
        

        private void AddArticleButton(RssChannel rssChannel )
        {
            Articles.Clear();
            foreach (var item in rssChannel.Articles)
            {
                Articles.Add(item);
            }
            DefaultArticle = 0;
            


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
            CountOfCannals = "Number of Cannals: " + RssChannels.Count.ToString();
        }


        public ICommand AddArticleCommand
        {
            get;
            private set;
        }

    }
}
