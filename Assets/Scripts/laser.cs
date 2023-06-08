using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private string targetTag;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed ;
    }

    public float getDamage()
    {
        return damage;
    }

}
