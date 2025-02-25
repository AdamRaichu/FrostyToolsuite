using Frosty.Core;
using Frosty.Core.Controls.Editors;
using FrostySdk.Attributes;
using FrostySdk.IO;
using System.Windows.Controls;

namespace SoundEditorPlugin
{
    [DisplayName("Sound Options")]
    public class SoundOptions : OptionsExtension
    {
        [Category("Editor")]
        [DisplayName("Sound Volume")]
        [Description("Playback volume for sounds.")]
        [Editor(typeof(FrostySliderEditor))]
        [SliderMinMax(0.0f, 100.0f, 1.0f, 10.0f, true)]
        [EbxFieldMeta(EbxFieldType.Float32)]
        public float Volume { get; set; } = 20.0f;

        [Category("Experimental")]
        [DisplayName("Allow Duplicating Chunks with Multiple References")]
        [Description("Chunks can be referenced by multiple RuntimeVariations, and I haven't yet figured out how to correctly identify which track to duplicate for tracks like these. Enabling this setting will allow duplicating all variations again, but THIS WILL LEAD TO 'DUPLICATING' THE WRONG SOUND. This hopefully shouldn't matter much as you will be using your own audio anyway, but please be aware of this limitation.")]
        [EbxFieldMeta(EbxFieldType.Boolean)]
        public bool AllowDuplicatingMultiReferencedChunks { get; set; } = false;

        public override void Load()
        {
            Volume = Config.Get<float>("SoundVolume", 20.0f);
            AllowDuplicatingMultiReferencedChunks = Config.Get<bool>("AllowDuplicatingMultiReferencedChunks", false);
            //Volume = Config.Get<float>("Editor", "SoundVolume", 50);
        }

        public override void Save()
        {
            Config.Add("SoundVolume", Volume);
            Config.Add("AllowDuplicatingMultiReferencedChunks", AllowDuplicatingMultiReferencedChunks);
            Config.Save();
            //Config.Add("Editor", "SoundVolume", Volume);
        }

        public override bool Validate() => Volume >= 0.0f && Volume <= 100.0f;
    }
}
