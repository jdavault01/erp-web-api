namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
{
    public static class NumberExtensions
    {
        public static decimal ToDecimal(this double? a)
        {
            return (decimal) (a ?? 0.0d);
        }
    }
}