using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewComponentLesson.Context;

namespace ViewComponentLesson.Pages.Product;

public class IndexModel(AppDbContext context) : PageModel
{
    private readonly AppDbContext _context = context;

    public string Message { get; set; }
    public List<Entities.Product> Products { get; set; }

    public void OnGet()
    {
        Message = $"Now date is {DateTime.Now.DayOfWeek}";
        Products = [.. _context.Products];
    }

    [BindProperty]
    public Entities.Product Product { get; set; }

    public IActionResult OnPost()
    {
        _context.Products.Add(Product);
        _context.SaveChanges();
        return RedirectToPage("Index");
    }
}