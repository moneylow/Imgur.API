﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Imgur.API.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.EndpointTests
{
    public partial class AccountEndpointTests
    {
        [TestMethod]
        public async Task GetAccountFavoritesAsync_Any()
        {
            var mockUrl = "https://api.imgur.com/3/account/me/favorites";
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockAccountEndpointResponses.GetAccountFavorites)
            };

            var client = new ImgurClient("123", "1234", MockOAuth2Token);
            var endpoint = new AccountEndpoint(client, new HttpClient(new MockHttpMessageHandler(mockUrl, mockResponse)));
            var favorites = await endpoint.GetAccountFavoritesAsync().ConfigureAwait(false);

            Assert.IsTrue(favorites.Any());
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task GetAccountFavoritesAsync_WithOAuth2TokenNull_ThrowsArgumentNullException()
        {
            var client = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(client);
            await endpoint.GetAccountFavoritesAsync().ConfigureAwait(false);
        }

        [TestMethod]
        public async Task GetAccountGalleryFavoritesAsync_Any()
        {
            var mockUrl = "https://api.imgur.com/3/account/me/gallery_favorites/2/oldest";
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockAccountEndpointResponses.GetAccountGalleryFavorites)
            };

            var client = new ImgurClient("123", "1234", MockOAuth2Token);
            var endpoint = new AccountEndpoint(client, new HttpClient(new MockHttpMessageHandler(mockUrl, mockResponse)));
            var favorites =
                await
                    endpoint.GetAccountGalleryFavoritesAsync(page: 2, sort: AccountGallerySortOrder.Oldest)
                        .ConfigureAwait(false);

            Assert.IsTrue(favorites.Any());
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task GetAccountGalleryFavoritesAsync_WithDefaultUsernameAndOAuth2Null_ThrowsArgumentNullException
            ()
        {
            var client = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(client);
            await endpoint.GetAccountGalleryFavoritesAsync().ConfigureAwait(false);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task GetAccountGalleryFavoritesAsync_WithUsernameNull_ThrowsArgumentNullException()
        {
            var client = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(client);
            await endpoint.GetAccountGalleryFavoritesAsync(null).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task GetAccountSubmissionsAsync_Any()
        {
            var mockUrl = "https://api.imgur.com/3/account/me/submissions/2";
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockAccountEndpointResponses.GetAccountSubmissions)
            };

            var client = new ImgurClient("123", "1234", MockOAuth2Token);
            var endpoint = new AccountEndpoint(client, new HttpClient(new MockHttpMessageHandler(mockUrl, mockResponse)));
            var submissions = await endpoint.GetAccountSubmissionsAsync(page: 2).ConfigureAwait(false);

            Assert.IsTrue(submissions.Any());
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task GetAccountSubmissionsAsync_WithDefaultUsernameAndOAuth2Null_ThrowsArgumentNullException()
        {
            var client = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(client);
            await endpoint.GetAccountSubmissionsAsync().ConfigureAwait(false);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task GetAccountSubmissionsAsync_WithUsernameNull_ThrowsArgumentNullException()
        {
            var client = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(client);
            await endpoint.GetAccountSubmissionsAsync(null).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task GetGalleryProfileAsync_IsNotNull()
        {
            var mockUrl = "https://api.imgur.com/3/account/me/gallery_profile";
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockAccountEndpointResponses.GetGalleryProfile)
            };

            var client = new ImgurClient("123", "1234", MockOAuth2Token);
            var endpoint = new AccountEndpoint(client, new HttpClient(new MockHttpMessageHandler(mockUrl, mockResponse)));
            var profile = await endpoint.GetGalleryProfileAsync().ConfigureAwait(false);

            Assert.IsNotNull(profile);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task GetGalleryProfileAsync_WithDefaultUsernameAndOAuth2Null_ThrowsArgumentNullException()
        {
            var client = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(client);
            await endpoint.GetGalleryProfileAsync().ConfigureAwait(false);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task GetGalleryProfileAsync_WithUsernameNull_ThrowsArgumentNullException()
        {
            var client = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(client);
            await endpoint.GetGalleryProfileAsync(null).ConfigureAwait(false);
        }
    }
}