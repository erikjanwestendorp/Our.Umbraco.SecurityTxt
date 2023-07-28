using Umbraco.Cms.Core.Manifest;

namespace Our.Umbraco.SecurityTxt.Compose;

internal class ManifestFilter : IManifestFilter
{
    public void Filter(List<PackageManifest> manifests)
    {
        manifests.Add(new PackageManifest
        {
            PackageName = SecurityTxtConstants.Package.Name,
            Version = "1.0.0",
            Scripts = new []
            {
                "/App_Plugins/SecurityTxt/backoffice/SecurityTxt/detail.controller.js"
            },
            BundleOptions = BundleOptions.None
        });
    }
}
