using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PowerUp_fireRate : PowerUp
{
    [Header("value to add to fire rate")]
    [SerializeField] private float value;

    public override async void ApplyPower()
    {
        Shooter player = GameObject.FindObjectOfType<Shooter>();
        player.ChangeFireRate( value );
        await Task.Delay( (int)(duration*1000) );
        player.ChangeFireRate( -value );
    }
}