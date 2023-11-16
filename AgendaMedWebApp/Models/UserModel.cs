using AgendaMedWebApp.Business.Genericos;

namespace AgendaMedWebApp.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public long Pessoa { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public AccessType AccessType { get; set; }

        public UserModel()
        {

        }

        public UserModel(User usuario)
        {
            Id = usuario.Id;
            Pessoa = usuario.Pessoa;
            Password = usuario.Password;
            Login = usuario.Login; 
        }

        public User GetUser()
        {
            return new User()
            {
                Id = Id,
                Pessoa = Pessoa,
                Password = Password,
                Login = Login,

            };
        }
    }
}
