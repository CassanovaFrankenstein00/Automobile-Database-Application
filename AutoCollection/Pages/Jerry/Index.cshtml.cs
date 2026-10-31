using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoCollection.Models;

namespace AutoCollection.Pages.Jerry;

public class IndexModel : PageModel
{
    private readonly AutoCollectionContext _context;

    public IndexModel(AutoCollectionContext context)
    {
        _context = context;
    }

    public IList<Automobile> Automobile { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Automobile = await _context.Automobile.ToListAsync();
    }
}
