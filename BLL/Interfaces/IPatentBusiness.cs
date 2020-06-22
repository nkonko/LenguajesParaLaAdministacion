namespace BLL.Interfaces
{
    using BE;
    using System.Collections.Generic;

    public interface IPatentBusiness : ICRUD<Patent>
    {
        List<Patent> GetPatentsByUser(int userId);

        List<Patent> GetPatentsByFamily(int familyId);
    }
}