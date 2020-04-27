namespace BE
{
    using System.Collections.Generic;

    public interface ICRUD<T>
    {
        bool Add(T obj);

        List<T> Get();

        bool Delete(T obj);

        bool Update(T obj);
    }
}
