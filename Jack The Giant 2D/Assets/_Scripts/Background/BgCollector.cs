using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("BG"))
        {
            target.gameObject.SetActive(false);
        }
    }
}
