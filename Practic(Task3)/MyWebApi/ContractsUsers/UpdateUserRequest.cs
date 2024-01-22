namespace MyWebApi.Contracts
{
    public class UpdateUserRequest
    {
        public string Name { get; set; } = null!;
        public string Pasword { get; set; } = null!;
        public DateTime AddedTime { get; set; }
        public int AddedBy { get; set; }
    }
}
