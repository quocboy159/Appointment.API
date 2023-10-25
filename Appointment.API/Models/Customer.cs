namespace Appointment.API.Models
{
    public class Customer
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
