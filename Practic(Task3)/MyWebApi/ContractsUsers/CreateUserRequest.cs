namespace MyWebApi.Contracts
{
    public class CreateUserRequest
    {
        public string UsersName { get; set; } = null!;
        public string Pasword { get; set; } = null!;
        public DateTime AddedTime { get; set; }
        public int AddedBy { get; set; }



    }
}
