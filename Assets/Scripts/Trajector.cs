using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajector : MonoBehaviour
{
    public float v0;

    private float alpha = Mathf.PI / 2;
    private float R;
    private float p;
    private float e;
    private float g = 9.8f;
    private float t = 0;

    private float r(float x)
    {
        return p / (1 + e * Mathf.Cos(x));
    }

    void Start()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        R = Mathf.Sqrt(x * x + y * y);
        e = Mathf.Sqrt(1 + Mathf.Pow(v0 * Mathf.Cos(alpha * Mathf.PI / 180) / (g * R), 2) * (v0 * v0 - 2 * g * R));
        p = Mathf.Pow(v0 * Mathf.Cos(alpha * Mathf.PI / 180), 2) / g;
    }


    
    void Update()
    {
        t += Time.deltaTime;
        transform.position = new Vector3(r(t) * Mathf.Cos(t), r(t) * Mathf.Sin(t), 0);
    }
}
