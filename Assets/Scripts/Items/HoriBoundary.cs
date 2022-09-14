using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoriBoundary : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if(obj.tag == "Player")
        {
            float horiDistace = obj.transform.position.z - transform.position.z;
            PlayerMovement pm = obj.GetComponent<PlayerMovement>();

            if (horiDistace > 0  && obj.GetComponent<Rigidbody>().velocity.z < 0) //◊Û±ﬂΩÁ
            {
                Teleport(obj.transform, true);

            }
            else if (horiDistace < 0 && obj.GetComponent<Rigidbody>().velocity.z > 0) //”“±ﬂΩÁ
            {
                Teleport(obj.transform, false);

            }
        }

        
    }


    private void Teleport(Transform player, bool isLeft)
    {
        Vector3 position = player.position;
        position.z = position.z + (isLeft ? 21 : -21); //
        player.position = position;
        
    }

}
