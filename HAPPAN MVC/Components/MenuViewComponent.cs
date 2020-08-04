using HAPPAN_MVC.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAPPAN_MVC.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly HAPPAN_MVC_AuthDBContext hAPPAN_MVC_AuthDBContext;
        public MenuViewComponent(HAPPAN_MVC_AuthDBContext hAPPAN_MVC_AuthDBContext)
        {
            this.hAPPAN_MVC_AuthDBContext = hAPPAN_MVC_AuthDBContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = hAPPAN_MVC_AuthDBContext.Projects.ToList();
            return await Task.FromResult((IViewComponentResult)View("Menu", model));
        }

    }

}
