using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectweight : MonoBehaviour
{
    public float mass;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = mass;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
