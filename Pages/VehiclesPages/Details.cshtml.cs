using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automobiles.Models;

namespace Automobiles.Pages.VehiclesPages;

public class DetailsModel : PageModel
{
    private readonly AutomobilesContext _context;
    public DetailsModel(AutomobilesContext context)
    {
        _context = context;
    }

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
}
