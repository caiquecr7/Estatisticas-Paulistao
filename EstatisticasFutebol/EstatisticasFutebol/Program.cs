using EstatisticasFutebol.Business_Logic.ApiServices;
using EstatisticasFutebol.Business_Logic.ApiServices.Interface;
using EstatisticasFutebol.Business_Logic.Services;
using EstatisticasFutebol.Business_Logic.Services.Interface;
using EstatisticasFutebol;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IGeneralApiService, GeneralApiService>();
builder.Services.AddScoped<IRoundApiService, RoundApiService>();
builder.Services.AddScoped<IRoundService, RoundService>();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddHttpClient<IRoundApiService, RoundApiService>(x =>
{
    x.BaseAddress = new Uri("https://api.api-futebol.com.br/v1/campeonatos/10/");
    x.DefaultRequestHeaders.Add("Authorization", "Bearer test_207879d2b21a72f6371ee806644f2e");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthorization();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
