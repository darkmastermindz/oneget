//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a New-StronglyTypedCsFileForResx funciton.
//     To add or remove a member, edit your .ResX file then rerun buildCoreClr.ps1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.PackageManagement.Msu.Internal.Resources {
using System;
using System.Reflection;

/// <summary>
///   A strongly-typed resource class, for looking up localized strings, etc.
/// </summary>
[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]

internal class Messages {

    private static global::System.Resources.ResourceManager resourceMan;

    private static global::System.Globalization.CultureInfo resourceCulture;

    [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    internal Messages() {
    }

    /// <summary>
    ///   Returns the cached ResourceManager instance used by this class.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal static global::System.Resources.ResourceManager ResourceManager {
        get {
            if (object.ReferenceEquals(resourceMan, null)) {
                global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.PackageManagement.Msu.Internal.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
                resourceMan = temp;
            }
            return resourceMan;
        }
    }

    /// <summary>
    ///   Overrides the current thread's CurrentUICulture property for all
    ///   resource lookups using this strongly typed resource class.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal static global::System.Globalization.CultureInfo Culture {
        get {
            return resourceCulture;
        }
        set {
            resourceCulture = value;
        }
    }
    
    /// <summary>
    ///   Looks up a localized string similar to Package '{0}': Installation failed with Windows Update error code '{1}'. Please look at '{2}' for details.
    /// </summary>
    internal static string InstallFailed {
        get {
            return ResourceManager.GetString("InstallFailed", resourceCulture);
        }
    }

    /// <summary>
    ///   Looks up a localized string similar to Reboot is required to complete the installation operation.
    /// </summary>
    internal static string InstallRequiresReboot {
        get {
            return ResourceManager.GetString("InstallRequiresReboot", resourceCulture);
        }
    }

}
}
