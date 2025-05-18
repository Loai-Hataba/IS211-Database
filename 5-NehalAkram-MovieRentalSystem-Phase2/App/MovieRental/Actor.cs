public class Actor
{
    public int actorId { get; set; }
    public string firstName;
    public string lastName;
    public bool gender;
    public string bio; 
    public string fullName => $"{firstName} {lastName}";
}