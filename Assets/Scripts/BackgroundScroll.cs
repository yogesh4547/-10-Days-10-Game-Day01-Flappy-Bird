using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private float resetX = -10f;
    [SerializeField] private float startX = 10f;

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x <= resetX)
        {
            Vector3 pos = transform.position;
            pos.x = startX;
            transform.position = pos;
        }
    }
}
