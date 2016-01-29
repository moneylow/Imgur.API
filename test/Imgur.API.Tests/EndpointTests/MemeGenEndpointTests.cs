﻿using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.EndpointTests
{
    [TestClass]
    public class MemeGenEndpointTests : TestBase
    {
        [TestMethod]
        public async Task GetDefaultMemesAsync_IsTrue()
        {
            var mockUrl = "https://api.imgur.com/3/memegen/defaults";
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockMemeGenEndpointResponses.GetDefaultMemes)
            };

            var client = new ImgurClient("123", "1234");
            var endpoint = new MemeGenEndpoint(client, new HttpClient(new MockHttpMessageHandler(mockUrl, mockResponse)));
            var memes = await endpoint.GetDefaultMemesAsync().ConfigureAwait(false);

            Assert.IsTrue(memes.Any());
        }
    }
}