namespace API.Models
{
    public class Usuario: DAL.MongoEntity
    {
        public string email { get; set; }
        public string password { get; set; }
        public string displayName { get; set; }
        public bool isActive { get; set; }
    }

}
     