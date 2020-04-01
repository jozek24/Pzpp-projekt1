using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaReviewer.ViewModel
{
    public class Article
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public string HTML { get; set; }

        public List<string> Category { get; set; }

        public string PubDate { get; set; }


        public Article()
        {
            Title = "Tytuł do artykułu";
            HTML = "Może na tle innych tytułów taki wynik nie robi wrażenia, ale musicie wiedzieć, że ostatni taki rezultat War Thunder osiągnął… na przełomie 2014 i 2015 roku.Kto by się spodziewał, że po takim czasie w War Thunder znowu zaroi się od graczy? Ale to chyba dobrze.War Thunder, jak mało kto, zasługuje na taką popularność.Gierka posiada chyba najlepsze „samoloty MMO” na świecie. Czołgowy tryb(Ground Forces) też stoi na bardzo wysokim poziomie, który może się równać z World of Tanks.No to co? Zapraszamy do gry.Kto wie, może dzisiaj padnie kolejny rekord. ";
            PubDate = "21.03.2020r";
            Category = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                Category.Add("Alfa");
                Category.Add("I coś");
            }
        }
    }
}
