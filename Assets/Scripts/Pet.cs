using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    private GameObject player;
    [SerializeField] private float offset_X;
    [SerializeField] private float offset_Y;
    private Vector2 velocity = Vector2.zero;
    public bool go = true;

    private void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 targetPos;
        if ( go )
        {
            targetPos = new Vector2( player.transform.position.x , player.transform.position.y + offset_Y);
        }
        else
        {
            targetPos = new Vector2( transform.position.x, -8);
        }
        transform.position = Vector2.Lerp( transform.position, targetPos, movementSpeed*Time.deltaTime);
        transform.position = new Vector2( Mathf.Clamp( transform.position.x, -1.5f, 1.5f), transform.position.y);

        float rotation_factor = (targetPos.x - transform.position.x)*(3/5f);
        Rotate( rotation_factor );
    }
    private void Rotate( float rotation_factor )
    {
        Quaternion newRot = transform.localRotation;
        newRot.y = Mathf.Lerp(newRot.y, rotation_factor, Time.deltaTime * movementSpeed );
        transform.localRotation = newRot;
    }
}
