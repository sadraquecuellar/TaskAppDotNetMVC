namespace TasksWebAPP.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        //  string?  atributo pode ser nulo
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}