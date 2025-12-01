using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility.Sound
{
    public class GameBGMSoundObject : GameSoundObject
    {
        private static GameBGMSoundObject instance;

        [SerializeField] private AudioClip lobbyClip;
        [SerializeField] private AudioClip battleClip;

        private bool IsLobbyClip = false;

        protected override float spatialBlendSetting => .0f;

        public override SoundType SoundType => SoundType.BGM;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                GameAudioMixerController.Instance.InitSoundObject(this);

                SceneManager.sceneLoaded += SceneLoadedListener;

                Audio.loop = true;
                PlayOneShot(lobbyClip);
                IsLobbyClip = true;
            }
            else
                Destroy(gameObject);
        }

        private void SceneLoadedListener(Scene scene, LoadSceneMode mode)
        {
            if (scene.name.Equals("InGame"))
            {
                IsLobbyClip = false;
                Audio.Stop();
                Audio.clip = battleClip;
                Audio.Play();
            }
            else
            {
                if (IsLobbyClip) return;
                IsLobbyClip = true;
                Audio.Stop();
                Audio.clip = lobbyClip;
                Audio.Play();
            }
        }
        
    }
}