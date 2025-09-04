using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListTurnOff : MonoBehaviour
{
    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
