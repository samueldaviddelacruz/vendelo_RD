namespace API.Models
{
    public class Persona: DAL.MongoEntity
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
    }

}