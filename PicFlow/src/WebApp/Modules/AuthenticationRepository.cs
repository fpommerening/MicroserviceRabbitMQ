using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using EasyNetQ;
using FP.MsRMQ.PicFlow.Contracts.Messages;

namespace FP.MsRMQ.PicFlow.WebApp.Modules
{
    public class AuthenticationRepository
    {
        private readonly ConcurrentDictionary<Guid, AuthUser> userSessions = new ConcurrentDictionary<Guid, AuthUser>();

        private readonly IBus _bus;

        public AuthenticationRepository(IBus bus)
        {
            _bus = bus;

            bus.Subscribe<AuthenticationRequest>("WebAuthRepo", req =>
            {
                var authUser = new AuthUser();
                userSessions.AddOrUpdate(req.Id, authUser, (guid, user) => authUser);
            });

            bus.Subscribe<AuthenticationResponse>("authRepo", response =>
            {
                var authUser = new AuthUser
                {
                    Id = response.UserId,
                    User = response.User,
                    IsValid = response.IsValid
                };
                userSessions.AddOrUpdate(response.Id, authUser, (guid, user) => authUser);
            });
        }

        public Task SendAuthorizationRequest(Guid sessionId, string userName, string passwordBase64)
        {
            var authRequest = new AuthenticationRequest
            {
                Id = sessionId,
                PasswordHash = passwordBase64,
                UserName = userName
            };
            return _bus.PublishAsync(authRequest);
        }

        public AuthUser GetAuthUserBySessionId(Guid sessionId)
        {
            if (!userSessions.ContainsKey(sessionId))
                return null;
            return userSessions[sessionId];
        }

        public void DeleteSession(Guid sessionId)
        {
            if (userSessions.ContainsKey(sessionId))
            {
                userSessions.Remove(sessionId);
            }
        }
    }
}
