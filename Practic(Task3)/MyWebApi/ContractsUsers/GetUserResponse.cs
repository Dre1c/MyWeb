namespace MyWebApi.Contracts
{
    public class GetUserResponse
    {
        public int UsersId { get; set; }
        public string Name { get; set; } = null!;
        public string Pasword { get; set; } = null!;
    }
}
