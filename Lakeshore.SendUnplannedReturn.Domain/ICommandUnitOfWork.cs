
namespace Lakeshore.SendUnplannedReturn.Domain;

public interface ICommandUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
