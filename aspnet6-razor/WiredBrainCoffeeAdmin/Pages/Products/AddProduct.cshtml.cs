using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class AddProductModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private IWebHostEnvironment webEnv;

        [BindProperty]
        public Product NewProduct { get; set; }

        public AddProductModel(IProductRepository productRepository, IWebHostEnvironment environment)
        {
            _productRepository = productRepository;
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

            _productRepository.Add(NewProduct);

            return RedirectToPage("ViewAllProducts");
        }
    }
}
