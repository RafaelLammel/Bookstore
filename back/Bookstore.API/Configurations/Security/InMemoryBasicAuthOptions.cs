namespace Bookstore.API.Configurations.Security
{
    internal class InMemoryBasicAuthOptions
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
