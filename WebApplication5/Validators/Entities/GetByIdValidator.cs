using FluentValidation;
using WebApplication5.Queries.GetEntity;
using WebApplication5.Interfaces;

namespace WebApplication5.Validators.Entities
{
    public class GetByIdValidator<TEntity> : AbstractValidator<GetQuery<TEntity>>
                where TEntity : IEntity
    {
        public GetByIdValidator()
        {
            RuleFor(query => query.Entity.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
