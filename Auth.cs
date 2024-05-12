using Microsoft.AspNetCore.Authentication;
using System.Net.Sockets;
using System.Text;

namespace WebAPI
{
    public class Auth
    {
        const string exampletokencustomer = "123";
        public bool AuthenticateUser(HttpRequest request)
        {
            string authorizationHeader = request.Headers["Authorization"]!;
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                return false;
            }
            var token = authorizationHeader.Substring("Bearer ".Length);

            try
            {
                if(token == exampletokencustomer)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
