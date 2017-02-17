using Abp.Web.Mvc.Views;

namespace Zz.Web.Views
{
    public abstract class ZzWebViewPageBase : ZzWebViewPageBase<dynamic>
    {

    }

    public abstract class ZzWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ZzWebViewPageBase()
        {
            LocalizationSourceName = ZzConsts.LocalizationSourceName;
        }
    }
}