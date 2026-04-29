using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
    }

    // 重置敌人位置
    public void ResetPosition()
    {
        transform.position = startPosition;
        gameObject.SetActive(true);
    }
}