using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PowerUp_pet : PowerUp
{
    [SerializeField] private GameObject pet;

    public override async void ApplyPower()
    {
        GameObject instance = Instantiate( pet, new Vector2(0,-8), Quaternion.identity);
        await Task.Delay( (int)(duration*1000) );
        instance.GetComponent<Shooter_pet>().Disable();
        Destroy( instance, 3);
    }
}