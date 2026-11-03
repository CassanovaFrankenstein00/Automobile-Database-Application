using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoCollection.Models;
using System.Threading.Tasks;

namespace AutoCollection.Pages.AutomobilePages;

public class IndexModel : PageModel
{
    private readonly AutoCollectionContext _context;

    public IndexModel(AutoCollectionContext context)
    {
        _context = context;
    }

    public IList<Automobile> Automobile { get; set; } = default!;
    [BindProperty(SupportsGet = true)]
    public string SearchString { get; set; }

    public async Task OnGetAsync()
    {
        var automobile = from r in _context.Automobile
                         select r;
        if (!string.IsNullOrEmpty(SearchString))
        {
            automobile = automobile.Where(r => r.Make.Contains(SearchString));
        }

        Automobile = await automobile.ToListAsync();
    }
}
