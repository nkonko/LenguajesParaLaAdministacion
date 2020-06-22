namespace DAL.Interfaces
{
    using BE;
    using System.Collections.Generic;

    public interface IPatentDao : ICRUD<Patent>
    {
        List<Patent> GetUserPatents(int id);

        List<Patent> GetFamilyPatents(int familyId);
    }
}
