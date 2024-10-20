namespace SeahawkSaverBackend.API;
using Microsoft.OpenApi.Models;
using SeahawkSaverBackend.Application;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;
using SeahawkSaverBackend.Persistence;

/**
 * <summary>
 * Extension method for configuring the API services and middleware.
 * </summary>
 */
public static class StartupExtensions
{
	/**
	 * <summary>
	 * An extension method for <see cref="WebApplicationBuilder"/> to configure the API services.
	 * </summary>
	 * <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
	 */
	public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.Configuration.Sources.Clear();
		builder.Configuration.AddJsonFile("AppSettings.json", false, true);
		builder.Configuration.AddJsonFile($"AppSettings.{builder.Environment.EnvironmentName}.json", true, true);
		builder.Configuration.AddUserSecrets<Program>();
		builder.Configuration.AddEnvironmentVariables();

		builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(configureOptions =>
		{
			configureOptions.SerializerOptions.PropertyNamingPolicy = null;
		});

		builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(configureOptions =>
		{
			configureOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
		});

		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		builder.Services.RegisterApplicationServices();
		builder.Services.RegisterPersistenceServices(builder.Configuration);

		builder.Services.AddCors(setupAction =>
		{
			setupAction.AddPolicy("Open",
								  policy =>
								  {
									  policy.AllowAnyOrigin();
									  policy.AllowAnyMethod();
									  policy.AllowAnyHeader();
								  });
		});

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(setupAction =>
		{
			const string version = "1.0.0";

			setupAction.SwaggerDoc(version,
								   new OpenApiInfo
								   {
									   Description = "The Seahawk Saver API.",
									   Title = "Seahawk Saver API",
									   Version = version
								   });

			setupAction.CustomSchemaIds(schemaIdSelector => schemaIdSelector.FullName);
		});

		return builder;
	}

	/**
	 * <summary>
	 * An extension method for <see cref="WebApplication"/> to asynchronously configure the API middleware.
	 * </summary>
	 * <returns>A task that represents the asynchronous operation, and it contains the <see cref="WebApplication"/> instance.</returns>
	 */
	public async static Task<WebApplication> ConfigureMiddleware(this WebApplication application)
	{
		application.UseCors("Open");

		if (application.Environment.IsDevelopment())
		{
			application.UseDeveloperExceptionPage();
			application.UseSwagger();
			application.UseSwaggerUI(setupAction =>
			{
				setupAction.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Seahawk Saver API 1.0.0");
			});
		}

		await StartupExtensions.SeedDatabaseASync(application);

		return application;
	}

	/**
	 * <summary>
	 * Asynchronously seeds the database if the Database:Seed configuration value is <c>true</c>.
	 * </summary>
	 * <param name="application">The application.</param>
	 * <returns>A task that represents the asynchronous operation.</returns>
	 */
	private async static Task SeedDatabaseASync(WebApplication application)
	{
		await using var scope = application.Services.CreateAsyncScope();
		var databaseSettings = scope.ServiceProvider.GetRequiredService<DatabaseSettings>();

		if (databaseSettings.Seed == false)
		{
			return;
		}

		var databaseDataset = scope.ServiceProvider.GetRequiredService<IDatabaseDataset>();
		var databaseSeeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
		await databaseSeeder.SeedDatabaseAsync(databaseDataset);
	}
}