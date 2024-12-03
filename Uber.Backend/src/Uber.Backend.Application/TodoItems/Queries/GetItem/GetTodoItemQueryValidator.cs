namespace Uber.Backend.Application.TodoItems.Queries.GetItem;

internal sealed class GetTodoItemQueryValidator : AbstractValidator<GetTodoItemQuery>
{
    public GetTodoItemQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}
