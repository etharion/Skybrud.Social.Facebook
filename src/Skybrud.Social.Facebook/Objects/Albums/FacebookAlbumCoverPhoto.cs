﻿using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Facebook.Objects.Albums {

    /// <summary>
    /// Class representing the cover photo of an album.
    /// </summary>
    public class FacebookAlbumCoverPhoto : FacebookObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the cover photo.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets a timestamp representing the creation time of the cover photo.
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// Gets the name of the cover photo, or <code>null</code> if not specified.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets whether the album has a name.
        /// </summary>
        public bool HasName {
            get { return !String.IsNullOrWhiteSpace(Name); }
        }

        #endregion

        #region Constructors

        private FacebookAlbumCoverPhoto(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            CreatedTime = obj.GetDateTime("created_time");
            Name = obj.GetString("name");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="FacebookAlbumCoverPhoto"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="FacebookAlbumCoverPhoto"/>.</returns>
        public static FacebookAlbumCoverPhoto Parse(JObject obj) {
            return obj == null ? null : new FacebookAlbumCoverPhoto(obj);
        }

        #endregion

    }

}