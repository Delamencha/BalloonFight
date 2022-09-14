using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] float period = 5f; //����
    [SerializeField]  Vector3 moveVector; //λ������

    Vector3 startPosition;
    float moveFactor; //λ�Ʊ���
    const float tau = Mathf.PI * 2;

    private void Start()
    {    
        startPosition = transform.position;

    }
    
    private void Update()
    {
       
        if (period <= Mathf.Epsilon) return;
        float cycle = Time.time / period; //period���Ʊ仯�ٶ�
        float sinWave = Mathf.Sin(cycle * tau);// sin(2��t/T)
        moveFactor = (sinWave + 1f) / 2f;

        Vector3 offset = moveVector * moveFactor;
        transform.position = startPosition + offset;
    }


}
