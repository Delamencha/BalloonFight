using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] int points = 200;
    [SerializeField] float speed = 1f;
    [SerializeField] AudioClip balloonSFX;

    

    private void Update()
    {

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(balloonSFX, transform.position);
            other.gameObject.GetComponent<CollisionHandler>().GainPoints(points);
            gameObject.SetActive(false);
        }else if (other.gameObject.tag == "Boundary")
        {
            gameObject.SetActive(false);
        }
    }

}
