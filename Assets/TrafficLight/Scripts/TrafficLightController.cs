using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TrafficLightController : MonoBehaviour
{
    public event Action<TrafficLightColor> OnColorChange;

    [SerializeField]
    public List<TrafficLightColor> Colors;

    public MeshRenderer TrafficLight;
    private TrafficLightColor _currentColor;
    private float _timer;
    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        changeColor();
    }

    private void Update()
    {
        if (Time.time > _timer + _currentColor.Timer) changeColor();
    }

    private void changeColor()
    {
        _timer = Time.time;

        int indexColor = Colors.IndexOf(_currentColor);

        if (Colors.Count <= indexColor + 1)
        {
            _currentColor = Colors[0];
        } else
        {
            _currentColor = Colors[indexColor + 1];
        }
        TrafficLight.material.color = _currentColor.Color;
        _collider.enabled = !_currentColor.AllowTraffic;
        OnColorChange?.Invoke(_currentColor);
    }
}
