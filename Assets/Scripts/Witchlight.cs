using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witchlight : MonoBehaviour
{
    private bool inFlight = false;
    private Transform parentPlayer;
    private float flySpeed = 10f;
    private Rigidbody rb;
    public Vector3 offset;

    private void Start()
    {
        parentPlayer = Camera.main.gameObject.transform;
        transform.parent = parentPlayer;
        transform.localPosition = offset;
        transform.localRotation = Quaternion.identity;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !inFlight)
        {
            transform.parent = null;
            Vector3 facing = parentPlayer.forward;
            rb.velocity = facing * flySpeed;
            inFlight = true;
        }
        if (Input.GetMouseButtonDown(1) && inFlight)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            transform.parent = parentPlayer;
            transform.localPosition = offset;
            transform.localRotation = Quaternion.identity;
            inFlight = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
