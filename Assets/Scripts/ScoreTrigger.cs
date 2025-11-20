using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool hasScored = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasScored)
        {
            hasScored = true;
            GameManager.Instance.AddScore(1);
        }
    }
}
