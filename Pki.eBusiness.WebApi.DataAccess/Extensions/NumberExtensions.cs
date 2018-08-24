namespace Pki.eBusiness.WebApi.DataAccess.Extensions
{
    public static class NumberExtensions
    {
        public static decimal ToDecimal(this double? a)
        {
            return (decimal) (a ?? 0.0d);
        }
    }
}