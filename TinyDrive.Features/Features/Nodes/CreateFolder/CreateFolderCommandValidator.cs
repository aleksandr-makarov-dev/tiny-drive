using FluentValidation;

namespace TinyDrive.Features.Features.Nodes.CreateFolder;


public sealed class CreateFolderCommandValidator : AbstractValidator<CreateFolderCommand>
{
	public CreateFolderCommandValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(255);
	}
}
