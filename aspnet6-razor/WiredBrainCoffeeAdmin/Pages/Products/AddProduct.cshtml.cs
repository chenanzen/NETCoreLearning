using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class AddProductModel : PageModel
    {
        private WiredContext wiredContext;
        private IWebHostEnvironment webEnv;

        [BindProperty]
        public Product NewProduct { get; set; }

        public AddProductModel(WiredContext context, IWebHostEnvironment environment)
        {
            this.wiredContext = context;
            this.webEnv = environment;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page();  }

            if (NewProduct.Upload is not null)
            {
                NewProduct.ImageFile = NewProduct.Upload.FileName;

                var file = Path.Combine(webEnv.ContentRootPath, "wwwroot/images/menu", NewProduct.Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await NewProduct.Upload.CopyToAsync(fileStream);
                }
            }
            NewProduct.Created = DateTime.Now;
            this.wiredContext.Products.Add(NewProduct);
            var changes = this.wiredContext.SaveChanges();

            return RedirectToPage("ViewAllProducts");
        }
    }
}
