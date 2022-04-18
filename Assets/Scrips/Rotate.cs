using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float elapsedTime = 0f;
   [SerializeField] float speed = 3f;
    [SerializeField] float angleSpeed = 90;


    void Update()
    {
        elapsedTime += Time.deltaTime * speed;

        float t = Mathf.Abs( Mathf.Sin(elapsedTime * elapsedTime) - Mathf.Cos(elapsedTime));




        transform.RotateAround(transform.position, transform.up, t * angleSpeed);

   

    }


}
