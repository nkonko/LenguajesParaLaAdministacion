namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using EasyEncryption;
    using Microsoft.AspNet.Identity.Owin;
    using System.Linq;

    public class AccountBusiness : IAccountBusiness
    {
        private readonly IUserBusiness userBusiness;
        private readonly IFamilyBusiness familyBusiness;
        private readonly IPatentBusiness patentBusiness;

        public AccountBusiness(IUserBusiness userBusiness, IFamilyBusiness familyBusiness, IPatentBusiness patentBusiness)
        {
            this.userBusiness = userBusiness;
            this.familyBusiness = familyBusiness;
            this.patentBusiness = patentBusiness;
        }

        public User LogIn(string userName, string psw)
        {
            var response = new User();

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(psw))
            {
                response.SignInStatus = SignInStatus.Failure;

                return response;
            }

            var encripted = userBusiness.GetEncriptedUser(userName);

            if (encripted.LoginAttempt <= 5)
            {
                if (encripted != null && encripted.Password == MD5.ComputeMD5Hash(psw))
                {
                    encripted.Families = familyBusiness.GetFamilies(encripted.Id);

                    var patents = patentBusiness.GetPatentsByUser(encripted.Id);

                    foreach (var family in encripted.Families)
                    {
                        var familyPatents = patentBusiness.GetPatentsByFamily(family.Id);

                        patents = patents.Union(familyPatents).ToList();
                    }

                    response.Name = encripted.Name;
                    response.UserName = userName;
                    response.Patents = patents;
                    response.Families = encripted.Families;
                    response.LoginAttempt = 0;
                    response.SignInStatus = SignInStatus.Success;

                    return response;
                }

                response.SignInStatus = SignInStatus.Failure;
                response.LoginAttempt = response.LoginAttempt + 1;

                userBusiness.Update(response);

                return response;
            }

            response = encripted;
            response.SignInStatus = SignInStatus.LockedOut;
            userBusiness.Update(response);

            return response;
        }
    }
}
