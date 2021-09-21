using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;
    [SerializeField] PlayerCollisions playerCollisions;

    public bool controls;
    public Rigidbody rb;
   
    public Vector3 waveUpPos;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (controls) 
        {
            playerControls.TouchControl();
        }
    }
}