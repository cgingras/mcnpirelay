namespace NpiRelay
{
    public class PageInfo : MedCompli.Common.Contracts.PageInfo
    {
    }

    public static class PageInfoExtensions
    {
        public static bool IsPageNumberValid(this PageInfo pageInfo)
        {
            return MedCompli.Common.Extensions.PageInfoExtensions.IsPageNumberValid(pageInfo);
        }

        public static bool IsPageSizeValid(this PageInfo pageInfo)
        {
            return MedCompli.Common.Extensions.PageInfoExtensions.IsPageSizeValid(pageInfo);
        }
    }
}
