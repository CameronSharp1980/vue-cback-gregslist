using System.ComponentModel.DataAnnotations;

namespace vue_cback_gregslist.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, MinLength(1)]
        public string Username { get; set; }
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4)]
        public string Password { get; set; }

        internal UserReturnModel GetReturnModel()
        {
            return new UserReturnModel()
            {
                Id = Id,
                Username = Username,
                Email = Email
            };
        }
    }
}