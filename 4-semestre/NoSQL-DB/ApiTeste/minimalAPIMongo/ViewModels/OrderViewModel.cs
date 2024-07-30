namespace minimalAPIMongo.ViewModels
{
    public class OrderViewModel
    {
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
        public List<string>? ProductsList { get; set; }
        public string? ClientId { get; set; }
    }
}
