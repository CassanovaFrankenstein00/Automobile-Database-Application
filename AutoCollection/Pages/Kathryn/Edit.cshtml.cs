using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoCollection.Models;

namespace AutoCollection.Pages.AutomobilePages;

public class EditModel : PageModel
{
    private readonly AutoCollectionContext _context;

    public EditModel(AutoCollectionContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Automobile Automobile { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var automobile = await _context.Automobile.FirstOrDefaultAsync(m => m.Id == id);
        if (automobile is null)
        {
            return NotFound();
        }
        Automobile = automobile;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Automobile).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AutomobileExists(Automobile.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool AutomobileExists(int id)
    {
        return _context.Automobile.Any(e => e.Id == id);
    }
}
