namespace planningpoker.TOs
{
    public class LoginTO
    {
        public string Token{ get; set;}

        public LoginTO(string token)
        {
            this.Token = token;
        }
    }
}