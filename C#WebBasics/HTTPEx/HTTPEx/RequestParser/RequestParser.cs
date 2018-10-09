using System.Collections.Generic;
using System.Text;

namespace RequestParser
{
    using System;

    public class RequestParser
    {
        public static void Main()
        {
            var getList = new List<string>();
            var postList = new List<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var splitPath = input.Split('/');

                if (splitPath[2] == "get")
                {
                    getList.Add(splitPath[1]);
                }
                else
                {
                    postList.Add(splitPath[1]);
                }
            }

            var requestParams = Console.ReadLine().Split(" ");

            bool IsUrlFound = true;

            if (requestParams[0] == "GET")
            {
                if (!getList.Contains(requestParams[1].Substring(1)))
                {
                    IsUrlFound = false;
                }
            }
            else
            {
                if (!postList.Contains(requestParams[1].Substring(1)))
                {
                    IsUrlFound = false;
                }
            }

            ResponseCodes responseStatus;

            if (IsUrlFound)
            {
                responseStatus = ResponseCodes.OK;
            }
            else
            {
                responseStatus = ResponseCodes.NotFound;
            }

            var outputSb = new StringBuilder();

            outputSb.Append(requestParams[2]).AppendLine($" {(int)responseStatus} {responseStatus}");
            outputSb.AppendLine($"Content-Length: {responseStatus.ToString().Length}");
            outputSb.AppendLine("Content-Type: text/plain").AppendLine();
            outputSb.Append($"{responseStatus}");

            Console.WriteLine(outputSb.ToString());
        }
    }
}
