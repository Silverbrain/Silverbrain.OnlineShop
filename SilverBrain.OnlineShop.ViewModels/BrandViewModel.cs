using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.Resources;
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
        [Required(ErrorMessageResourceName = nameof(Messages.RequiredFieldErrorMessage), ErrorMessageResourceType = typeof(Messages))]
        public string Title { get; set; }


        public BrandImage Image { get; set; }
    }
}