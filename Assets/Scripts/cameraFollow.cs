using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float smoothspeed = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newposition = Vector3.Lerp(transform.position, target.position + offset, smoothspeed);
        transform.position = newposition;
    }
}
