using CommonLib;

namespace MathsLib
{
    public class SecurityCheck
    {
        public void CheckLogin(string username, string password)
        {
            // Abstract reference pointing to concrete implementation
            LoginAbs loginAbs = new MathsLogin();

            // Common login flow
            if (loginAbs.LoginProcess())
            {
                loginAbs.Login(username, password);
            }
        }

        public void CheckLogout()
        {
            LoginAbs loginAbs = new MathsLogin();
            loginAbs.Logout();
        }
    }
}
