using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoCollection.Models;

namespace AutoCollection.Pages.AutomobilePages;

public class CreateModel : PageModel
{
    private readonly AutoCollectionContext _context;

    public CreateModel(AutoCollectionContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Automobile Automobile { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Automobile.Add(Automobile);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
