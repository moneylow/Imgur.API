﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Enums;
using Imgur.API.RequestBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imgur.API.Tests.RequestBuilderTests
{
    [TestClass]
    public class AccountRequestBuilderTests
    {
        [TestMethod]
        public async Task UpdateAccountSettingsRequest_AreEqual()
        {
            var client = new ImgurClient("123", "1234");
            var requestBuilder = new AccountRequestBuilder();

            var mockUrl = $"{client.EndpointUrl}account/me/settings";
            var request = requestBuilder.UpdateAccountSettingsRequest(
                mockUrl, "BioTest", true, true, AlbumPrivacy.Public,
                true, "Bob2", true, true);

            Assert.IsNotNull(request);
            var expected =
                "public_images=true&messaging_enabled=true&album_privacy=public&accepted_gallery_terms=true&show_mature=true&newsletter_subscribed=true&bio=BioTest&username=Bob2";

            Assert.AreEqual(expected, await request.Content.ReadAsStringAsync().ConfigureAwait(false));
            Assert.AreEqual("https://api.imgur.com/3/account/me/settings", request.RequestUri.ToString());
            Assert.AreEqual(HttpMethod.Post, request.Method);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void UpdateAccountSettingsRequest_WithUrlNull_ThrowsArgumentNullException()
        {
            var requestBuilder = new AccountRequestBuilder();
            requestBuilder.UpdateAccountSettingsRequest(null);
        }
    }
}