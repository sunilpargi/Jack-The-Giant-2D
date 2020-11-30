using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 5f);
    }

  

    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
