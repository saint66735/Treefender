using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    public float time = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }
}
