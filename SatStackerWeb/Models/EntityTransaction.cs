using SatStackerWeb.Models.Enums;
using SatStackerWeb.Models.Extensions;

namespace SatStackerWeb.Models
{
    /*
         * models a transaction for some sort of ... thing.
         * in/out
         * amount
         * etc pp
         */
    public class EntityTransaction : BaseClass
    {
        public int EntityTransactionId { get; set; }

        public TransactionType Type { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }

        public decimal ValuePerUnitinEuros { get; set; }        

    }
}
