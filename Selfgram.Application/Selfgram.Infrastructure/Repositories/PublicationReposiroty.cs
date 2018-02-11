using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Selfgram.Extensions.Publication;
using Selfgram.Objects.Context;
using Selfgram.Objects.Objects.Account;
using Selfgram.Objects.Objects.Core;

namespace Selfgram.Infrastructure.Repositories
{
    public class PublicationReposiroty: IPublicationReposiroty
    {
        private readonly SelfgramContext _selfgramContext;
        private readonly IIncludableQueryable<Publication, ApplicationUser> _publications;

        public PublicationReposiroty(SelfgramContext selfgramContext)
        {
            _selfgramContext = selfgramContext;
            _publications = selfgramContext.Publications.Include(p => p.Author);
        }


        public Task<List<Publication>> GetListAsync()
        {
            return _publications.AsQueryable().OrderedQueryable().ToListAsync();
        }

        public Task<List<Publication>> GetListForUserAsync(ApplicationUser user)
        {
            return _publications.Where(p => p.Author == user).OrderedQueryable().ToListAsync();
        }
        
        public Task<List<Publication>> GetListForTagAsync(string tag)
        {
            return _publications.Where(p => p.Tags.Contains(tag)).OrderedQueryable().ToListAsync();
        }

        public Task<Publication> GetAsync(Guid id)
        {
          return _publications.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool PublicationExists(Guid id)
        {
            return _selfgramContext.Publications.Any(p => p.Id == id);
        }

        public async Task SaveOrUpdateAsync(Publication publication)
        {
            if (PublicationExists(publication.Id))
            {
                await Update(publication);
            }
            else
            {
                await Create(publication);
            }
        }

        public async Task DeleteAsync(Publication publication)
        {
            if (GetAsync(publication.Id) != null)
            {
                _selfgramContext.Publications.Remove(publication);
                await SaveContextAsync();
            }
        }

        public IEnumerable Users()
        {
            return _selfgramContext.Users;
        }


        #region private methods
        private async Task SaveContextAsync()
        {
            try
            {
                await _selfgramContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        private async Task Create(Publication publication)
        {
            _selfgramContext.Add(publication);
            await SaveContextAsync();
        }

        private async Task Update(Publication publication)
        {
            _selfgramContext.Update(publication);
            await SaveContextAsync();
        }
        #endregion
    }
}
