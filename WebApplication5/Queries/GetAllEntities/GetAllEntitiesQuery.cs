using WebApplication5.DAL;
using MediatR;
using WebApplication5.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Pagination;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Queries.GetAllEntities
{
    public class GetAllEntitiesQuery<TEntity> : IRequest<IEnumerable<TEntity>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
