public class movieItem
{
    public int id { get; set; }
    public string title { get; set; }
    public string description{ get; set; }
    public int actorId { get; set; }
    public int genreId { get; set; }
    public double rentalCharge { get; set; }
    public DateTime releaseDate { get; set; }
    public string imagePath { get; set; }
    public bool isAvailable { get; set; }
}