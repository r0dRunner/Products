using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Products.Service.Interfaces;
using Products.Repository.Interfaces;
using Products.Service;
using System.Collections.Generic;
using Products.Entity;
using RandomTestValues;
using System.Linq;
using Products.Model;
using System.Threading.Tasks;
using AutoMapper;
using Products.Service.Helpers.Exceptions;
using System.Data.SqlClient;

namespace Products.Test
{
    [TestClass]
    public class ProductOptionServiceTests
    {
        private Mock<IProductRepository> _productRepository;
        private IProductService _productService;

        [TestInitialize]
        public void Setup()
        {
            _productRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepository.Object);
            Mapper.Initialize(a => a.AddProfiles(new[] { typeof(ProductService) }));
        }

        [TestMethod]
        public async Task RetrieveAsync_WithMatchingEntities_ShouldReturnEquivalentModels()
        {
            var entities = RandomValue.IList<ProductEntity>(2);
            _productRepository.Setup(a => a.RetrieveAsync()).ReturnsAsync(entities);

            var models = await _productService.RetrieveAsync();

            Assert.IsNotNull(models);
            Assert.AreEqual(entities.Count, models.Count());
            Assert.IsInstanceOfType(models, typeof(IEnumerable<ProductModel>));
            Assert.AreEqual(entities.FirstOrDefault().Id, models.FirstOrDefault().Id);
            Assert.AreEqual(entities.FirstOrDefault().Name, models.FirstOrDefault().Name);
            Assert.AreEqual(entities.FirstOrDefault().Description, models.FirstOrDefault().Description);
            Assert.AreEqual(entities.FirstOrDefault().Price, models.FirstOrDefault().Price);
            Assert.AreEqual(entities.FirstOrDefault().DeliveryPrice, models.FirstOrDefault().DeliveryPrice);
        }

        [TestMethod]
        public async Task RetrieveAsync_WithNoMatchingEntities_ShouldReturnEmptyList()
        {
            var entities = RandomValue.IList<ProductEntity>(0);
            _productRepository.Setup(a => a.RetrieveAsync()).ReturnsAsync(entities);

            var models = await _productService.RetrieveAsync();

            Assert.IsNotNull(models);
            Assert.AreEqual(entities.Count, models.Count());
            Assert.IsInstanceOfType(models, typeof(IEnumerable<ProductModel>));
            Assert.AreEqual(0, models.Count());
        }

        [TestMethod]
        public async Task RetrieveByNameAsync_WithMatchingEntities_ShouldReturnEquivalentModels()
        {
            var entities = RandomValue.IList<ProductEntity>(2);
            var name = RandomValue.String();
            _productRepository.Setup(a => a.RetrieveByNameAsync(name)).ReturnsAsync(entities);

            var models = await _productService.RetrieveByNameAsync(name);

            Assert.IsNotNull(models);
            Assert.AreEqual(entities.Count, models.Count());
            Assert.IsInstanceOfType(models, typeof(IEnumerable<ProductModel>));
            Assert.AreEqual(entities.FirstOrDefault().Id, models.FirstOrDefault().Id);
            Assert.AreEqual(entities.FirstOrDefault().Name, models.FirstOrDefault().Name);
            Assert.AreEqual(entities.FirstOrDefault().Description, models.FirstOrDefault().Description);
            Assert.AreEqual(entities.FirstOrDefault().Price, models.FirstOrDefault().Price);
            Assert.AreEqual(entities.FirstOrDefault().DeliveryPrice, models.FirstOrDefault().DeliveryPrice);
        }

        [TestMethod]
        public async Task RetrieveByNameAsync_WithNoMatchingEntities_ShouldReturnEmptyList()
        {
            var entities = RandomValue.IList<ProductEntity>(0);
            var name = RandomValue.String();
            _productRepository.Setup(a => a.RetrieveByNameAsync(name)).ReturnsAsync(entities);

            var models = await _productService.RetrieveByNameAsync(name);

            Assert.IsNotNull(models);
            Assert.AreEqual(entities.Count, models.Count());
            Assert.IsInstanceOfType(models, typeof(IEnumerable<ProductModel>));
            Assert.AreEqual(0, models.Count());
        }

        [TestMethod]
        public async Task RetrieveByIdAsync_WithMatchingEntity_ShouldReturnEquivalentModel()
        {
            var entity = RandomValue.Object<ProductEntity>();
            var id = RandomValue.Guid();
            _productRepository.Setup(a => a.RetrieveByIdAsync(id)).ReturnsAsync(entity);

            var model = await _productService.RetrieveByIdAsync(id);

            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(model, typeof(ProductModel));
            Assert.AreEqual(entity.Id, model.Id);
            Assert.AreEqual(entity.Name, model.Name);
            Assert.AreEqual(entity.Description, model.Description);
            Assert.AreEqual(entity.Price, model.Price);
            Assert.AreEqual(entity.DeliveryPrice, model.DeliveryPrice);
        }


        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task RetrieveByIdAsync_WithNoMatchingEntity_ShouldThrowNotFoundException()
        {
            ProductEntity entity = null;
            var id = RandomValue.Guid();
            _productRepository.Setup(a => a.RetrieveByIdAsync(id)).ReturnsAsync(entity);

            var models = await _productService.RetrieveByIdAsync(id);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task UpdateAsync_WithNoMatchingEntity_ShouldThrowNotFoundException()
        {
            ProductEntity entity = null;
            var model = RandomValue.Object<ProductModel>();
            var id = RandomValue.Guid();
            _productRepository.Setup(a => a.RetrieveByIdAsync(id)).ReturnsAsync(entity);

            await _productService.UpdateAsync(id, model);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task DeleteAsync_WithNoMatchingEntity_ShouldThrowNotFoundException()
        {
            ProductEntity entity = null;
            var id = RandomValue.Guid();
            _productRepository.Setup(a => a.RetrieveByIdAsync(id)).ReturnsAsync(entity);

            await _productService.DeleteAsync(id);
        }
    }
}
