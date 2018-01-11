namespace DagensNamnApp
{
    public partial class MainPage
    {
        public class Rootobject
        {
            public string cachetid { get; set; }
            public string version { get; set; }
            public string uri { get; set; }
            public string startdatum { get; set; }
            public string slutdatum { get; set; }
            public Dagar[] dagar { get; set; }
        }

    }
}
