namespace TinyDrive.Features.Common.Constants;

public static class S3
{
	public const string BucketName = "tiny-drive";
	public static readonly TimeSpan PresignedUrlExpiration = TimeSpan.FromMinutes(15);
	public const long UploadSizeThresholdBytes = 1 * 1024 * 1024;
}
