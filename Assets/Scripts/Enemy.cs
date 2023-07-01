using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int type;
    [SerializeField] private float health_type;
    private float health;
    [SerializeField] private TextMeshProUGUI health_text;
    [SerializeField] private GameObject next_enemy_prefab;
    private Rigidbody2D rb;
    private Shooter player;
    private ScoreKeeper scoreKeeper;
    private AudioPlayer audioPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Shooter>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerLaser"))
        {
            TakeDamage( player.GetDamage() );
            scoreKeeper.AddScore( (int)player.GetDamage() );
            Destroy(other);
        }
    }

    private void TakeDamage( float value )
    {
        health -= value;
        ShowHealth();
        if (health<=0)
        {
            die();
        }
        else
        {
            Resize();
        }
    }

    private void ShowHealth()
    {
        health_text.text = health.ToString();
    }

    private void Resize()
    {
        float factor = 2- health/health_type;
        transform.localScale = Vector3.one *factor;
    }

    private void die()
    {
        audioPlayer.PlayDamageClipEnemy();
        if (type == 0)
        {
            Destroy( gameObject );
        }
        else
        {
            GameObject instance1 = Instantiate( next_enemy_prefab, transform.position, Quaternion.identity);
            GameObject instance2 = Instantiate( next_enemy_prefab, transform.position, Quaternion.identity);
            Destroy( gameObject );
        }
    }

    public void ChangeSpeed( float value )
    {
        rb.gravityScale *= value;
    }
}
