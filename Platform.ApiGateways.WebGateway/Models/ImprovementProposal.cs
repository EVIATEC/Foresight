namespace Platform.ApiGateways.WebGateway.Models
{
    public class ImprovementProposal
    {
        public string topic_Arbeitsplatz { get; set; }
        public string topic_Unfallschutz { get; set; }
        public string topic_Werkstoffe { get; set; }
        public string topic_Energie { get; set; }
        public string topic_Betriebsmittel { get; set; }
        public string topic_Verwaltung { get; set; }
        public string topic_Verpackung { get; set; }
        public string topic_Sonstiges { get; set; }

        public string Topic_Text { get; set; }

        public string name { get; set; }

        public string date { get; set; }

        public string department { get; set; }

        public string personalNumber { get; set; }

        public string problemDescription { get; set; }

        public string problemSource { get; set; }

        public string solution { get; set; }

        public string effect { get; set; }

        public string whocanhelp { get; set; }

        public string advantage { get; set; }

        public string patent { get; set; }

        public string group { get; set; }

        public string groupPersons { get; set; }

    }
}
