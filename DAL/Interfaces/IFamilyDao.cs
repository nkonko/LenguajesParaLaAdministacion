namespace DAL.Interfaces
{
    using BE;
    using System.Collections.Generic;

    public interface IFamilyDao : ICRUD<Family>
    {
        List<Family> GetUserFamily(int id);
    }
}
