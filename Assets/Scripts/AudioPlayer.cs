using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private AudioClip shootingClip_player;
    [SerializeField] private AudioClip shootingClip_pet;
    [SerializeField] [Range(0f,1f)] private float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] private AudioClip damageClip_player;
    [SerializeField] private AudioClip damageClip_enemy;
    [SerializeField] [Range(0f,1f)] private float damageVolume = 1f;

    public void PlayShootingClipPlayer()
    {
        PlayClip( shootingClip_player, shootingVolume);
    }
    public void PlayShootingClipPet()
    {
        PlayClip( shootingClip_pet, shootingVolume);
    }

    public void PlayDamageClipPlayer()
    {
        PlayClip( damageClip_player, damageVolume);
    }

    public void PlayDamageClipEnemy()
    {
        PlayClip( damageClip_enemy, damageVolume);
    }

    private void PlayClip( AudioClip clip, float volume)
    {
        if ( clip != null )
        {
            AudioSource.PlayClipAtPoint( clip,
                                        Camera.main.transform.position,
                                        volume );
        }
    }
}