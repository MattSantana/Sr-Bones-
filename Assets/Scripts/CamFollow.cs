using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing = 2.5f;
    [SerializeField] private float xMax = 0.06f;

    void FixedUpdate()
    {
        FollowCamera();
    }

    void FollowCamera()
    {
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);

            float meuX = Mathf.Clamp( transform.position.x, xMax, transform.position.x );


           transform.position = new Vector3( meuX, transform.position.y, transform.position.z);
        }
    }
}

