using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float maxAngle = 20;
    [SerializeField] private float maxOffset = 5f;
    [SerializeField] private float shake = 5f;
    private int seed = 4;
    private float timeCounter = 0;
    private bool isShaking = true;
    
    Rigidbody2D rb;
    
    private void Start()
    {
        rb = Player.Instance.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetCamera();
    }

    private Vector2 CheckPlayerPosition()
    {
        Vector2 position = rb.transform.position;
        return position;
    }

    private Vector2 GetRandomOffset(int seed)
    {
        Vector2 randomOffset = new Vector2(Mathf.Clamp(Mathf.PerlinNoise((float)seed, timeCounter), 0f, maxOffset), Mathf.Clamp(Mathf.PerlinNoise((float)(seed + 5f), timeCounter), 0f, maxOffset));
        return randomOffset;
    }

    private float GetRandomAngle(int seed)
    {
        float angle = Mathf.Clamp(Mathf.PerlinNoise((float)seed, timeCounter), 0, maxAngle);
        return angle;
    }

    private void SetCamera()
    {
        if (isShaking)
        {
            Vector3 position = new Vector3((CheckPlayerPosition().x + GetRandomOffset(seed).x) * shake, (CheckPlayerPosition().y + GetRandomOffset(seed).y) * shake, -10);
            timeCounter += Time.deltaTime;
            this.transform.position = position;
            this.transform.eulerAngles = new Vector3(0, 0, GetRandomAngle(seed));
        }
        else
        {
            return;
        }
    }
}
