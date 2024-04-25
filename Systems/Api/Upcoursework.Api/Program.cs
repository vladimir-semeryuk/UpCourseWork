using Upcoursework.Api.Configuration;
using Upcoursework.Common.Settings;
using Upcoursework.Services.Logger;
using Upcoursework.Services.Logger.Logger;
using Upcoursework.Services.Settings.Settings;
using Upcoursework.Context;
using Upcoursework.Context.Setup;

var mainSettings = Settings.Load<MainSettings>("Main");
var logSettings = Settings.Load<LogSettings>("Log");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
// var identitySettings = Settings.Load<IdentitySettings>("Identity");

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(mainSettings, logSettings);


var services = builder.Services;

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppCors();

services.AddAppHealthChecks();

services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings);

services.AddAppAutoMappers();

services.AddAppValidator();

// services.AddAppAuth(identitySettings);

services.AddAppControllerAndViews();

services.RegisterServices();



var app = builder.Build();

var logger = app.Services.GetRequiredService<IAppLogger>();

app.UseAppCors();

app.UseAppHealthChecks();

app.UseAppSwagger();

// app.UseAppAuth();

app.UseAppControllerAndViews();

DbInitialiser.Execute(app.Services);

// DbSeeder.Execute(app.Services);

logger.Information("The UpCourseWork.API has started");

app.Run();

logger.Information("The UpCourseWork.API has stopped");

