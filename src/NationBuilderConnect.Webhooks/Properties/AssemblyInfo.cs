using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("Proximity Mobile")]
[assembly: AssemblyProduct("NationBuilderConnect")]
[assembly: AssemblyCopyright("Copyright © Proximity Mobile 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//[assembly: AssemblyVersion("1.0.*")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]

#if !PCL
[assembly: NeutralResourcesLanguage("en")]
#endif