using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Products.API.Controllers.v1_0;
using Products.API.DTOs;
using Products.Model;
using Products.Repository.Interfaces;
using Products.Service;
using Products.Service.Helpers.Exceptions;
using Products.Service.Interfaces;
using RandomTestValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Products.Test.Controllers
{
    [TestClass]
    public class ProductsControllerTests
    {
        private Mock<IProductService> _productService;
        private Mock<IProductOptionService> _productOptionService;
        private ProductsController _productsController;

        [TestInitialize]
        public void Setup()
        {
            _productService = new Mock<IProductService>();
            _productOptionService = new Mock<IProductOptionService>();
            _productsController = new ProductsController(_productService.Object, _productOptionService.Object);
            Mapper.Initialize(a => a.AddProfiles(new[] { typeof(ProductsController) }));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task RetrieveProductById_WithNoMatchingEntity_ShouldThrowNotFoundException()
        {
            var id = RandomValue.Guid();
            _productService.Setup(a => a.RetrieveByIdAsync(id)).ThrowsAsync(new NotFoundException("Not Found"));

            var result = await _productsController.RetrieveProductById(id);
        }

        [TestMethod]
        public async Task RetrieveProductById_WithMatchingEntity_ShouldReturnProductDTO()
        {
            var model = RandomValue.Object<ProductModel>();
            var id = model.Id;
            _productService.Setup(x => x.RetrieveByIdAsync(id)).ReturnsAsync(model);

            var result = await _productsController.RetrieveProductById(id) as OkNegotiatedContentResult<ProductDTO>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Content, typeof(ProductDTO));
            Assert.AreEqual(model.Id, result.Content.Id);
            Assert.AreEqual(model.Name, result.Content.Name);
            Assert.AreEqual(model.Description, result.Content.Description);
            Assert.AreEqual(model.Price, result.Content.Price);
            Assert.AreEqual(model.DeliveryPrice, result.Content.DeliveryPrice);
        }

        [TestMethod]
        public async Task RetrieveProductOptionByProductIdAndOptionId_WithMatchingEntity_ShouldReturnProductOptionDTO()
        {
            var model = RandomValue.Object<ProductOptionModel>();
            var id = model.Id;
            var productId = model.ProductId;
            _productOptionService.Setup(x => x.RetrieveByProductIdAndIdAsync(productId, id)).ReturnsAsync(model);

            var result = await _productsController.RetrieveProductOptionByProductIdAndOptionId(productId, id) as OkNegotiatedContentResult<ProductOptionDTO>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Content, typeof(ProductOptionDTO));
            Assert.AreEqual(model.Id, result.Content.Id);
            Assert.AreEqual(model.Name, result.Content.Name);
            Assert.AreEqual(model.Description, result.Content.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task RetrieveProductOptionByProductIdAndOptionId_WithNoMatchingEntity_ShouldThrowNotFoundException()
        {
            var model = RandomValue.Object<ProductModel>();
            var id = RandomValue.Guid();
            var productId = RandomValue.Guid();
            _productOptionService.Setup(x => x.RetrieveByProductIdAndIdAsync(productId, id)).ThrowsAsync(new NotFoundException("Not Found"));

            var result = await _productsController.RetrieveProductOptionByProductIdAndOptionId(productId, id) as OkNegotiatedContentResult<ProductOptionDTO>;
        }
    }
}
