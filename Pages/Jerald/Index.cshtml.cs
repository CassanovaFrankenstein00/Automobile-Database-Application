using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automobiles.Models;

namespace Automobiles.Pages.Jerald;

public class IndexModel : PageModel
{
    private readonly AutomobilesContext _context;

    public IndexModel(AutomobilesContext context)
    {
        _context = context;
    }

    public IList<Vehicles> Vehicles { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Vehicles = await _context.Vehicles.ToListAsync();
    }
}
