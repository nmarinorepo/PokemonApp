namespace Pokemon.Models
{
    public class Pokemon
    {
        public string name { get; set; }

        public Type[] types { get; set; }
    }

    public class Type
    {
        public Type1 type { get; set; }
    }

    public class Type1
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
