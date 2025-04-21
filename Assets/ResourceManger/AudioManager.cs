using MoreMountains.Tools;
using Tools;
using UnityEngine;

namespace ResourceManger
{
    public class AudioManager : MMSingleton<AudioManager>
    {
        [SerializeField] private AudioSource uiAudioSource;
        [SerializeField] private AudioClip clickBtnSound;

        public void Init()
        {
            // clickBtnSound = ResourcesManager.Instance.Load<AudioClip>("Audio/click_001");
        }

        public void PlaySound()
        {
            
        }

        public void PlayButtonClickSound()
        {
            uiAudioSource.PlayOneShot(clickBtnSound);
        }
    }
}