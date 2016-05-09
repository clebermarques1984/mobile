using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itgMobile.Core;
using Xamarin.Forms;

namespace itgMobile.Core
{
    public static class ItgWebService
    {
        public static Service.ICore itgEspecifico
        {
            get
            {
                return DependencyService.Get<Service.ICore>();
            }
        }
    }
}
