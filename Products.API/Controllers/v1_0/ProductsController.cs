using AutoMapper;
using Products.API.DTOs;
using Products.API.Helpers.Filters;
using Products.Service.Interfaces;
using Products.Model;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Web.Http;

namespace Products.API.Controllers.v1_0
{
    [ApiVersion("1.0")]
    [RoutePrefix("products")]
    [ModelStateCheckFilter]
    [NotFoundExceptionFilter]
    [UnhandledExceptionFilter]
    public class ProductsController : ApiController
    {
        #region Properties
        private readonly IProductService _productService;
        private readonly IProductOptionService _productOptionService;
        #endregion

        #region Constructors
        public ProductsController(
            IProductService productService,
            IProductOptionService productOptionService)
        {
            _productService = productService;
            _productOptionService = productOptionService;
        }
        #endregion

        #region Methods - Product
        // GET /products - gets all products.
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> RetrieveProducts()
        {
            var productsModel = await _productService.RetrieveAsync();
            var productCollectionDTO = Mapper.Map<CollectionDTO<ProductDTO>>(productsModel);

            return Ok(productCollectionDTO);
        }

        // GET /products?name={name} - finds all products matching the specified name.
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> RetrieveProductsByName(string name)
        {
            var productsModel = await _productService.RetrieveByNameAsync(name);
            var productCollectionDTO = Mapper.Map<CollectionDTO<ProductDTO>>(productsModel);

            return Ok(productCollectionDTO);
        }

        // GET /products/{id} - gets the project that matches the specified ID - ID is a GUID.
        [Route("{id:guid}", Name = "RetrieveProductById")]
        [HttpGet]
        public async Task<IHttpActionResult> RetrieveProductById(Guid id)
        {
            var productModel = await _productService.RetrieveByIdAsync(id);
            var productDTO = Mapper.Map<ProductDTO>(productModel);

            return Ok(productDTO);
        }

        // POST /products - creates a new product.
        [Route("")]
        [HttpPost]
        [NullResourceCheckFilter]
        public async Task<IHttpActionResult> CreateProduct([FromBody]ProductDTO productDTO)
        {
            var productModel = Mapper.Map<ProductModel>(productDTO);
            productModel = await _productService.CreateAsync(productModel);
            productDTO = Mapper.Map<ProductDTO>(productModel);

            return CreatedAtRoute("RetrieveProductById", new { id = productDTO.Id }, productDTO);
        }

        // PUT /products/{id} - updates a product.
        [Route("{id:guid}")]
        [HttpPut]
        [NullResourceCheckFilter]
        [SameIdCheckFilter]
        public async Task<IHttpActionResult> UpdateProduct(Guid id, [FromBody]ProductDTO productDTO)
        {
            var productModel = Mapper.Map<ProductModel>(productDTO);
            await _productService.UpdateAsync(id, productModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE /products/{id} - deletes a product and its options.
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteAsync(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
        #endregion

        #region Methods - ProductOption

        // GET /products/{id}/options - finds all options for a specified product.
        [Route("{id:guid}/options")]
        [HttpGet]
        public async Task<IHttpActionResult> RetrieveProductOptionsByProductId(Guid id)
        {
            var productOptionsModel = await _productOptionService.RetrieveByProductIdAsync(id);
            var productOptionsCollectionDTO = Mapper.Map<CollectionDTO<ProductOptionDTO>>(productOptionsModel);

            return Ok(productOptionsCollectionDTO);
        }

        // GET /products/{id}/options/{optionId} - finds the specified product option for the specified product.
        [Route("{id:guid}/options/{optionId:guid}", Name = "RetrieveProductOptionByProductIdAndOptionId")]
        [HttpGet]
        public async Task<IHttpActionResult> RetrieveProductOptionByProductIdAndOptionId(Guid id, Guid optionId)
        {
            var productOptionModel = await _productOptionService.RetrieveByProductIdAndIdAsync(id, optionId);
            var productOptionDTO = Mapper.Map<ProductOptionDTO>(productOptionModel);

            return Ok(productOptionDTO);
        }

        // POST /products/{id}/options - adds a new product option to the specified product.
        [Route("{id:guid}/options")]
        [HttpPost]
        [NullResourceCheckFilter]
        public async Task<IHttpActionResult> CreateProductOption(Guid id, [FromBody]ProductOptionDTO productOptionDTO)
        {
            var productOptionModel = Mapper.Map<ProductOptionModel>(productOptionDTO);
            productOptionModel = await _productOptionService.CreateAsync(id, productOptionModel);
            productOptionDTO = Mapper.Map<ProductOptionDTO>(productOptionModel);

            return CreatedAtRoute(
                "RetrieveProductOptionByProductIdAndOptionId",
                new { id = id, optionId = productOptionDTO.Id },
                productOptionDTO);
        }

        // PUT /products/{id}/options/{optionId} - updates the specified product option.
        [Route("{id:guid}/options/{optionId:guid}")]
        [HttpPut]
        [NullResourceCheckFilter]
        [SameIdCheckFilter]
        public async Task<IHttpActionResult> UpdateProductOption(Guid id, Guid optionId, [FromBody]ProductOptionDTO productOptionDTO)
        {
            var productOptionModel = Mapper.Map<ProductOptionModel>(productOptionDTO);
            await _productOptionService.UpdateAsync(id, optionId, productOptionModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE /products/{id}/options/{optionId} - deletes the specified product option.
        [Route("{id:guid}/options/{optionId:guid}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProductOption(Guid id, Guid optionId)
        {
            await _productOptionService.DeleteAsync(id, optionId);

            return StatusCode(HttpStatusCode.NoContent);
        }
        #endregion
    }
}
