using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PowerUp_shield : PowerUp
{
    public override async void ApplyPower()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        player.SetShield( true );
        await Task.Delay( (int)(duration*1000) );
        player.SetShield( false );
    }
}