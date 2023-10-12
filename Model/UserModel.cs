namespace CrudDTOS.Model
{
    public class UserModel
    {


        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public DateTime CreateRegistration { get; set; }
        public DateTime UpdateRegistration { get; set; }

        public UserModel(
            string name,
            string telefone,
            string email,
            string cpf,
            DateTime createRegistration,
            DateTime updateRegistration
        )
        {
            Name = name;
            Telefone = telefone;
            Email = email;
            Cpf = cpf;
            CreateRegistration = createRegistration;
            UpdateRegistration = updateRegistration;
        }

        public UserModel(
            string name,
            string email,
            string telefone
        )
        {
            Name = name;
            Email = email;
            Telefone = telefone;
        }
    }
}