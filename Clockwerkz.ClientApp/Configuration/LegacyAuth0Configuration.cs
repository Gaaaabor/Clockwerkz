using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;


namespace Clockwerkz.ClientApp.Configuration
{
    public static class LegacyAuth0Configuration
    {
        private const string Audience = "auth0:audience";
        private const string Domain = "auth0:domain";
        private const string ClientId = "auth0:clientId";
        private const string ClientSecret = "auth0:clientSecret";

        public const string AuthenticationScheme = "Auth0";

        public static void ConfigureLegacyAuth0(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add authentication services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(AuthenticationScheme, options =>
            {
                // Set the authority to your Auth0 domain
                options.Authority = $"https://{configuration[Domain]}";

                // Configure the Auth0 Client ID and Client Secret
                options.ClientId = configuration[ClientId];
                options.ClientSecret = configuration[ClientSecret];

                // Set response type to code
                options.ResponseType = "code";

                // Configure the scope
                options.Scope.Clear();
                options.Scope.Add("openid");

                // Set the callback path, so Auth0 will call back to http://localhost:3000/callback
                // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard
                options.CallbackPath = new PathString("/callback");

                // Configure the Claims Issuer to be Auth0
                options.ClaimsIssuer = AuthenticationScheme;

                options.Events = new OpenIdConnectEvents
                {
                    // handle the logout redirection
                    OnRedirectToIdentityProvider = (context) =>
                    {
                        context.ProtocolMessage.SetParameter("audience", configuration[Audience]);
                        return Task.FromResult(0);

                    },
                    OnRedirectToIdentityProviderForSignOut = (context) => OnSignOut(context, configuration)
                };
            });
        }

        public static Task OnSignOut(RedirectContext context, IConfiguration configuration)
        {
            var logoutUri = $"https://{configuration[Domain]}/v2/logout?client_id={configuration[ClientId]}";

            var postLogoutUri = context.Properties.RedirectUri;
            if (!string.IsNullOrEmpty(postLogoutUri))
            {
                if (postLogoutUri.StartsWith("/"))
                {
                    // transform to absolute
                    var request = context.Request;
                    postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                }
                logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
            }

            context.Response.Redirect(logoutUri);
            context.HandleResponse();

            return Task.CompletedTask;
        }

    }
}
