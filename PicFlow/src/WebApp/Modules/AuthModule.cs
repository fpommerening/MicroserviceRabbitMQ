using System;
using System.Text;
using Nancy;

namespace FP.MsRMQ.PicFlow.WebApp.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(AuthenticationRepository authRepo) : base("/restApi/auth/")
        {
            Post("/", async args =>
            {
                var userName = (string) Request.Form.Username;
                var passwordBase64 = HashPassword((string)Request.Form.Password);
                var sessionId = Guid.NewGuid();
                await authRepo.SendAuthorizationRequest(sessionId, userName, passwordBase64);
                return Response.AsJson(new { waitKey = sessionId.ToString() });
            });

            Post("/wait", args =>
            {
                var waitkey = (string) this.Request.Form.Waitkey;
                var cycle = Convert.ToInt16((string)this.Request.Form.cycle);
                Guid waitkeyAsGuid;

                // Es wird maximale Zylen probiert
                if (cycle >= 5 || string.IsNullOrEmpty(waitkey) || !Guid.TryParse(waitkey, out waitkeyAsGuid))
                {
                   return new Response { StatusCode = HttpStatusCode.Unauthorized };
                }

                cycle++;

                var userAuth = authRepo.GetAuthUserBySessionId(waitkeyAsGuid);

                if (userAuth != null && !userAuth.IsEmpty())
                {
                    if (!userAuth.IsValid)
                    {
                        return new Response {StatusCode = HttpStatusCode.Unauthorized};
                    }

                    return Response.AsJson(new
                    {
                        apiKey = waitkey,
                        username = userAuth.User,
                        rememberMe = "True"
                    });
                }

                return this.Response.AsJson(new
                    {
                        waitKey = waitkey,
                        cycle = cycle
                    });
            } );

            Get("secure", args =>
            {
                var identity = this.Context.CurrentUser;
                if (identity != null)
                {
                    return Response.AsJson(new { });
                }
                return new Response {StatusCode = HttpStatusCode.Unauthorized};
            });

            Delete("/", parameter =>
            {
                var sessionId = (string)this.Request.Form.sessionId;
                var sessionIdAsGuid = Guid.Parse(sessionId);
                authRepo.DeleteSession(sessionIdAsGuid);
                return Response.AsJson(new { });
            });
        }

        private static string HashPassword(string password)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var passwordBytes = Encoding.ASCII.GetBytes(password);
            var passwordHash = sha1.ComputeHash(passwordBytes);
            var passwordBase64 = Convert.ToBase64String(passwordHash);
            return passwordBase64;
        }
    }
}
