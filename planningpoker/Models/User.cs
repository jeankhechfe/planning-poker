using planningpoker.TOs;

namespace planningpoker.Models
{
    public class User
    {
        public string Id { get; set;}
        public string Login { get; set;}

        public UserTO ToTo()
        {
            var userTo = new UserTO {Login = Login};
            return userTo;
        }
    }
}