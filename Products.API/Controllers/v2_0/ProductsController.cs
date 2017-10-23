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

namespace Products.API.Controllers.v2_0
{
    [ApiVersion("2.0")]
    [RoutePrefix("products")]
    [NotFoundExceptionFilter]
    [UnhandledExceptionFilter]
    public class ProductsController : ApiController
    {
        #region Properties
        //private readonly IProductService _productService;
        //private readonly IProductOptionService _productOptionService;
        private readonly string _message = "API Version 2.0 in progress.";
        #endregion

        #region Constructors
        //public ProductsController(
        //    IProductService productService,
        //    IProductOptionService productOptionService)
        //{
        //    _productService = productService;
        //    _productOptionService = productOptionService;
        //}
        #endregion

        #region Methods - Product
        // GET /products - gets all products.
        [Route("")]
        [HttpGet]
        public IHttpActionResult RetrieveProducts()
        {
            throw new NotImplementedException(_message);
        }

        // GET /products?name={name} - finds all products matching the specified name.
        [Route("")]
        [HttpGet]
        public IHttpActionResult RetrieveProductsByName(string name)
        {
            throw new NotImplementedException(_message);
        }

        // GET /products/{id} - gets the project that matches the specified ID - ID is a GUID.
        [Route("{id:guid}", Name = "RetrieveProductByIdV2_0")]
        [HttpGet]
        public IHttpActionResult RetrieveProductById(Guid id)
        {
            throw new NotImplementedException(_message);
        }

        // POST /products - creates a new product.
        [Route("")]
        [HttpPost]
        [NullResourceCheckFilter]
        public IHttpActionResult CreateProduct([FromBody]ProductDTO productDTO)
        {
            throw new NotImplementedException(_message);
        }

        // PUT /products/{id} - updates a product.
        [Route("{id:guid}")]
        [HttpPut]
        [NullResourceCheckFilter]
        [SameIdCheckFilter]
        public IHttpActionResult UpdateProduct(Guid id, [FromBody]ProductDTO productDTO)
        {
            throw new NotImplementedException(_message);
        }

        // DELETE /products/{id} - deletes a product and its options.
        [Route("{id:guid}")]
        [HttpDelete]
        public IHttpActionResult DeleteProduct(Guid id)
        {
            throw new NotImplementedException(_message);
        }
        #endregion

        #region Methods - ProductOption

        // GET /products/{id}/options - finds all options for a specified product.
        [Route("{id:guid}/options")]
        [HttpGet]
        public IHttpActionResult RetrieveProductOptionsByProductId(Guid id)
        {
            throw new NotImplementedException(_message);
        }

        // GET /products/{id}/options/{optionId} - finds the specified product option for the specified product.
        [Route("{id:guid}/options/{optionId:guid}", Name = "RetrieveProductOptionsByProductIdAndOptionIdV2_0")]
        [HttpGet]
        public IHttpActionResult RetrieveProductOptionsByProductIdAndOptionId(Guid id, Guid optionId)
        {
            throw new NotImplementedException(_message);
        }

        // POST /products/{id}/options - adds a new product option to the specified product.
        [Route("{id:guid}/options")]
        [HttpPost]
        [NullResourceCheckFilter]
        public IHttpActionResult CreateProductOption(Guid id, [FromBody]ProductOptionDTO productOptionDTO)
        {
            throw new NotImplementedException(_message);
        }

        // PUT /products/{id}/options/{optionId} - updates the specified product option.
        [Route("{id:guid}/options/{optionId:guid}")]
        [HttpPut]
        [NullResourceCheckFilter]
        [SameIdCheckFilter]
        public IHttpActionResult UpdateProductOption(Guid id, Guid optionId, [FromBody]ProductOptionDTO productOptionDTO)
        {
            throw new NotImplementedException(_message);
        }

        // DELETE /products/{id}/options/{optionId} - deletes the specified product option.
        [Route("{id:guid}/options/{optionId:guid}")]
        [HttpDelete]
        public IHttpActionResult DeleteProductOption(Guid id, Guid optionId)
        {
            throw new NotImplementedException(_message);
        }
        #endregion
    }
}
