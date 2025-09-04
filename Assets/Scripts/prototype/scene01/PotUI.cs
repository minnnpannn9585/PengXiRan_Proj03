using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotUI : MonoBehaviour
{
    bool canClose = false;

    private void OnEnable()
    {
        Invoke("EnableClose", 0.5f);
    }

    private void EnableClose()
    {
        canClose = true;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && canClose)
        {
            gameObject.SetActive(false);
            canClose = false;
        }
    }
}
