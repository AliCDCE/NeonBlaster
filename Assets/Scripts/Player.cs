using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newPos = transform.position;
        newPos.x = Mathf.Lerp(newPos.x, mousePos.x, Time.deltaTime * movementSpeed);
        newPos.x = Mathf.Clamp( newPos.x, -2.15f, 2.15f);
        transform.position = newPos;

        float rotation_factor = (mousePos.x-newPos.x)/2f;
        Rotate( rotation_factor );
    }
    private void Rotate( float rotation_factor )
    {
        Quaternion newRot = transform.localRotation;
        newRot.y = Mathf.Lerp(newRot.y, rotation_factor, Time.deltaTime * movementSpeed );
        transform.localRotation = newRot;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.CompareTag("Enemy") )
        {
            Die();
        }
    }

    // private void OnCollisionEnter2D(Collision2D other) 
    // {
    //     if ( other.gameObject.CompareTag("Enemy") )
    //     {
    //         Die();
    //     }
    // }

    private void Die()
    {
        levelManager.OpenGameOver();
    }

    public void SetShield( bool value )
    {
        transform.GetChild(2).gameObject.SetActive( value );
    }

}
