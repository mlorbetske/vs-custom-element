using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace VSCustomElement
{
    [Guid(CommandConstants.VSCustomElementPackageGuid)]
    [ProvideAutoLoad(UIContextGuids80.SolutionExists)]
    [InstalledProductRegistration("#110", "#112", "0.0.1", IconResourceID = 400)]
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), PackageRegistration(UseManagedResourcesOnly = true)]
    public sealed class VSCustomElementPackage : Package
    {

    }
}
