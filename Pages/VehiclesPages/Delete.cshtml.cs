using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automobiles.Models;

namespace Automobiles.Pages.VehiclesPages;

public class DeleteModel : PageModel
{
    private readonly AutomobilesContext _context;

    public DeleteModel(AutomobilesContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Vehicles Vehicles { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vehicles = await _context.Vehicles.FirstOrDefaultAsync(m => m.Id == id);
        if (vehicles is null)
        {
            return NotFound();
        }
        else
        {
            Vehicles = vehicles;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vehicles = await _context.Vehicles.FindAsync(id);
        if (vehicles != null)
        {
            Vehicles = vehicles;
            _context.Vehicles.Remove(Vehicles);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
