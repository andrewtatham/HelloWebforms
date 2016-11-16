using System;
using System.Threading;
using System.Web.SessionState;
using HelloWebforms.Helpers;

namespace HelloWebforms
{
    public class SessionWrapper : ISessionWrapper
    {
        private readonly HttpSessionState _session;

        public SessionWrapper(HttpSessionState session)
        {
            _session = session;

        }

        public NestedDictionary<string, string> GetDebugInfo()
        {
            var retval = new NestedDictionary<string, string>();

            retval["SessionID"].Value = _session.SessionID;
            retval["Mode"].Value = _session.Mode.ToString();
            retval["CookieMode"].Value = _session.CookieMode.ToString();
            retval["IsCookieless"].Value = _session.IsCookieless.ToString();
            retval["CodePage"].Value = _session.CodePage.ToString();
            retval["IsNewSession"].Value = _session.IsNewSession.ToString();
            retval["IsReadOnly"].Value = _session.IsReadOnly.ToString();
            retval["IsSynchronized"].Value = _session.IsSynchronized.ToString();
            retval["LCID"].Value = _session.LCID.ToString();
            retval["Timeout"].Value = _session.Timeout.ToString();
            retval["Count"].Value = _session.Count.ToString();
            retval["Contents"] = _session.GetDebugInfo();
            return retval;
        }

        public void SetUpdated()
        {
            _session.Add("Updated at", DateTime.Now);
        }

        public string SessionId => _session.SessionID;
    }
}