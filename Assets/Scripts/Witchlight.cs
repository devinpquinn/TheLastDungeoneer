using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witchlight : MonoBehaviour
{
    private bool inFlight = false;
    private Transform parentPlayer;
    private float flySpeed = 6f;
    private Rigidbody rb;

    private void Start()
    {
        parentPlayer = Camera.main.gameObject.transform;
        transform.parent = parentPlayer;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !inFlight)
        {
            transform.parent = null;
            rb.velocity = parentPlayer.forward * flySpeed;
            inFlight = true;
        }
        if (Input.GetMouseButtonDown(1) && inFlight)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            transform.parent = parentPlayer;
            transform.localPosition = new Vector3(0f, 0f, 0f);
            inFlight = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
    }
}
