using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Navigation : MonoBehaviour
{
    [SerializeField]
    private GameObject root;

    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = new Vector3(-2.5f, 8.5f, 0);
        Instantiate(root, _currentPosition, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject clickedObject = hit.transform.GameObject();
                Vector3 newPosition = clickedObject.transform.position;
                if (!gameObject.CompareTag("Root") && Vector3.Distance(_currentPosition, newPosition) == 1)
                {
                    Destroy(gameObject);
                    _currentPosition = newPosition;
                    Instantiate(root, _currentPosition, Quaternion.identity);
                }
            }
        }
    }
}
