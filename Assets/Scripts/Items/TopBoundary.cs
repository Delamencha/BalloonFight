using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBoundary : MonoBehaviour
{
    [SerializeField] float limitVelocity = 0.5f;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 temp = rb.velocity;
            temp.y = Mathf.Min(temp.y, limitVelocity);
            rb.velocity = temp;
        }
    }

}
