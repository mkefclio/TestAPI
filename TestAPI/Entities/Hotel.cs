namespace TestAPI.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StarRating { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
