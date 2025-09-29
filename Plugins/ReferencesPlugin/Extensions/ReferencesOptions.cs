using Frosty.Controls;
using Frosty.Core;
using FrostySdk.Attributes;
using FrostySdk.IO;

namespace ReferencesPlugin.Extensions
{
    [DisplayName("References Options")]
    public class ReferencesOptions : OptionsExtension
    {
        [Category("References")]
        [DisplayName("Show NetRegs")]
        [Description("If `false`, NetworkRegistryAssets will be hidden from the \"References to ___\" tab.")]
        [EbxFieldMeta(EbxFieldType.Boolean)]
        public bool ShowNetRegs { get; set; } = true;

        [Category("References")]
        [DisplayName("Show MVDBs")]
        [Description("If `false`, MeshVariationDatabase assets will be hidden from the \"References to ___\" tab.")]
        [EbxFieldMeta(EbxFieldType.Boolean)]
        public bool ShowMVDBs { get; set; } = true;

        public override void Load()
        {
            ShowNetRegs = Config.Get<bool>("References.ShowNetRegs", true);
            ShowMVDBs = Config.Get<bool>("References.ShowMVDBs", true);
        }

        public override void Save()
        {
            Config.Add("References.ShowNetRegs", ShowNetRegs);
            Config.Add("References.ShowMVDBs", ShowMVDBs);
            Config.Save();
        }
    }
}
