using Amazon.S3;
using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TinyDrive.Infrastructure.Data;

namespace TinyDrive.Infrastructure;

public static class DependencyInjection
{
	public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");

		Guard.Against.NullOrEmpty(connectionString);

		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseNpgsql(connectionString: connectionString);
			options.UseSnakeCaseNamingConvention();
		});

		services.AddSingleton<IAmazonS3>(_ =>
		{
			var config = new AmazonS3Config
			{
				ServiceURL = configuration["S3:Endpoint"],
				ForcePathStyle = true
			};

			return new AmazonS3Client(configuration["S3:AccessKey"],
				configuration["S3:SecretKey"], config);
		});
	}
}
