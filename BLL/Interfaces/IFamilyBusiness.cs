namespace BLL.Interfaces
{
    using BE;
    using System.Collections.Generic;

    public interface IFamilyBusiness : ICRUD<Family>
    {
        List<Family> GetFamilies(int userId);
    }
}