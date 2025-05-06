namespace APKtest.Models
{
    public class MeritveA
    {
        public int Id { get; set; }
        public DateTime Datum_Meritve { get; set; }
        public float Temperatura { get; set; }
        public float Vlažnost { get; set; }
        public string Okvara { get; set; } = null!;
        public int Merilna_NapravaId { get; set; }
        public int MetrologId { get; set; }
        public virtual Merilna_Naprava Merilna_Naprava { get; set; } = null!;
        public virtual Metrolog Metrolog { get; set; } = null!;
    }
}