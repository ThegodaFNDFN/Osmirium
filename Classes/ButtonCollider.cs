using System;
using UnityEngine;
using MelonLoader;
using static IIDKQuest.Menu.Main;
using static IIDKQuest.Settings;

namespace IIDKQuest.Classes
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class Button : MonoBehaviour
    {
        public Button(IntPtr ptr) : base(ptr) { }
        public string relatedText;

        public static float buttonCooldown = 0f;
        private static AudioSource audioSource;
        private static AudioClip DM_CGS_31;

        void Awake()
        {
            if (audioSource == null)
            {
                audioSource = new GameObject("ButtonSoundPlayer").AddComponent<AudioSource>();
                UnityEngine.Object.DontDestroyOnLoad(audioSource.gameObject);
                audioSource.playOnAwake = false;
                audioSource.loop = false;

                foreach (var clip in Resources.FindObjectsOfTypeAll<AudioClip>())
                {
                    if (clip.name == "DM-CGS-31")
                    {
                        DM_CGS_31 = clip;
                        break;
                    }
                }
            }
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (collider == buttonCollider && Time.time > buttonCooldown && menu != null)
            {
                buttonCooldown = Time.time + 0.2f;

                GorillaTagger.Instance.StartVibration(
                    rightHanded,
                    GorillaTagger.Instance.tagHapticStrength / 2f,
                    GorillaTagger.Instance.tagHapticDuration / 2f
                );

                if (DM_CGS_31 != null)
                    audioSource.PlayOneShot(DM_CGS_31, 0.16f);

                Toggle(this.relatedText);
            }
        }
    }
}
