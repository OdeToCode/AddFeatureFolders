using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace OdeToCode.AddFeatureFolders
{
    public class FeatureControllerModelConvention : IControllerModelConvention
    {
        private readonly string _folderName;
        private readonly Func<ControllerModel, string> _nameDerivationStrategy;

        public FeatureControllerModelConvention(FeatureFolderOptions options)
        {
            if(options == null)
                throw new ArgumentNullException(nameof(options));

            _folderName = options.FeatureFolderName;
            _nameDerivationStrategy = options.DeriveFeatureFolderName ?? DeriveFeatureFolderName;
        }

        public void Apply(ControllerModel model)
        {
            if(model == null)
                throw new ArgumentNullException(nameof(model));

            var featureName = _nameDerivationStrategy(model);
            model.Properties.Add("feature", featureName);
        }

        private string DeriveFeatureFolderName(ControllerModel model)
        {
            var @namespace = model.ControllerType.Namespace;
            var result = @namespace.Split('.')
                                   .SkipWhile(s => s != _folderName)
                                   .Aggregate("", Path.Combine);

            return result;
        }
    }
}
