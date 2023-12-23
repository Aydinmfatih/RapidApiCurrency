namespace RapidApiCurrency.Models
{

    public class HistoricalCurrencyViewModel
    {
        public string start_date { get; set; }
        public string _base { get; set; }
        public bool success { get; set; }
        public string end_date { get; set; }
        public bool timeseries { get; set; }
        public Dictionary<string, Values> rates { get; set; }
    }

    public class Values
    {
 
        public int EUR { get; set; }
        public float TRY { get; set; }
        public float USD { get; set; }

    }
}
