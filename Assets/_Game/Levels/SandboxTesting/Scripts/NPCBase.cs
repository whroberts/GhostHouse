using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour, Interactable
{

    bool _firstUpdate = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (_firstUpdate)
        {
            Debug.Log("First Update");
            _firstUpdate = false;
        }
    }

    public void Interact()
    {
        Debug.Log("Interact");
    }
}
