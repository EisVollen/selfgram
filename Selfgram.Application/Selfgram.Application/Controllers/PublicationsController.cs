using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Selfgram.Infrastructure.Repositories;
using Selfgram.Models.CoreModels;
using Selfgram.Objects.Objects.Account;
using Selfgram.Objects.Objects.Core;

namespace Selfgram.Application.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly IPublicationReposiroty _reposiroty;
        private readonly UserManager<ApplicationUser> _userManager;

        public PublicationsController(
            IPublicationReposiroty reposiroty, 
            UserManager<ApplicationUser> userManager)
        {
            _reposiroty = reposiroty;
            _userManager = userManager;
        }


        // GET: Publications
        public async Task<IActionResult> Index()
        {
            return View(await _reposiroty.GetListAsync());
        }

        // GET: Publications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _reposiroty.GetAsync((Guid)id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // GET: Publications/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_reposiroty.Users(), "Id", "UserName");
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublicationModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                var publication = new Publication
                {
                    Id = Guid.NewGuid(),
                    AuthorId = currentUser.Id,
                    PublicDate = DateTime.Now,
                    Header = model.Header,
                    ImagePath = model.ImagePath,
                    Tags = model.Tags,
                };
                await _reposiroty.SaveOrUpdateAsync(publication);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _reposiroty.GetAsync((Guid) id);
            if (publication == null)
            {
                return NotFound();
            }
            return View(publication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Header,ImagePath,Tags,AuthorId,PublicDate")] Publication publication)
        {
            if (id != publication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _reposiroty.SaveOrUpdateAsync(publication);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_reposiroty.PublicationExists(publication.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_reposiroty.Users(), "Id", "UserName");
            return View(publication);
        }

        // GET: Publications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _reposiroty.GetAsync((Guid) id);
            if (publication == null)
            {
                return NotFound();
            }

            await _reposiroty.DeleteAsync(publication);
            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var publication = await _reposiroty.GetAsync(id);
            await _reposiroty.DeleteAsync(publication);
            return RedirectToAction(nameof(Index));
        }
       
    }
}
