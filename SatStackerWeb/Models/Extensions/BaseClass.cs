namespace SatStackerWeb.Models.Extensions
{
    /*
         * base class for general attributes (CRUD)
         */
    public class BaseClass
    {
        public BaseClass()
        {
            Create = DateTime.Now;
        }

        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public DateTime? Delete { get; set; }
    }
}
