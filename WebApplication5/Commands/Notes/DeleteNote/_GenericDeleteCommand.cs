using MediatR;
using WebApplication5.DAL;
using WebApplication5.Interfaces;

namespace WebApplication5.Commands.Notes.DeleteNote
{
    public class _GenericDeleteCommand<TEntity> : IRequest<int?>
        where TEntity : class, IEntity
    {
        public int Id { get; set; }
        //public string Header { get; set; }
        //public string Text { get; set; }
    }
}
