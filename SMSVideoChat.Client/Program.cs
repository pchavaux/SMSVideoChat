using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using SMSVideoChat.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton(sp =>
{
    return new HubConnectionBuilder()
        .WithUrl("https://smsvideochat.azurewebsites.net/chatHub") // Update to your Azure SignalR endpoint
        .WithAutomaticReconnect()
        .Build();
});
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

await builder.Build().RunAsync();
