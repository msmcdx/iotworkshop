using Iot.Models;

namespace IoT.Web.ViewModels
{
    /// <summary>
    /// Class CategoryViewModel.
    /// </summary>
    public class CategoryViewModel
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public Category Category { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CategoryViewModel"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool Selected { get; set; }
    }
}