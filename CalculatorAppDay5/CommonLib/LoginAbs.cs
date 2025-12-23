namespace CommonLib
{
    public abstract class LoginAbs
    {
        public abstract void Login(string username, string password);   //can be overide : abstract method
        public abstract void Logout();

        public bool LoginProcess()  //can be accessed but can't override:implemented method
        {
            return true;
        }
    }
}



