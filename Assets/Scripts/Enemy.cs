using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public enum Type { small, medium, large} ;
    public Type type;
    private float health;
    [SerializeField] private TMP_Text  health_text;
    [SerializeField] private GameObject enemyPrefab;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float xrand = Random.Range(-60f,60f);
        float yrand = Random.Range(-100f,0f);
        rb.AddForce( new Vector2( xrand, yrand));

        switch (type)
        {
            case Type.small : health = 10;
            break;
            case Type.medium : health = 20;
            break;
            case Type.large : health = 40;
            break;
        }

        health_text.text = health.ToString();
    }

    void Update()
    {
        
    }

    public void setType( Type type )
    {
        this.type = type;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.CompareTag("FrontWall") )
        {
            // Vector2 newV = rb.velocity;
            // newV.x *= -10;
            // // rb.velocity = newV;
            // rb.AddForce(newV);
        }
        else if ( other.gameObject.CompareTag("BottomWall") )
        {
            // Vector2 newV = rb.velocity;
            // Debug.Log(newV);
            // newV.y *= -10;
            // Debug.Log(newV);
            // rb.velocity = newV;
            // rb.velocity = new Vector2( rb.velocity.x, -1*rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerLaser"))
        {
            TakeDamage( other.GetComponent<laser>().getDamage() );
            Destroy(other);
        }
    }

    private void TakeDamage( float value )
    {
        health -= value;
        health_text.text = health.ToString();
        if (health<=0)
        {
            die();
        }
    }

    private void die()
    {
        if ((int)type == 0)
        {
            Destroy( gameObject );
        }
        else
        {
            Type newType = (Type)((int)type-1);

            GameObject instance1 = Instantiate( enemyPrefab, transform.position, Quaternion.identity);
            instance1.GetComponent<Enemy>().setType( newType );

            GameObject instance2 = Instantiate( enemyPrefab, transform.position, Quaternion.identity);
            instance2.GetComponent<Enemy>().setType( newType );

        }

    }
}
