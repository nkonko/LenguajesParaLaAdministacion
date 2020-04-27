namespace BE
{
    using System.Collections.Generic;

    public class Family
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public List<Patent> Patent { get; set; }
    }
}
