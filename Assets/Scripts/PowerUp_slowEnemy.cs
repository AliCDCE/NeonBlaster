using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PowerUp_slowEnemy : PowerUp
{
    [Header("value to multiply the enemy's speed by")]
    [SerializeField] private float value;
    [SerializeField] private Rigidbody2D enemy;

    public override async void ApplyPower()
    {
        enemy.gravityScale *= value;
        await Task.Delay( (int)(duration*1000) );
        enemy.gravityScale *= (1/value);
    }
}