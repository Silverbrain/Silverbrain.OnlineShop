using System.ComponentModel.DataAnnotations;

namespace Silverbrain.OnlineShop.ViewModels
{
    /// <summary>
    ///   <strong>BrandViewModel</strong> is used for passing <strong>Brand</strong> model data between view and other layers.</summary>
    public class BrandViewModel
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The <strong>Brand</strong> identifier.</value>
        public int? Id { get; set; } = 0;

        /// <summary>Gets or sets the Brand title.</summary>
        [MaxLength(50)]
        [Required(ErrorMessage = "نمیتواند خالی باشد")]
        public string Title { get; set; }
    }
}