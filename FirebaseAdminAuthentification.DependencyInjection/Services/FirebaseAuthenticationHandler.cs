﻿using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FirebaseAdminAuthentification.DependencyInjection.Services;

public class FirebaseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions> {
    private readonly FirebaseAuthenticationFunctionHandler _authenticationFunctionHandler;

    public FirebaseAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock,
        FirebaseAuthenticationFunctionHandler authenticationFunctionHandler
    ) : base(options, logger, encoder, clock) {
        _authenticationFunctionHandler = authenticationFunctionHandler;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync() {
        return _authenticationFunctionHandler.HandleAuthenticateAsync(Context);
    }
}