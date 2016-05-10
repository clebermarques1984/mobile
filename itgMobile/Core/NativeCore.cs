using Xamarin.Forms;

namespace Mobile.Core
{
    public static class NativeCore
    {
        public static Service.ICore Especifico
        {
            get
            {
                return DependencyService.Get<Service.ICore>();
            }
        }
    }
}
