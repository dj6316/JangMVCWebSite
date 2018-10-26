using JangMVCWebSite.Models.CommonParam;
using System;
using System.Web.Mvc;

namespace JangMVCWebSite.Controllers.Master
{
    public class AbstractMaster : ViewMasterPage<CommonParam>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}