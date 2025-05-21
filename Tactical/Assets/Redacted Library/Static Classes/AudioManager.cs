using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Redacted.Component.Audio
{
    /// <summary>
    /// AudioManager class for managing audio in the game.
    /// </summary>
    /// <remarks>
    /// Use OnCreated() to replace awake() for initialization.
    /// Read Documentation for more information about methods and properties.
    /// </remarks>
    [AddComponentMenu("Redacted/Audio/AudioManager")]
    [DisallowMultipleComponent]
    public sealed class AudioManager : RDCTStaticClasses
    {
        [SerializeField] private Audios[] audios;
        [Tooltip("Same Number as the AudioType Lenght")][SerializeField] private AudioSourcesCollection[] audioSources;
        public static AudioManager Instance { get; private set; }

        public bool PlayAudio(string audioname, AudioSource aSource = null)
        {
            foreach (var audio in audios)
            {
                if (audio.audioName == audioname)
                {
                    if (audio.source)
                        Play(audio);
                    else
                    {
                        if (aSource)
                        {
                            audio.source = aSource;
                        }
                        else
                        {
                            Debug.LogWarning($"Audio Source not assigned for {audioname}. Please assign an Audio Source or pass one as a parameter.");
                            return false;
                        }
                    }
                    break;
                }
            }
            return true;
        }

        private void Play(Audios a)
        {
            a.source.loop = a.clipSettings.loop;
            a.source.clip = a.clip;
            a.source.volume = a.volume;
            a.source.priority = a.priority;
            a.source.pitch = a.clipSettings.pitch;
            a.source.spatialBlend = a.clipSettings.audioSpace == AudioSpace.Dimension3 ? 1 : 0;
            a.source.bypassEffects = a.bypassSetting.bypassEffects;
            a.source.bypassListenerEffects = a.bypassSetting.bypassListenerEffects;
            a.source.bypassReverbZones = a.bypassSetting.bypassReverbZones;
            a.audioState = AudioState.Playing;
            a.source.Play();
        }

        public bool PauseAudio(string audioname)
        {
            foreach (var audio in audios)
            {
                if (audio.audioName == audioname)
                {
                    if (audio.source.isPlaying)
                    {
                        audio.source.Pause();
                        audio.audioState = AudioState.Paused;
                    }
                    else
                    {
#if REDACTED_DEBUG
                        Debug.LogWarning($"Audio {audioname} is not playing.");
#endif
                        return false;
                    }
                    break;
                }
            }
            return true;
        }

        public bool PauseAudioAll()
        {
            foreach (var audio in audios)
            {
                if (audio.audioState == AudioState.Playing)
                {
                    audio.source.Pause();
                    audio.audioState = AudioState.Paused;
                }
            }
            return true;
        }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            OnCreated();
        }

        override public void OnCreated()
        {
            Array.Resize(ref audioSources, Enum.GetNames(typeof(AudioType)).Length);
            var a = new GameObject();
            a.name = "Audio Manger Source";
            a.transform.SetParent(this.transform);

            for (int i = 0; i < Enum.GetNames(typeof(AudioType)).Length; i++)
            {
                audioSources[i].sourceName = $"{Enum.GetName(typeof(AudioType), i)} Source";
                audioSources[i].sourceRef = a.AddComponent<AudioSource>();
#if REDACTED_DEBUG
                Debug.Log($"Created {audioSources[i].sourceName} {Enum.GetName(typeof(AudioType),i)} With Instance ID of {audioSources[i].sourceRef.GetInstanceID()}");
#endif
            }

            foreach (var audio in audios)
            {
                switch(audio.audioType)
                {
                    case AudioType.Music:
                        audio.mixerGroup = Resources.Load<AudioMixerGroup>("Audio/Music");
                        audio.source = audioSources[(int)AudioType.Music].sourceRef;
                        break;
                    case AudioType.SFX:
                        audio.mixerGroup = Resources.Load<AudioMixerGroup>("Audio/SFX");
                        audio.source = audioSources[(int)AudioType.SFX].sourceRef;
                        break;
                    case AudioType.Voice:
                        audio.mixerGroup = Resources.Load<AudioMixerGroup>("Audio/Voice");
                        audio.source = audioSources[(int)AudioType.Voice].sourceRef;
                        break;
                    case AudioType.Ambience:
                        audio.mixerGroup = Resources.Load<AudioMixerGroup>("Audio/Ambience");
                        audio.source = audioSources[(int)AudioType.Ambience].sourceRef;
                        break;
                    case AudioType.UI:
                        audio.mixerGroup = Resources.Load<AudioMixerGroup>("Audio/UI");
                        audio.source = audioSources[(int)AudioType.UI].sourceRef;
                        break;
                }
            }
        }
    }

    [Serializable]
    public class AudioSourcesCollection
    {
        public string sourceName;
        public AudioSource sourceRef;
    }

    [Serializable]
    public class Audios
    {
        [Header("Attribute")]
        public string audioName;
        public AudioType audioType;
        public AudioState audioState;

        [Header("Reference")]
        public AudioClip clip;
        public AudioSource source;
        [HideInInspector] public AudioMixer mixer;
        [HideInInspector] public AudioMixerGroup mixerGroup;

        [Header("Clip")]

        public AudioBypassSetting bypassSetting;
        public ClipSettings clipSettings;

        [Range(0.0f, 1.0f)] public float volume = 1f;
        [Range(0.0f, 256.0f)] public int priority = 128;        
    }


    [Serializable]
    public struct AudioBypassSetting
    {
        public bool bypassEffects;
        public bool bypassListenerEffects;
        public bool bypassReverbZones;
    }

    [Serializable]
    public struct ClipSettings
    {
        public float pitch;
        public bool loop;
        public bool playOnAwake;
        public AudioSpace audioSpace;
    }

    public enum AudioType
    {
        Music,
        SFX,
        Voice,
        Ambience,
        UI
    }

    public enum AudioState
    {
        Playing,
        Paused,
        Stopped
    }

    public enum AudioSpace
    {
        Dimension3,
        Dimension2,
    }
}