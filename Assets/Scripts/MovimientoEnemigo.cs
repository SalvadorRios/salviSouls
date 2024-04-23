using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public enum MovementPattern
    {
        Stationary,
        Circular,
        Zigzag
    }

    public MovementPattern currentPattern = MovementPattern.Stationary;
    public float speed = 5f;
    public float magnitude = 1f;

    private float angle = 0f;

    void Update()
    {
        switch (currentPattern)
        {
            case MovementPattern.Circular:
                MoveInCircle();
                break;
            case MovementPattern.Zigzag:
                MoveInZigzag();
                break;
            case MovementPattern.Stationary:
                // No movement
                break;
        }
    }

    void MoveInCircle()
    {
        angle += speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * magnitude;
        float z = Mathf.Sin(angle) * magnitude;
        transform.position = new Vector3(x, transform.position.y, z);
    }

    void MoveInZigzag()
    {
        transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time * speed) * magnitude, transform.position.y, transform.position.z + Mathf.Cos(Time.time * speed) * magnitude);
    }
}
