using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPause : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void unPause()
    {
        ShipManager.paused = false;
        transform.gameObject.SetActive(false);
    }
}
