using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestDbApp.Conext;
using TestDbApp.Models;

namespace TestDbApp.Controllers
{
    public class CashFlowsController : Controller
    {
        private readonly MyDbContext _context;

        public CashFlowsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: CashFlows
        public async Task<IActionResult> Index()
        {
            return View(await _context.CashFlowEntity.ToListAsync());
        }

        // GET: CashFlows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashFlow = await _context.CashFlowEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashFlow == null)
            {
                return NotFound();
            }

            return View(cashFlow);
        }

        // GET: CashFlows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashFlows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Symbol,Region")] CashFlow cashFlow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashFlow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cashFlow);
        }

        // GET: CashFlows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashFlow = await _context.CashFlowEntity.FindAsync(id);
            if (cashFlow == null)
            {
                return NotFound();
            }
            return View(cashFlow);
        }

        // POST: CashFlows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Symbol,Region")] CashFlow cashFlow)
        {
            if (id != cashFlow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashFlow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashFlowExists(cashFlow.Id))
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
            return View(cashFlow);
        }

        // GET: CashFlows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashFlow = await _context.CashFlowEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashFlow == null)
            {
                return NotFound();
            }

            return View(cashFlow);
        }

        // POST: CashFlows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashFlow = await _context.CashFlowEntity.FindAsync(id);
            _context.CashFlowEntity.Remove(cashFlow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashFlowExists(int id)
        {
            return _context.CashFlowEntity.Any(e => e.Id == id);
        }
        public string Extract(string yahooHttpRequestString)
        {
            //if need to pass proxy using local configuration  
            System.Net.WebClient webClient = new WebClient();
            webClient.Proxy = HttpWebRequest.GetSystemWebProxy();
            webClient.Proxy.Credentials = CredentialCache.DefaultCredentials;

            Stream strm = webClient.OpenRead(yahooHttpRequestString);
            StreamReader sr = new StreamReader(strm);
            string result = sr.ReadToEnd();
            strm.Close();
            return result;
        }
    }
}
