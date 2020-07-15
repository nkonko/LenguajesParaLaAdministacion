namespace BE
{
    using BE.Interfaces;
    using Microsoft.AspNet.Identity.Owin;
    using System.Collections.Generic;

    public class User : IVerificable
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public List<Family> Families { get; set; }

        public List<Patent> Patents { get; set; }

        public SignInStatus SignInStatus { get; set; }

        public int LoginAttempt { get; set; }

        public int DVH { get; set; }

        public string GetFinalString()
        {
            return Name + Password + UserName + LoginAttempt;
        }
    }
}
