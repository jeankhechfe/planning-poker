namespace planningpoker.Utils
{
    public class StringUtils
    {
        public static bool isStringNotEmpty(string s)
        {
            if (s != null && !s.Equals("") && !s.Trim().Equals(""))
                return true;
            else
                return false;
        }
    }
}