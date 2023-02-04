using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityTemplateProjects;

public class Navigation : MonoBehaviour
{
    [SerializeField]
    private GameObject treeRoot;

    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = new Vector3(0.5f, -0.5f, 0);
        Instantiate(treeRoot, _currentPosition, Quaternion.identity);
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

                if (!clickedObject.CompareTag("Root") && Vector3.Distance(_currentPosition, newPosition) == 1)
                {   
                    clickedObject.GetComponent<Value>().Liquidate();
                    Destroy(clickedObject);
                    _currentPosition = newPosition;
                    Instantiate(treeRoot, _currentPosition, Quaternion.identity);
                    /*Debug.Log(Currency.GetCurrency());*/
                }
            }
        }
    }
}
