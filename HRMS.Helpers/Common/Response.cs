using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Helpers.Common
{
    public class Response
    {
        public static Dictionary<string, object> SuccessResponse<T>(string status, string statusCode, T Response) where T : class
        {
            Dictionary<string, object> SuccessResponse = new Dictionary<string, object>();
            SuccessResponse.Add("Status", status);
            SuccessResponse.Add("StatusCode", statusCode);
            SuccessResponse.Add("Data", Response);
            return SuccessResponse;
        }
        public static Dictionary<string, object> SuccessResponse<T>(string status, string statusCode, object Access, T Response) where T : class
        {
            Dictionary<string, object> SuccessResponse = new Dictionary<string, object>();
            SuccessResponse.Add("Status", status);
            SuccessResponse.Add("StatusCode", statusCode);
            SuccessResponse.Add("AccessRights", Access);
            SuccessResponse.Add("Data", Response);
            return SuccessResponse;
        }

        public static Dictionary<string, object> SuccessResponse<T>(string status, int statusCode, T Response) where T : class
        {
            Dictionary<string, object> SuccessResponse = new Dictionary<string, object>();
            SuccessResponse.Add("Status", status);
            SuccessResponse.Add("StatusCode", statusCode);
            SuccessResponse.Add("Data", Response);
            return SuccessResponse;
        }

        public static Dictionary<string, object> SuccessResponse(string status, string statusCode, int Id)
        {
            Dictionary<string, object> SuccessResponse = new Dictionary<string, object>();
            SuccessResponse.Add("Status", status);
            SuccessResponse.Add("StatusCode", statusCode);
            SuccessResponse.Add("Id", Id);
            return SuccessResponse;
        }
        public static Dictionary<string, object> ErrorResponse<T>(string status, int statusCode, T Response) where T : class
        {
            Dictionary<string, object> ErrorResponse = new Dictionary<string, object>();
            ErrorResponse.Add("Status", status);
            ErrorResponse.Add("StatusCode", statusCode);
            ErrorResponse.Add("StatusDescription", Response);
            return ErrorResponse;
        }

        public static Dictionary<string, object> ErrorResponse(string status, string statusCode, string statusDescription)
        {
            Dictionary<string, object> ErrorResponse = new Dictionary<string, object>();
            ErrorResponse.Add("Status", status);
            ErrorResponse.Add("StatusCode", statusCode);
            ErrorResponse.Add("StatusDescription", statusDescription);
            return ErrorResponse;
        }

        public static Dictionary<string, object> PaginationSuccessResponse<T>(string status, string statusCode, T Response, int TotalCount) where T : class
        {
            Dictionary<string, object> SuccessResponse = new Dictionary<string, object>();
            SuccessResponse.Add("Status", status);
            SuccessResponse.Add("StatusCode", statusCode);
            SuccessResponse.Add("Data", Response);
            SuccessResponse.Add("TotalCount", TotalCount);
            return SuccessResponse;
        }
    }
}
