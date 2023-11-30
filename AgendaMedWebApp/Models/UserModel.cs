using AgendaMedWebApp.Business.Genericos;

namespace AgendaMedWebApp.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public long Pessoa { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public IFormFile Pic { get; set; }
        public string PicName { get; set; }
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
            PicName = usuario.PicName;

            if (usuario.Pic != null)
            {
                using (var stream = new MemoryStream(usuario.Pic))
                {
                    var formFile = new FormFile(stream, 0, usuario.Pic.Length, Path.GetFileNameWithoutExtension(usuario.PicName), Path.GetExtension(usuario.PicName))
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "application/octet-stream"
                    };

                    Pic = formFile;
                }
            }
        }

        public User GetUser()
        {
            byte[] convertedPic = null;
            string convertedPicName = null;
            if (Pic != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Pic.CopyTo(memoryStream);
                    convertedPic = memoryStream.ToArray();
                    convertedPicName = Pic.FileName;
                }
            }

            return new User()
            {
                Id = Id,
                Pessoa = Pessoa,
                Password = Password,
                Login = Login,
                Pic = convertedPic,
                PicName = convertedPicName,

            };
        }
    }
}
