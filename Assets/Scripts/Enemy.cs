using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle1 : MonoBehaviour
{
    private Vector3 startPosition;
    public Vector3 endOffset;
    public float speed;
    private float time;

    void Start()
    {
        startPosition = transform.position;
    }
   void Update ()
   {
        time += Time.deltaTime;
        transform.position = startPosition + (endOffset * Mathf.Sin(time * speed));
   }
}
