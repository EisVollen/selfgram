using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Selfgram.Objects.Objects.Account;
using Selfgram.Objects.Objects.Core;

namespace Selfgram.Infrastructure.Repositories
{
    public interface IPublicationReposiroty
    {
        Task<List<Publication>> GetListAsync();
        Task<List<Publication>> GetListForUserAsync(ApplicationUser user);
        Task<List<Publication>> GetListForTagAsync(string tag);
        Task<Publication> GetAsync(Guid id);
        bool PublicationExists(Guid id);


        Task SaveOrUpdateAsync(Publication publication);
        Task DeleteAsync(Publication publication);
        IEnumerable Users();


    }
}
