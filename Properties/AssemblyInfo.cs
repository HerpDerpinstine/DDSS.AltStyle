using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(DDSS_AltStyle.Properties.BuildInfo.Description)]
[assembly: AssemblyDescription(DDSS_AltStyle.Properties.BuildInfo.Description)]
[assembly: AssemblyCompany(DDSS_AltStyle.Properties.BuildInfo.Company)]
[assembly: AssemblyProduct(DDSS_AltStyle.Properties.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + DDSS_AltStyle.Properties.BuildInfo.Author)]
[assembly: AssemblyTrademark(DDSS_AltStyle.Properties.BuildInfo.Company)]
[assembly: AssemblyVersion(DDSS_AltStyle.Properties.BuildInfo.Version)]
[assembly: AssemblyFileVersion(DDSS_AltStyle.Properties.BuildInfo.Version)]
[assembly: MelonInfo(typeof(DDSS_AltStyle.MelonMain), 
    DDSS_AltStyle.Properties.BuildInfo.Name, 
    DDSS_AltStyle.Properties.BuildInfo.Version,
    DDSS_AltStyle.Properties.BuildInfo.Author,
    DDSS_AltStyle.Properties.BuildInfo.DownloadLink)]
[assembly: MelonGame("StripedPandaStudios", "DDSS")]
[assembly: VerifyLoaderVersion("0.6.5", true)]
[assembly: HarmonyDontPatchAll]