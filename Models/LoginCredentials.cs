namespace QuestStore.Models
{
    public class LoginCredentials
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
