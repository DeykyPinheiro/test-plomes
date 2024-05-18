namespace PlomesApi.Models
{
    public class User
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public string Email { get; set; }

        public User() { }

        public User(int id, User data)
        {
            Id = id;
            Name = data.Name;
            Email = data.Email;
        }
    }
}
