using Microsoft.EntityFrameworkCore;
using DL.DomainModels.Entities;

namespace DL.Interfaces.DatabaseContext
{
    public interface IAppDbContext : IBaseDbContext
    {
        DbSet<Operation> Operations { get; set; }
    }
}
