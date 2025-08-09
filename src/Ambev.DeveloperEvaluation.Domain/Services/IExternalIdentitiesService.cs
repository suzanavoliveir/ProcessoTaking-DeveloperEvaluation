using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IExternalIdentitiesService
    {
        Task<ExternalIdentities> CreateAsync(ExternalIdentities externalIdentities, CancellationToken cancellationToken = default);
        Task<ExternalIdentities?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(ExternalIdentities externalIdentities, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
