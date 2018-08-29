using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(LMS_Population.Startup))]
namespace LMS_Population
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //=============================================================
        //======================== END ================================
        //============================================  ====  =========
        //======================== OF =================================
        //=============================================================
        //======================= PARSE ============  ========  =======
        //============================================        =========
        //======================= SCRIPT ==============================
        //=============================================================
    }
}
