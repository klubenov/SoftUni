namespace URLDecodeAndValidate
{
    using System;
    using System.Linq;
    using System.Net;

    public class HttpValidator
    {
        static void Main()
        {
            var url = Console.ReadLine();

            var decodedUrl = WebUtility.UrlDecode(url);

            if (!IsUrlValid(decodedUrl))
            {
                Console.WriteLine("Invalid URL");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(ValidUrlInfo(url));
                Environment.Exit(0);
            }  
        }

        public static string ValidUrlInfo(string url)
        {
            var splitUrl = url.Split("://");

            var protocol = splitUrl[0];

            string queryString = null;
            string fragmentString = null;
            bool querryOrFragmentExists = false;

            int port = 0;

            switch (protocol)
            {
                case "http":
                    port = 80;
                    break;
                case "https":
                    port = 443;
                    break;
            }

            var urlWithoutProtocol = splitUrl[1];

            var host = urlWithoutProtocol.Split("/")[0];

            var defaultPath = "/";

            string pathWithQuerryAndFragment;

            try
            {
                pathWithQuerryAndFragment = urlWithoutProtocol.Substring(host.Length + 1);
            }
            catch
            {
                pathWithQuerryAndFragment = urlWithoutProtocol.Substring(host.Length);
            }

            var path = pathWithQuerryAndFragment.Split('?')[0];

            if (path.Length == pathWithQuerryAndFragment.Length)
            {
                path = defaultPath + pathWithQuerryAndFragment;
            }
            else
            {
                path = defaultPath + path;
                querryOrFragmentExists = true;
            }

            if (querryOrFragmentExists)
            {
                var queryPlusFragment = pathWithQuerryAndFragment.Split('?')[1];

                var queryPlusFragmentSplit = queryPlusFragment.Split('#');

                queryString = queryPlusFragmentSplit[0];

                if (queryString.Length == queryPlusFragment.Length)
                {
                    queryString = queryPlusFragment;
                }
                else
                {
                    queryString = queryPlusFragmentSplit[0];
                    fragmentString = queryPlusFragmentSplit[1];
                }
            }

            var infoString = $"Protocol: {protocol}\r\nHost: {host}\r\nPort: {port}\r\nPath: {path}";
            if (queryString != null)
            {
                infoString += $"\r\nQuery {queryString}";
            }

            if (fragmentString != null)
            {
                infoString += $"\r\nFragment: {fragmentString}";
            }

            return infoString;
        }

        public static bool IsUrlValid(string url)
        {
            bool IsValid = true;

            var splitUrl = url.Split("://");

            if (splitUrl.Length<2)
            {
                return false;
            }

            var protocol = splitUrl[0];

            int port;

            switch (protocol)
            {
                case "http":
                    port = 80;
                    break;
                case "https":
                    port = 443;
                    break;
                default:
                    return false;
            }

            var urlWithoutProtocol = splitUrl[1];

            var splitUrlWithoutProtocol = urlWithoutProtocol.Split("/");
            var host = splitUrlWithoutProtocol.First();

            var hostPortSplit = host.Split(':');

            if (hostPortSplit.Length != 2)
            {
                return true;
            }

            var portInUrlAsString = hostPortSplit[1];

            int portFromUrl;

            IsValid = int.TryParse(portInUrlAsString, out portFromUrl);

            if (portFromUrl != port)
            {
                IsValid = false;
            }

            return IsValid;
        }
    }
}
