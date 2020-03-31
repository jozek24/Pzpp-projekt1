﻿using MediaReviewer.Model;
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


        public ICommand RefreschCommand
        {
            get;
        }
        public MediaReviewerVM()
        {
            RefreschCommand = new DelegateCommand(RefreschListOfChannels);
            AddArticleCommand = new DelegateCommand<RssChannel>(AddArticleButton);


        }

        private void AddArticleButton(RssChannel rssChannel )
        {
            Articles.Clear();
            foreach (var item in rssChannel.Articles)
            {
                Articles.Add(item);
            }
        }

        private void RefreschListOfChannels()
        {
          List<RssChannel>rssChannelsList = new List<RssChannel>();
          RssChannels.Clear();
            
            var articlesHelper = new ArticlesHelper("NowaBaza");

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