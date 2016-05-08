﻿using System;
using System.Threading.Tasks;
using EasyNetQ;
using FP.MsRmq.ProcessChain.Contracts;
using FP.MsRmq.ProcessChain.Data;

namespace FP.MsRmq.ProcessChain.Processes.Messages
{
    public class Authorization : IBusinessProcess
    {
        private MarktpartnerRepository _marktpartnerRepository;

        public Authorization(MarktpartnerRepository marktpartnerRepository)
        {
            _marktpartnerRepository = marktpartnerRepository;
        }

        private IDisposable subscription;
        public void ConnectToBus(IBus bus)
        {
           subscription = bus.RespondAsync<AuthorizationRequest, AuthorizationResponse>(Authorize);
        }

        private Task<AuthorizationResponse> Authorize(AuthorizationRequest authorizationRequest)
        {
            var marktPartner = _marktpartnerRepository.GetMarktpartnerByUserName(authorizationRequest.UserName);

            var credentialsValid = marktPartner != null && marktPartner.Password == authorizationRequest.Passwort;
            
            return Task.FromResult(new AuthorizationResponse
            {
                IsValid = credentialsValid,
                Id = credentialsValid ? marktPartner.Id : Guid.Empty
            });
        }

        public void Dispose()
        {
            if (subscription != null)
            {
                subscription.Dispose();
                subscription = null;
            }
        }
    }
}
