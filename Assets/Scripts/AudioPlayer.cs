using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    [Header("Explosion")]
    [SerializeField] AudioClip explosionSound;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }
    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootSound()
    {
        PlayClip(shootingSound, shootingVolume);
    }
    public void PlayExplosionSound()
    {
        PlayClip(explosionSound, explosionVolume);
    }
    private void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }
    }
}
