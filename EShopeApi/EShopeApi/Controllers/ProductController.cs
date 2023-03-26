using AutoMapper;
using EShopeApi.DTO;
using EShopeApi.Repository.ProductRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //private readonly Iproducthelper instance
        private readonly IProductHelper  _productHelper;
        private readonly IMapper _mapper;

        //public constructor
        public ProductController(IProductHelper productHelper, IMapper mapper)
        {
            _productHelper = productHelper;
            _mapper = mapper;
        }

        //Implementation EndPoint

        [HttpGet]
        public IActionResult Get() {

            var ProductList = _mapper.Map<List<ProductDto>>(_productHelper.GetAll());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ProductList);
        
        }


        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            if(!_productHelper.isExist(id))
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Product=_mapper.Map<ProductDto>(_productHelper.Getbyid(id));
            return Ok(Product);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(product == null)
            {
                return BadRequest(ModelState);
            }
            var newproduct=_mapper.Map<ProductDto>(_productHelper.CreateProduct(product));
            return Ok(newproduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_productHelper.isExist(id))
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           _productHelper.DeleteProduct(id);
            return Ok();
             
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,ProductDto newproduct) {

            if (!_productHelper.isExist(id))
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product=_mapper.Map<ProductDto>(_productHelper.UpdateProduct(id,newproduct));
            return Ok(product);
        }



    }
}
