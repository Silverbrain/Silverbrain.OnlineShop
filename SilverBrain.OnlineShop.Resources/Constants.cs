using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Resources
{
    public static class Constants
    {
        //Areas
        public static string AreaManagement { get; set; } = "Dashboard";
        public static string AreaAccount { get; set; } = "Account";

        //Controllers
        public static string ControllerHome { get; set; } = "Home";
        public static string ControllerAccount { get; set; } = "Account";
        public static string ControllerBrand { get; set; } = "Brand";

        //Actions
        public static string ActionIndex { get; set; } = "Index";
        public static string ActionLogout { get; set; } = "LogOut";
        public static string ActionLogin { get; set; } = "Login";
        public static string ActionCreate { get; set; } = "Create";
        public static string ActionEdit { get; set; } = "Edit";
        public static string ActionDelete { get; set; } = "Delete";
        public static string ActionRead { get; set; } = "Read";
        public static string ActionReadAll { get; set; } = "ReadAll";

        //Paths
        public static string PathBrandImage { get; set; } = "~/assets/images/brands";
    }
}
