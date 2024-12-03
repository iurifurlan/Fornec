using Fornec.Data;
using Fornec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fornec.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly AppCont _appCont;

        public FornecedoresController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            var allTalks = _appCont.Fornecedor.ToList();
            return View(allTalks);

        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fornec = await _appCont.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);

            if (fornec == null)
            {
                return BadRequest();
            }
            return View(fornec);
        }

        //GET: Fornecedores / Create
        public IActionResult Create()
        {
            return View();
        }

        // Metodo Post / Create / Fornecedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(fornecedor);
                await _appCont.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // Metodo Get / Edit / Fornecedor
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fornec = await _appCont.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);
            if (fornec == null)
            {
                return BadRequest();
            }
            return View(fornec);
        }

        // Metodo Post / Edit / Fornecedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Fornecedor fornecedor)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _appCont.Update(fornecedor);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // Metodo Get / Delete / Fornecedor
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fornec = await _appCont.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);

            if (fornec == null)
            {
                return NotFound();
            }
            return View(fornec);
        }

        // Metodo Posto / Delete / Fornecedor
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _appCont.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa != null)
            {
                _appCont.Fornecedor.Remove(tarefa);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

    }
}
