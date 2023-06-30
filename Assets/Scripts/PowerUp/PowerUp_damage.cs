using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PowerUp_damage : PowerUp
{
    [Header("value to multiply the player's damage by")]
    [SerializeField] private float value;

    public override async void ApplyPower()
    {
        Shooter player = GameObject.FindObjectOfType<Shooter>();
        player.ChangeDamage( value );
        await Task.Delay( (int)(duration*1000) );
        player.ChangeDamage( 1/value );
    }
}