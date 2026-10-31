using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoCollection.Models;

namespace AutoCollection.Pages.Jerry;

public class DetailsModel : PageModel
{
    private readonly AutoCollectionContext _context;
    public DetailsModel(AutoCollectionContext context)
    {
        _context = context;
    }

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
}
