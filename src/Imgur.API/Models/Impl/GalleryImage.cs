﻿using System;
using System.Collections.Generic;
using Imgur.API.JsonConverters;
using Newtonsoft.Json;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    ///     The data model formatted for gallery images.
    /// </summary>
    public class GalleryImage : GalleryItem, IGalleryImage
    {
        /// <summary>
        ///     The ID for the image.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The title of the image.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Description of the image.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Utc timestamp of when the image was inserted into the gallery, converted from epoch time.
        /// </summary>
        [JsonConverter(typeof (EpochTimeConverter))]
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        ///     Image MIME type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Is the image animated.
        /// </summary>
        public bool Animated { get; set; }

        /// <summary>
        ///     The width of the image in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///     The height of the image in pixels.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        ///     The size of the image in bytes.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///     The size of the image in bytes.
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        ///     Bandwidth consumed by the image in bytes.
        /// </summary>
        public long Bandwidth { get; set; }

        /// <summary>
        ///     OPTIONAL, the deletehash, if you're logged in as the image owner.
        /// </summary>
        public string DeleteHash { get; set; }

        /// <summary>
        ///     The direct link to the the image. (Note: if fetching an animated GIF that was over 20MB in original size, a .gif
        ///     thumbnail will be returned)
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        ///     OPTIONAL, The .gifv link. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        public string Gifv { get; set; }

        /// <summary>
        ///     OPTIONAL, The direct link to the .mp4. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        public string Mp4 { get; set; }

        /// <summary>
        ///     OPTIONAL, The direct link to the .webm. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        public string Webm { get; set; }

        /// <summary>
        ///     OPTIONAL, Whether the image has a looping animation. Only available if the image is animated and type is
        ///     'image/gif'.
        /// </summary>
        public bool Looping { get; set; }

        /// <summary>
        ///     The current user's vote on the album. null if not signed in, if the user hasn't voted on it, or if not submitted to
        ///     the gallery.
        /// </summary>
        public string Vote { get; set; }

        /// <summary>
        ///     Indicates if the current user favorited the image. Defaults to false if not signed in.
        /// </summary>
        public bool? Favorite { get; set; }

        /// <summary>
        ///     Indicates if the image has been marked as nsfw or not. Defaults to null if information is not available.
        /// </summary>
        public bool? Nsfw { get; set; }

        /// <summary>
        ///     Number of comments on the gallery image.
        /// </summary>
        [JsonProperty("comment_count")]
        public int? CommentCount { get; set; }

        /// <summary>
        ///     Up to 10 top level comments, sorted by "best".
        /// </summary>
        [JsonProperty("comment_preview")]
        [JsonConverter(typeof (TypeConverter<IEnumerable<Comment>>))]
        public IEnumerable<IComment> CommentPreview { get; set; } = new List<IComment>();

        /// <summary>
        ///     Topic of the gallery image.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        ///     Topic ID of the gallery image.
        /// </summary>
        [JsonProperty("topic_id")]
        public int? TopicId { get; set; }

        /// <summary>
        ///     If the image has been categorized then this will contain the section the image belongs in. (funny, cats,
        ///     adviceanimals, wtf, etc)
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        ///     The username of the account that uploaded it, or null.
        /// </summary>
        [JsonProperty("account_url")]
        public string AccountUrl { get; set; }

        /// <summary>
        ///     The account ID for the uploader, or null.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        ///     Upvotes for the image.
        /// </summary>
        public int? Ups { get; set; }

        /// <summary>
        ///     Number of downvotes for the image.
        /// </summary>
        public int? Downs { get; set; }

        /// <summary>
        ///     Imgur popularity score.
        /// </summary>
        public int? Score { get; set; }
    }
}