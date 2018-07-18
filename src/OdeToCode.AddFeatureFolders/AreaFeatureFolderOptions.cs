namespace OdeToCode.AddFeatureFolders
{
    public class AreaFeatureFolderOptions
    {
        /// <summary>
        /// Options to control the area feature folders
        /// </summary>
        public AreaFeatureFolderOptions() : this(new FeatureFolderOptions())
        {
        }
        
        /// <summary>
        /// Options to control the area feature folders
        /// </summary>
        /// <param name="options">Can read options from <see cref="FeatureFolderOptions"/> if non default options are chosen</param>
        public AreaFeatureFolderOptions(FeatureFolderOptions options)
        {
            AreaFolderName = "Areas";
            DefaultAreaViewLocation = $@"Areas\{{2}}\{options.FeatureNamePlaceholder}\{{0}}.cshtml";
            FeatureFolderName = options.FeatureFolderName;
        }

        /// <summary>
        /// The name of the root area folder on disk (default: 'Areas')
        /// </summary>
        public string AreaFolderName { get; set; }
        
        /// <summary>
        /// The default view location for areas. Helps intellisense find razor views. Example:
        ///     "\Areas\{2}\{Feature}\{0}.cshtml". 
        /// Razor replaces the area name into {2} placeholder, the controller name into {1} placeholder & view name into the {0} placeholder.
        /// The {Feature} placeholder must be the same name as the <see cref="FeatureFolderOptions"/> FeatureNamePlaceholder to replace
        /// the placeholder with the path to the feature folder.
        /// </summary>
        public string DefaultAreaViewLocation { get; set; }

        /// <summary>
        /// The name of the root feature folder on disk (default: 'Features')
        /// Only change this if there is a custom feature folder name set in the feature folder options.
        /// </summary>
        public string FeatureFolderName { get; set; }
    }
}