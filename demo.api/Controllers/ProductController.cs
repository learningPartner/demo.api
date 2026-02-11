using demo.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public ProductController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateNewProduct(ProductViewModel obj)
        {
            ProductModel pObj = new ProductModel()
            {
                category = obj.category,
                price = obj.price,
                prodName = obj.prodName,
                shortName = obj.shortName
            };
            _context.ProductModels.Add(pObj);
            _context.SaveChanges();

            foreach (var image in obj.prodImages)
            {
                ProductImageModel img = new ProductImageModel()
                {
                    imageName = image.imageName,
                    prodId = pObj.prodId,
                    isActive = image.isActive
                };
                _context.ProductImageModels.Add(img);
                _context.SaveChanges();
            }


            return Ok("Product Created Succes");

        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(ProductViewModel obj)
        {
            var product =  _context.ProductModels.SingleOrDefault(x => x.prodId == obj.prodId);
            if (product == null)
            {
                return NotFound("Product Not Found");
            }
            else
            {

                product.category = obj.category;
                product.price = obj.price;
                product.prodName = obj.prodName;
                product.shortName = obj.shortName;
                _context.SaveChanges();
            }
        
           

            foreach (var image in obj.prodImages)
            {
                if(image.prodImageId ==0)
                {
                    ProductImageModel img = new ProductImageModel()
                    {
                        imageName = image.imageName,
                        prodId = obj.prodId,
                        isActive = image.isActive
                    };
                    _context.ProductImageModels.Add(img);
                    _context.SaveChanges();
                } else
                {
                    var imageData = _context.ProductImageModels.SingleOrDefault(x => x.prodImageId == image.prodImageId);
                    if (imageData == null)
                    {
                        return NotFound("Image Not Found");
                    }
                    else
                    {
                        imageData.imageName = image.imageName;
                        imageData.isActive = image.isActive; 
                        _context.SaveChanges();
                    }
                }
               
            }


            return Ok("Product Created Succes");

        }

        [HttpDelete("deleteProduct")]
        public bool deleteProduct(int id)
        {
            var stud = _context.ProductModels.FirstOrDefault(m => m.prodId == id);
            if (stud != null)
            {
                var images = _context.ProductImageModels.Where(m => m.prodId == id);
                _context.ProductImageModels.RemoveRange(images);
                _context.SaveChanges();


                _context.ProductModels.Remove(stud);
                _context.SaveChanges();

               

                return true;
            }
            else
            {
                return false;

            }

        }


    }
}
