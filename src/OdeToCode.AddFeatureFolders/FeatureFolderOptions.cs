using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace OdeToCode.AddFeatureFolders
{
    /// <summary>
    /// Options to control the behavior of feature folders
    /// </summary>
    public class FeatureFolderOptions
    {
        public FeatureFolderOptions()
        {
            FeatureFolderName = "Features";
            DeriveFeatureFolderName = null;
            FeatureNamePlaceholder = "{Feature}";
            DefaultViewLocation = @"\Features\{0}\{1}.cshtml";
            EnableAreas = false;
            AreaFolderName = "Areas";
            DefaultAreaViewLocation = @"\Areas\{2}\{0}\{1}.cshtml";
        }

        /// <summary>
        /// The name of the root feature folder on disk (default: 'Features')
        /// </summary>
        public string FeatureFolderName { get; set; }

        /// <summary>
        /// Given a ControllerModel object, returns the path to the feature folder.
        /// Only set this property if you want to override the default logic.
        /// The default logic takes the namespace of a Controller and assumes the 
        /// namespace maps to a folder. Examples:
        ///     Project.Name.Features.Admin.ManageUsers -> Features\Admin\ManageUsers
        ///     Project.Name.Features.Admin -> Features\Admin
        /// Note the name "Features" is set by the FeatureFolderName property. 
        /// </summary>
        public Func<ControllerModel, string> DeriveFeatureFolderName { get; set; }


        /// <summary>
        /// Used internally in RazorOptions.ViewLocationFormats strings. The Default is {Feature},
        /// so the first format string in Razor options will be {Feature}\{0}.cshtml. Razor places 
        /// the view name into the {0} placeholder, the FeatureViewLocationExander class in this project
        /// replaces {feature} with the feature path derived from the ControllerModel
        /// </summary>
        public string FeatureNamePlaceholder { get; set; }

        /// <summary>
        /// The default view location. Helps intellisense find razor views. Example:
        ///     "\Features\{0}\{1}.cshtml". 
        /// Razor replaces the controller name into {0} placeholder & view name into the {1} placeholder. 
        /// </summary>
        public string DefaultViewLocation { get; set; }

        /// <summary>
        /// Enables support for areas (default: false)
        /// </summary>
        public bool EnableAreas { get; set; }

        /// <summary>
        /// The name of the root area folder on disk (default: 'Areas')
        /// </summary>
        public string AreaFolderName { get; set; }

        /// <summary>
        /// The default view location for areas. Helps intellisense find razor views. Example:
        ///     "\Areas\{2}\{0}\{1}.cshtml". 
        /// Razor replaces the area name into {2} placeholder, the controller name into {0} placeholder & view name into the {1} placeholder. 
        /// </summary>
        public string DefaultAreaViewLocation { get; set; }
    }
}
