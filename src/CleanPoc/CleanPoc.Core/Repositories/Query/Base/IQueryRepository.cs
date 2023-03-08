
namespace CleanPoc.Core.Repositories.Query.Base;

public interface IQueryRepository<T> where T : class
{
    Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken);
  
}

