namespace BE
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Family> Family { get; set; }

        public List<Patent> Patent { get; set; }
    }
}
