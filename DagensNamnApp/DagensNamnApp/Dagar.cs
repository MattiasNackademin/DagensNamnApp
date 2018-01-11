namespace DagensNamnApp
{
    public partial class MainPage
    {
        public class Dagar
        {
            public string datum { get; set; }
            public string veckodag { get; set; }
            public string arbetsfridag { get; set; }
            public string röddag { get; set; }
            public string vecka { get; set; }
            public string dagivecka { get; set; }
            public string[] namnsdag { get; set; }
            public string flaggdag { get; set; }
        }

    }
}
