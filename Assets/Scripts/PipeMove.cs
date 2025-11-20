using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PipeMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float destroyX = -10f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}