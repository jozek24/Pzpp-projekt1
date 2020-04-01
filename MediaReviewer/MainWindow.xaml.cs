using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MediaReviewer.Model;
using MediaReviewer.ViewModel;

namespace MediaReviewer
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public List<Article> ArticlesList = new List<Article>();
        public List<RssChannel> ChannelsList = new List<RssChannel>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MediaReviewerVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChannelsList.Clear();
            TitleView.Children.Clear();
            var articlesHelper = new ArticlesHelper("NowaBaza");
            ChannelsList =  articlesHelper.GetChannels();
            for (int i = 0; i < ChannelsList.Count; i++)
            {
                System.Windows.Controls.Button newBtnCh = new Button();
                newBtnCh.Name = "ButtonChannel" + i.ToString();
                newBtnCh.Content = i + 1 + ". " + ChannelsList[i].Title;
                newBtnCh.Click += ChannelButtons;
                
                TitleView.Children.Add(newBtnCh);
            }
        }


        private void ChannelButtons(object sender, RoutedEventArgs e)
        {     
            Button b = (Button)sender;
            string count = b.Content.ToString();
            string[] count1 = count.Split(new char[] { '.' });
            count = count1[0];
            int chanNum = 0;

            Int32.TryParse(count, out chanNum);
            ArtView.Children.Clear();
            
            for (int i = 0; i < ChannelsList[chanNum - 1].Articles.Count; i++)
            {
                ArticlesList = ChannelsList[chanNum - 1].Articles;
                System.Windows.Controls.Button newBtnArt = new Button();
                newBtnArt.Name = "buttonArticle" + i.ToString();
                newBtnArt.Content = i + 1 + ". " + ArticlesList[i].Title;
                newBtnArt.Click += ArticleButton;
                ArtView.Children.Add(newBtnArt);
                
            }

        }

        private void ArticleButton(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string count = b.Content.ToString();
            string[] count1 = count.Split(new char[] { '.' });
            count = count1[0];
            int artNum = 0;
            Int32.TryParse(count, out artNum);

            MessageBox.Show(artNum.ToString());
            List<String> CategoryList = new List<string>(ArticlesList[artNum - 1].Category);

            ArticleBody.Text = ArticlesList[artNum - 1].HTML;
           // Stopka.Content = "Publication Date: " + ArticlesList[artNum - 1].PubDate;
            foreach (var item in CategoryList)
            {
                //CategoryView.Items.Add(item);
            }
            foreach (var item in CategoryList)
            {
                //CategoryListing.Items.Add(item);
            }

        }
        public void selectArticleByCategory()
        {
            string category;
            //category = CategoryListing.SelectedItem.ToString();
           
        }
    }

}
