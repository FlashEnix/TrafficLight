using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float Speed;
    [SerializeField]
    private float distanceCrash = 2;
    protected bool _allowMove = true;
    protected Transform _transform;

    private void Awake()
    {
        _transform = transform;
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    private void Update()
    {
        checkCrash();
        if (_allowMove) transform.Translate(0, 0, Speed * Time.deltaTime);
    }

    private void checkCrash()
    {
        Ray ray = new Ray(_transform.position, Vector3.forward);
        _allowMove = !Physics.Raycast(ray, distanceCrash);
    }
}
