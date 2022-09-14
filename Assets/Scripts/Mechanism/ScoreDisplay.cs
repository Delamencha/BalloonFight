using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    CollisionHandler ch;

    private void Awake()
    {
        ch = GameObject.FindWithTag("Player").GetComponent<CollisionHandler>();
    }

    private void Update()
    {

        GetComponent<Text>().text = ch.GetPoints().ToString();

    }

}
