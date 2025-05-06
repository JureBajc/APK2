namespace APKtest.Models{ 

public class Merilna_Naprava
{
    public int Id { get; set; }
    public string Ime { get; set; } = null!;
    public float Zemljepisna_Dolzina { get; set; }
    public float Zempljepisna_Sirina { get; set; }

    public ICollection<MeritveA> MeritveA { get; set; } = new List<MeritveA>();
}
}