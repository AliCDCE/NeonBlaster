using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;

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
        var rotation_factor = (mousePos.x-newPos.x)/2f;
        transform.position = newPos;

        Quaternion newRot = transform.localRotation;
        newRot.y = Mathf.Lerp(newRot.y, rotation_factor, Time.deltaTime * movementSpeed );
        transform.localRotation = newRot;
    }
}
