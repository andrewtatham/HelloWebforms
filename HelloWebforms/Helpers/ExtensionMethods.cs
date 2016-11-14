using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.SessionState;
using HelloWebforms.Helpers;
using WebGrease.Css.Extensions;

namespace HelloWebforms
{
    public static class ExtensionMethods
    {
        public static NestedDictionary<string, string> GetDebugInfo(this HttpApplicationState nameObjectCollectionBase)
        {
            var retval = new NestedDictionary<string, string>();
            nameObjectCollectionBase.Cast<object>().ForEach(key =>
                retval[key.ToString()].Value = nameObjectCollectionBase[key.ToString()].ToString());
            return retval;
        }


        public static NestedDictionary<string,string> GetDebugInfo(this HttpSessionState nameObjectCollectionBase)
        {
            var retval = new NestedDictionary<string,string>();
            nameObjectCollectionBase.Cast<object>().ForEach(key =>
                retval[key.ToString()].Value = nameObjectCollectionBase[key.ToString()].ToString());
            return retval;

        }


    }
}
