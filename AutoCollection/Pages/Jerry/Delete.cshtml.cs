using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoCollection.Models;

namespace AutoCollection.Pages.Jerry;

public class DeleteModel : PageModel
{
    private readonly AutoCollectionContext _context;

    public DeleteModel(AutoCollectionContext context)
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
        else
        {
            Automobile = automobile;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var automobile = await _context.Automobile.FindAsync(id);
        if (automobile != null)
        {
            Automobile = automobile;
            _context.Automobile.Remove(Automobile);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
