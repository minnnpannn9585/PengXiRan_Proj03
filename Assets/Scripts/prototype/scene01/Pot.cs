using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public GameObject potCanvas;
    private void OnMouseDown()
    {
        potCanvas.SetActive(true);
    }
}
