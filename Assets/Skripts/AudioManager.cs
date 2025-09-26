using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

// ��������� ������ ��� �����, �� ��� ������
public enum SFXType
{
    // UI �����
    ButtonClick,
    Win,
    Lose,

    // ����� �����
    Jump,
    Walk,
    Damage,
    Land,

    // ��������� ���� ����� ���
}

public class AudioManager : MonoBehaviour
{
    // ��������� �� AudioSource, ���� ������������� ������ ������
    [SerializeField] AudioSource bgAudioSource;
    [SerializeField] AudioSource sfxAudioSource;
    [SerializeField] private AudioMixer mainMixer;

    // ������� ��� �������� ������� �� �������� ����
    public Dictionary<SFXType, AudioClip> sfxClips = new Dictionary<SFXType, AudioClip>();

    [Header("UI Sounds")]
    [SerializeField] AudioClip buttonClickSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    [Header("Game Sounds")]
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip damageSound;
    [SerializeField] AudioClip landingSound;

    public static AudioManager Instance = null;

    void Awake()
    {
        // ���������� �������, ��� �� ��������������� if/else ��� switch
        sfxClips.Add(SFXType.ButtonClick, buttonClickSound);
        sfxClips.Add(SFXType.Win, winSound);
        sfxClips.Add(SFXType.Lose, loseSound);
        sfxClips.Add(SFXType.Jump, jumpSound);
        sfxClips.Add(SFXType.Walk, walkSound);
        sfxClips.Add(SFXType.Damage, damageSound);
        sfxClips.Add(SFXType.Land, landingSound);

        // ��� �������� ����� ���� ���� ���������, ��� �� ����� ����� ���� ���������� �������
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        // ����������� �������� ������������ �������
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            SetMixerVolume("music", musicVolume);
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            float sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
            SetMixerVolume("sfx", sfxVolume);
        }
    }

    // �������� ����� ��� ���������� �������� ������
    public void PlaySFX(SFXType sfxToPlay)
    {
        // ����������, �� ���� ���� � ������ ��������
        if (sfxClips.ContainsKey(sfxToPlay))
        {
            // ³��������� ���� �� ��������� PlayOneShot
            sfxAudioSource.PlayOneShot(sfxClips[sfxToPlay]);
        }
        else
        {
            Debug.LogWarning("���� " + sfxToPlay.ToString() + " �� ��������!");
        }
    }
    private void SetMixerVolume(string parameterName, float volume)
    {
        if (volume == 0)
        {
            mainMixer.SetFloat(parameterName, -80f);
        }
        else
        {
            mainMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        }
    }
}