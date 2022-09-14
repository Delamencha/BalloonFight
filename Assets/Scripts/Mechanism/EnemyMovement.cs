using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] float period = 5f; //周期
    [SerializeField]  Vector3 moveVector; //位移向量

    Vector3 startPosition;
    float moveFactor; //位移变量
    const float tau = Mathf.PI * 2;

    private void Start()
    {    
        startPosition = transform.position;

    }
    
    private void Update()
    {
       
        if (period <= Mathf.Epsilon) return;
        float cycle = Time.time / period; //period控制变化速度
        float sinWave = Mathf.Sin(cycle * tau);// sin(2πt/T)
        moveFactor = (sinWave + 1f) / 2f;

        Vector3 offset = moveVector * moveFactor;
        transform.position = startPosition + offset;
    }


}
