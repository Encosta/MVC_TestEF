using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Test.Data;
using MVC_Test.Models;

namespace MVC_Test.Controllers
{
    public class BillOfMaterialsExpandedController : Controller
    {
        private readonly EncostaContext _context;

        public BillOfMaterialsExpandedController(EncostaContext context)
        {
            _context = context;
        }

        // GET: BillOfMaterialsExpanded
        public async Task<IActionResult> Index()
        {
            return View(await _context.BillOfMaterialsExpanded.Take(20).ToListAsync());
        }

        // GET: BillOfMaterialsExpanded/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billOfMaterialsExpanded = await _context.BillOfMaterialsExpanded
                .FirstOrDefaultAsync(m => m.BillOfMaterialsExpandedId == id);
            if (billOfMaterialsExpanded == null)
            {
                return NotFound();
            }

            return View(billOfMaterialsExpanded);
        }

        // GET: BillOfMaterialsExpanded/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BillOfMaterialsExpanded/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillOfMaterialsExpandedId,BomLevel,TopLevelItem, TopLevelDescription,ParentItem,ParentDescription,ComponentItem,ComponentDescription,QuantityPerTop,QuantityPerParent,PurchasedOrManufactured,ScrapPercentage,BomSequence,FullSequence,ParentId,HasChild,StandardCost,LineCost,ManufacturerCodes,BomDate,BomReference,BomRelease")] BillOfMaterialsExpanded billOfMaterialsExpanded)
        {
            if (ModelState.IsValid)
            {
                billOfMaterialsExpanded.BillOfMaterialsExpandedId = Guid.NewGuid();
                _context.Add(billOfMaterialsExpanded);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billOfMaterialsExpanded);
        }

        // GET: BillOfMaterialsExpanded/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billOfMaterialsExpanded = await _context.BillOfMaterialsExpanded.FindAsync(id);
            if (billOfMaterialsExpanded == null)
            {
                return NotFound();
            }
            return View(billOfMaterialsExpanded);
        }

        // POST: BillOfMaterialsExpanded/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BillOfMaterialsExpandedId,BomLevel,TopLevelItem,TopLevelDescription,ParentItem,ParentDescription,ComponentItem,ComponentDescription,QuantityPerTop,QuantityPerParent,PurchasedOrManufactured,ScrapPercentage,BomSequence,FullSequence,ParentId,HasChild,StandardCost,LineCost,ManufacturerCodes,BomDate,BomReference,BomRelease")] BillOfMaterialsExpanded billOfMaterialsExpanded)
        {
            if (id != billOfMaterialsExpanded.BillOfMaterialsExpandedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billOfMaterialsExpanded);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillOfMaterialsExpandedExists(billOfMaterialsExpanded.BillOfMaterialsExpandedId))
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
            return View(billOfMaterialsExpanded);
        }

        // GET: BillOfMaterialsExpanded/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billOfMaterialsExpanded = await _context.BillOfMaterialsExpanded
                .FirstOrDefaultAsync(m => m.BillOfMaterialsExpandedId == id);
            if (billOfMaterialsExpanded == null)
            {
                return NotFound();
            }

            return View(billOfMaterialsExpanded);
        }

        // POST: BillOfMaterialsExpanded/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var billOfMaterialsExpanded = await _context.BillOfMaterialsExpanded.FindAsync(id);
            _context.BillOfMaterialsExpanded.Remove(billOfMaterialsExpanded);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillOfMaterialsExpandedExists(Guid id)
        {
            return _context.BillOfMaterialsExpanded.Any(e => e.BillOfMaterialsExpandedId == id);
        }
    }
}
