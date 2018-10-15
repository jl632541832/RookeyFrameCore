using System.Net;
using System.Net.Sockets;

namespace Rookey.Frame.Common.Network
{
    /// <summary>
    /// ip地址帮助类
    /// </summary>
    public static class IpAddressHelper
    {
        /// <summary>
        /// 获取本机IP
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIp()
        {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    return ipa.ToString();
            }
            return string.Empty;
        }
    }
}
