using Newtonsoft.Json.Linq;
using Skybrud.Social.Facebook.Enums;
using Skybrud.Social.Json.Extensions;

namespace Skybrud.Social.Facebook.Objects.Comments {

    /// <summary>
    /// Class representing a summary for the comments of a given object.
    /// </summary>
    public class FacebookCommentsSummary : FacebookObject {

        #region Properties

        /// <summary>
        /// Order in which comments were returned. <see cref="FacebookCommentsOrder.Ranked"/> indicates the most
        /// interesting comments are sorted first. <see cref="FacebookCommentsOrder.Chronological"/> indicates comments
        /// are sorted by the oldest comments first.
        /// </summary>
        public FacebookCommentsOrder Order { get; private set; }

        /// <summary>
        /// Gets the count of comments on this object. It is important to note that this value is changed depending on
        /// the filter modifier being used (where comment replies are available):
        /// 
        /// - <code>toplevel</code> - this is the default, returns all top-level comments in either <code>ranked</code>
        /// or <code>chronological</code> order depending on how the comments are ordered on Facebook. This filter is
        /// useful for displaying comments in the same structure as they appear on Facebook.
        /// 
        /// - <code>stream</code> - all-level comments in <code>chronological</code> order. This filter is useful for
        /// comment moderation tools where it is helpful to see a chronological list of all comments.
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Gets whether the authenticated user can post on the parent object.
        /// </summary>
        public bool CanComment { get; private set; }

        #endregion

        #region Constructors

        private FacebookCommentsSummary(JObject obj) : base(obj) {
            Order = obj.GetEnum<FacebookCommentsOrder>("order");
            TotalCount = obj.GetInt32("total_count");
            CanComment = obj.GetBoolean("can_comment");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="FacebookCommentsSummary"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="Newtonsoft.Json.Linq.JObject"/> to parse.</param>
        /// <returns>Returns an instance of <see cref="FacebookCommentsSummary"/>.</returns>
        public static FacebookCommentsSummary Parse(JObject obj) {
            return obj == null ? null : new FacebookCommentsSummary(obj);
        }

        #endregion

    }

}