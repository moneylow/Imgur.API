﻿using System.Collections.Generic;
using Imgur.API.JsonConverters;
using Newtonsoft.Json;

namespace Imgur.API.Models.Impl
{
    /// <summary>
    ///     The base model for notifications.
    /// </summary>
    public class Notifications : INotifications
    {
        /// <summary>
        ///     An array of message notifications.
        /// </summary>
        [JsonConverter(typeof (TypeConverter<IEnumerable<Notification>>))]
        public IEnumerable<INotification> Messages { get; set; }

        /// <summary>
        ///     An array of comment notifications.
        /// </summary>
        [JsonConverter(typeof (TypeConverter<IEnumerable<Notification>>))]
        public IEnumerable<INotification> Replies { get; set; }
    }
}