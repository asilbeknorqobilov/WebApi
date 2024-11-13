using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi;

[ApiController]
[Route("api/[controller]")]
public class ProductController:ControllerBase
{
    private DataDbContext db;
    public ProductController(DataDbContext dataDbContext)
    {
        db = dataDbContext;
    }

    [HttpPost]
    public ActionResult<Product> Post(Product product)
    {
        db.Products.Add(product);
        db.SaveChanges();
        return Ok(product);
    }

    [HttpGet]
    public ActionResult<Product> Put(int id, Product product)
    {
        var old_product = db.Products.Find(id);
        if (old_product==null)
        {
            return NotFound();
        }
        old_product.Name = product.Name;
        old_product.Price = product.Price;
        db.SaveChanges();
        return Ok(product);
    }
    
    
    
    [HttpPut]
    public ActionResult<IEnumerable<Product>> Get()
    {
        // var res= new List<Product>() { new Product()
        // {
        //     Id =1,
        //     Name = "Shaftoli",
        //     Price = 27000
        // }};
        var res = db.Products.ToList();
        return Ok(res);
    }
}