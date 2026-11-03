using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoCollection.Pages.Andrew;

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
    public SelectList Type { get; set; }
    [BindProperty(SupportsGet = true)]
    public string AutomobileType { get; set; }
    public string ModelSort { get; set; }

    public async Task OnGetAsync(string sortOrder)
    {
        ModelSort = sortOrder;

        IQueryable<string> typeQuery = from m in _context.Automobile
                                             orderby m.Type.ToString()
                                             select m.Type.ToString();
        var automobile = from r in _context.Automobile
                         select r;
        if (!string.IsNullOrEmpty(SearchString))
        {
            automobile = automobile.Where(r => r.Make.Contains(SearchString));
        }

        if (!string.IsNullOrEmpty(AutomobileType))
        {
            automobile = automobile.Where(x => x.Type.ToString() == AutomobileType);
        }

        if (ModelSort == "desc")
        {
            automobile = automobile.OrderByDescending(r => r.Model);
        }
        else
        {
            automobile = automobile.OrderBy(r => r.Model);
        }

        Type = new SelectList(await typeQuery.Distinct().ToListAsync());
        Automobile = await automobile.ToListAsync();
    }
}
