using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBoundary : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().DecreaseHealth(1000);
        }
    }

}
