using JangMVCWebSite.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JangMVCWebSite.Libs.Info.UserItem
{
    public class UserDbItem
    {
        [NameChange("intUserNum")]
        public int UserNum { get; set; }
        [NameChange("strUserId")]
        public string UserId { get; set; }
        [NameChange("strName1")]
        public string Name { get; set; }
        [NameChange("strPhone")]
        public string Phone { get; set; }
    }
}