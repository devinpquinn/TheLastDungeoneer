using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witchlight : MonoBehaviour
{
    private bool inFlight = false;
    private bool inRecall = false;
    private Transform hand;
    private float flySpeed = 10f;
    private float recallSpeed = 50f;
    private Rigidbody rb;

    private void Start()
    {
        hand = Camera.main.gameObject.transform.Find("Hand");
        transform.parent = hand;
        transform.localPosition = hand.localPosition;
        transform.localRotation = Quaternion.identity;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !inFlight)
        {
            transform.parent = null;
            Vector3 facing = hand.forward;
            rb.velocity = facing * flySpeed;
            inFlight = true;
        }
        if (Input.GetMouseButtonDown(1) && inFlight)
        {
            inRecall = true;
        }
        if(inRecall)
        {
            transform.position = Vector3.MoveTowards(transform.position, hand.position, Time.deltaTime * recallSpeed);
            if(Vector3.Distance(transform.position, hand.position) < 0.01)
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
                transform.parent = hand;
                transform.localPosition = hand.localPosition;
                transform.localRotation = Quaternion.identity;
                inFlight = false;
                inRecall = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player") && inFlight)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
