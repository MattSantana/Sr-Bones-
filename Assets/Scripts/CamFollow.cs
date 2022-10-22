using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 2.5f;
    [SerializeField] private float xMax = 0.06f;
    [SerializeField] private float limiteX= 159.66f;


    void FixedUpdate()
    {
        FollowCamera();
    }

    void FollowCamera()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x + 6f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);

            float meuX = Mathf.Clamp( transform.position.x, xMax, limiteX );

           transform.position = new Vector3( meuX, transform.position.y, transform.position.z);
        }
    }
}

