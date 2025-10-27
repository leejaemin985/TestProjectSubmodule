
namespace Utility.Sound
{

    public class GameAudioMixerController : CommonAudioMixerController<SoundType>
    {
        protected override string MIXER_PATH => "AudioMixer/GameAudioMixer";
        protected override string GROUP_BASE => "Group_{0}";
        protected override string VOLUME_BASE => "Volume_{0}";


        private static GameAudioMixerController instance;
        public static GameAudioMixerController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new();
                    instance.Initialize();
                }
                return instance;
            }
        }

        public float GetBGMVolume() => GetMixerGroupVolume(SoundType.BGM);
        public float GetEffectVolume() => GetMixerGroupVolume(SoundType.Effect);

        public void SetBGMVolume(float volume) => SetMixerGroupVolume(SoundType.BGM, volume);
        public void SetEffectVolume(float volume) => SetMixerGroupVolume(SoundType.Effect, volume);


    }
}