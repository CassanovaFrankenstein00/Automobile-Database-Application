using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automobiles.Models;

namespace Automobiles.Pages.Jerald;

public class CreateModel : PageModel
{
    private readonly AutomobilesContext _context;

    public CreateModel(AutomobilesContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Vehicles Vehicles { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Vehicles.Add(Vehicles);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
