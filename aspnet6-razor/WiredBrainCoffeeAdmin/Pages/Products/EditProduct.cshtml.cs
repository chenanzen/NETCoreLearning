using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class EditProductModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _environment;

        [FromRoute]
        public int Id { get; set; }
        public Product EditProduct { get; set; }

        public EditProductModel(IProductRepository productRepository, IWebHostEnvironment environment)
        {
            _productRepository = productRepository;
            _environment = environment;
        }

        public void OnGet()
        {
            EditProduct = _productRepository.GetById(Id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            if (!ModelState.IsValid) { return Page(); }

            if (EditProduct.Upload is not null)
            {
                EditProduct.ImageFile = EditProduct.Upload.FileName;

                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/menu", EditProduct.Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await EditProduct.Upload.CopyToAsync(fileStream);
                }
            }
            EditProduct.Id = Id;
            EditProduct.Created = DateTime.Now;
            _productRepository.Update(EditProduct);

            return RedirectToPage("ViewAllProducts");
        }

        public IActionResult OnPostDelete()
        {
            this._productRepository.Delete(Id);
            return RedirectToPage("ViewAllProducts");
        }
    }
}
