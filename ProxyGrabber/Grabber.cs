using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ProxyGrabber
{
    internal class Grabber
    {

        #region Variables

        private string[] links = new string[] {
            "https://raw.githubusercontent.com/TheSpeedX/SOCKS-List/master/http.txt",
            "https://raw.githubusercontent.com/TheSpeedX/SOCKS-List/master/socks4.txt",
            "https://raw.githubusercontent.com/TheSpeedX/SOCKS-List/master/socks5.txt",
            "https://raw.githubusercontent.com/fate0/proxylist/master/proxy.list",
            "https://raw.githubusercontent.com/a2u/free-proxy-list/master/free-proxy-list.txt",
            "http://rootjazz.com/proxies/proxies.txt",
            "https://api.proxyscrape.com/v2/?request=displayproxies&protocol=http&timeout=10000&country=all&ssl=all&anonymity=all",
            "https://api.proxyscrape.com/v2/?request=displayproxies&protocol=socks5&timeout=10000&country=all&ssl=all&anonymity=all",
            "https://github.com/roosterkid/openproxylist/blob/main/SOCKS5_RAW.txt",
            "https://github.com/roosterkid/openproxylist/blob/main/HTTPS_RAW.txt",
            "https://github.com/opsxcq/proxy-list/blob/master/list.txt",
            "https://github.com/hookzof/socks5_list/blob/master/proxy.txt",
            "https://github.com/ShiftyTR/Proxy-List/blob/master/proxy.txt",
            "https://github.com/clarketm/proxy-list/blob/master/proxy-list.txt",
            "https://github.com/mmpx12/proxy-list/blob/master/proxies.txt",
            "https://github.com/Volodichev/proxy-list/blob/main/hproxy.txt",
            "https://github.com/Volodichev/proxy-list/blob/main/http.txt",
            "https://github.com/Volodichev/proxy-list/blob/main/http_old.txt",
            "https://github.com/sunny9577/proxy-scraper/blob/master/proxies.txt",
            "https://github.com/jetkai/proxy-list/blob/main/online-proxies/txt/proxies.txt",
            "https://checkerproxy.net/api/archive/" + DateTime.Today.ToString("yyyy-MM-d"),
        };

        public delegate void SetProxy(string data);
        public event SetProxy setProxy;

        #endregion

        #region Functions

        public void GetProxy()
        {
            string result = "";
            HttpRequest data = new HttpRequest();
            foreach (string link in links)
            {
                string response = data.Get(link).ToString();
                result += GetAllProxyFromResponse(response).ToString();
            }
            setProxy(result);
        }

        private string GetAllProxyFromResponse(string response)
        {
            string result = "";
            Regex regex = new Regex(@"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{1,5}");
            MatchCollection matchCollection = regex.Matches(response);
            if (matchCollection.Count > 0)
            {
                foreach (Match match in matchCollection)
                {
                    if (!match.Value.Any(char.IsLetter))
                    {
                        result += match.Value + "\n";
                    }
                }
            }
            return result;
        }

        #endregion

    }
}
