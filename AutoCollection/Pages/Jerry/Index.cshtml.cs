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
   
    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? MakeFilter { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SortOrder { get; set; }


    public async Task OnGetAsync()
    {
        var automobiles = from a in _context.Automobile
                          select a;

        // Search automobiles by Make
        if (!string.IsNullOrEmpty(SearchString))
        {
            automobiles = automobiles.Where(
                a => a.Make.Contains(SearchString));
        }

        // Filter automobiles by Make
        if (!string.IsNullOrEmpty(MakeFilter))
        {
            automobiles = automobiles.Where(
                a => a.Make.Contains(MakeFilter));
        }

        // Sort automobiles by Make (A-Z)
        if (SortOrder == "make_asc")
        {
            automobiles = automobiles.OrderBy(a => a.Make);
        }

        Automobile = await automobiles.ToListAsync();
    }
}
