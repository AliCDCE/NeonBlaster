using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAntiRotate : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    void Update()
    {
        transform.eulerAngles = new Vector3( 0, 0, -parent.transform.rotation.z);
    }
}
