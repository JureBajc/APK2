namespace APKtest.Models
{

    public class Metrolog
    {
        public int Id { get; set; }
        public string Ime { get; set; } = null!;
        public string Priimek { get; set; } = null!;
        public DateTime Datum_Zaposlitve { get; set; }
        public ICollection<MeritveA> Meritve { get; set; } = new List<MeritveA>();
    }
}