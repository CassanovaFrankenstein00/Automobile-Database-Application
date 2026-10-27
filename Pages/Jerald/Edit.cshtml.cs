using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automobiles.Models;

namespace Automobiles.Pages.Jerald;

public class EditModel : PageModel
{
    private readonly AutomobilesContext _context;

    public EditModel(AutomobilesContext context)
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
        Vehicles = vehicles;
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

        _context.Attach(Vehicles).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VehiclesExists(Vehicles.Id))
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

    private bool VehiclesExists(int id)
    {
        return _context.Vehicles.Any(e => e.Id == id);
    }
}
