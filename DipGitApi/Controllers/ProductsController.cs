using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Microsoft.Extensions.Configuration;
using DipGitApiLib;
using System.Text.Json;
using RestSharp.Authenticators;
using RestSharp.Serializers;

namespace DipGitApi.Controllers
{
    // public class Request {
    //     public Request(Product product)
    //     {
    //         Product = product;
    //     }
    //    public Product Product { get; set; }
    // }


    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private RestClient _client;
        private string _accessKey;

        public ProductsController(IConfiguration config) {
            _config = config;
            _client = new RestClient(_config.GetConnectionString("RestDB_Url"));
            _accessKey = _config.GetConnectionString("key");
        }
   
        /// <summary>
        /// Searches Products for the value of a specific field
        /// </summary>
        /// <param name="field">Name of field to search on</param>
        /// <param name="value">value of field</param>
        /// <returns>Object if found</returns>
        [HttpGet("{field}/{value}")]
        public async Task<IActionResult> SearchProduct(string field, string value) {
            string search = $"{{\"{field}\":\"{value}\"}}";

            var request = new RestRequest();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-apikey", _accessKey);
            request.AddHeader("content-type", "application/json");
            request.AddQueryParameter("q", search);
            var response = _client.Get(request);

            if(response.Content.Contains("_id")) {
                return Ok(response.Content);
            }

            return NotFound();
        }

        /// <summary>
        /// Gets all Products and returns them
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var client = new RestClient("https://diplomagit-e6cc.restdb.io/rest/products");
            var request = new RestRequest()
            .AddHeader("cache-control", "no-cache")
            .AddHeader("x-apikey", "35ef07b4da07e33f8da131df3ef7b29b87d9e")
            .AddHeader("content-type", "application/json");
            IRestResponse response = await client.ExecuteAsync(request);

            return Ok(response.Content);
        }

        /// <summary>
        /// Add a new Product
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Product newProduct) {

            var body = JsonSerializer.Serialize(newProduct);

            var client = new RestClient("https://diplomagit-e6cc.restdb.io/rest/products");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-apikey", "35ef07b4da07e33f8da131df3ef7b29b87d9e");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            return Ok(response.Content);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedProduct"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(string id,Product updatedProduct) {

            var body = JsonSerializer.Serialize(updatedProduct);

            var client = new RestClient($"https://diplomagit-e6cc.restdb.io/rest/products/{id}");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-apikey", "35ef07b4da07e33f8da131df3ef7b29b87d9e");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            return Ok(response.Content);
        } 

        /// <summary>
        /// Deletes a product based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string id) {
            var client = new RestClient($"https://diplomagit-e6cc.restdb.io/rest/products/{id}");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-apikey", "35ef07b4da07e33f8da131df3ef7b29b87d9e");
            request.AddHeader("content-type", "application/json");
            IRestResponse response = await client.ExecuteAsync(request);

            return Ok(response.Content);
        }
    }
}