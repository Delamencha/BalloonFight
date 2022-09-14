using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBall : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Launch();
    }

    private void Launch()
    {
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(0, y, z) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        switch (tag) 
        {
            case "Player":
                other.gameObject.GetComponent<PlayerHealth>().DecreaseHealth(1000);
                gameObject.SetActive(false);
                break;
            case "Boundary" :
                Bounce(other);
                break;
            case "Platform":
                Bounce(other);
                break;
            case "Bottom":
                gameObject.SetActive(false);
                break;

        }

    }

    private void Bounce(Collider other)
    {
        Vector3 thisPosition = transform.position;
        Vector3 otherPosition = other.transform.position;
        Vector3 boundExtent = other.bounds.extents;

        if(( thisPosition.z >= otherPosition.z - boundExtent.z && thisPosition.z <= otherPosition.z + boundExtent.z  ) &&
            (thisPosition.y > otherPosition.y + boundExtent.y || thisPosition.y < otherPosition.y - boundExtent.y))       //Ë®Æ½µ¯Éä
        {
            Vector3 temp = rb.velocity;
            temp.y = -temp.y;
            rb.velocity = temp;
        }
        else if ((thisPosition.z > otherPosition.z + boundExtent.z || thisPosition.z < otherPosition.z - boundExtent.z) && //ÊúÖ±µ¯Éä
            (thisPosition.y <= otherPosition.y + boundExtent.y && thisPosition.y >= otherPosition.y - boundExtent.y))
        {
            Vector3 temp = rb.velocity;
            temp.z = -temp.z;
            rb.velocity = temp;
        }

    }
}
