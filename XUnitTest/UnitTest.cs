using Core.Utilities.Enums;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTest.Container;
using XUnitTest.Utilities;

namespace XUnitTest
{
    public class UnitTest : IClassFixture<AppTestFixture>
    {
        readonly AppTestFixture fixture;
        readonly HttpClient client;
        public UnitTest(AppTestFixture fixture)
        {
            this.fixture = fixture;
            this.client = fixture.CreateClient();
        }

        [Theory]
        [InlineData]
        public async Task GetList_ShouldGiveData_WhenServiceCall()
        {
            var response = await client.GetAsync("http://localhost:44353/api/product/getlist");

            var json = await response.Content.ReadAsStringAsync();
            //Console.Write(json);
            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            Assert.Equal("application/json; charset=utf-8",
                    response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetById_ShouldGiveData_WhenServiceCall(int id)
        {
            var response = await client.GetAsync("http://localhost:44353/api/product/getbyid?id=" + id);

            var json = await response.Content.ReadAsStringAsync();
            //Console.Write(json);
            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("Shirt")]
        [InlineData("")]
        public async Task GetListByProductName_ShouldGiveData_WhenServiceCall(string productName)
        {
            var response = await client.GetAsync("http://localhost:44353/api/product/getlistbyproductname?productName=" + productName);

            var json = await response.Content.ReadAsStringAsync();
            //Console.Write(json);
            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData(ProductType.Accessories)]
        [InlineData(ProductType.OuterWear)]
        public async Task GetListByProductType_ShouldGiveData_WhenServiceCall(ProductType productType)
        {
            var response = await client.GetAsync("http://localhost:44353/api/product/getlistbyproducttype?productType=" + productType);

            var json = await response.Content.ReadAsStringAsync();
            //Console.Write(json);
            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData('A')]
        [InlineData('P')]
        public async Task GetListByProductStatus_ShouldGiveData_WhenServiceCall(char productStatus)
        {
            var response = await client.GetAsync("http://localhost:44353/api/product/getlistbyproductstatus?productStatus=" + productStatus);

            var json = await response.Content.ReadAsStringAsync();
            //Console.Write(json);
            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task AddProduct_ShouldPostData_WhenServiceCall()
        {
            string jsonProducts = new Converter().LoadJson(Directory.GetCurrentDirectory() + "/Parameters/AddProductData.json");
            HttpContent content = new StringContent(jsonProducts, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:44353/api/product/add", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ShouldPostData_WhenServiceCall()
        {
            string jsonProducts = new Converter().LoadJson(Directory.GetCurrentDirectory() + "/Parameters/UpdateProductData.json");
            HttpContent content = new StringContent(jsonProducts, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:44353/api/product/update", content);

            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct_ShouldPostData_WhenServiceCall()
        {
            string jsonProducts = new Converter().LoadJson(Directory.GetCurrentDirectory() + "/Parameters/DeleteProductData.json");
            HttpContent content = new StringContent(jsonProducts, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:44353/api/product/delete", content);

            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddLog_ShouldPostData_WhenServiceCall()
        {
            string jsonLog = new Converter().LoadJson(Directory.GetCurrentDirectory() + "/Parameters/AddLogData.json");
            HttpContent content = new StringContent(jsonLog, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:44353/api/product/log", content);

            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
