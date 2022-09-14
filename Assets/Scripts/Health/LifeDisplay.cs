using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    PlayerHealth ph;

    private void Awake()
    {
        ph = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
       
        GetComponent<Text>().text = ph.GetLifes().ToString();

    }
}
