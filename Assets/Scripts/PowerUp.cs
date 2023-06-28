using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float health_type;
    private float health;
    public float duration;
    [SerializeField] private TextMeshProUGUI health_text;
    private Rigidbody2D rb;
    private Shooter player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<Shooter>();
    }

    void Start()
    {
        float xrand = Random.Range(-100f,100f);
        float yrand = Random.Range(-100f,0f);
        rb.AddForce( new Vector2( xrand, yrand));

        HealthSetup();
        ShowHealth();
    }

    private void HealthSetup()
    {
        health = health_type;
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
            TakeDamage( player.GetDamage() );
            Destroy(other);
        }
    }

    private void TakeDamage( float value )
    {
        health -= value;
        ShowHealth();
        if (health<=0)
        {
            ApplyPower();
            Destroy( gameObject );
        }
    }

    private void ShowHealth()
    {
        health_text.text = health.ToString();
    }

    public virtual async void ApplyPower() { await Task.Delay(0); }
}