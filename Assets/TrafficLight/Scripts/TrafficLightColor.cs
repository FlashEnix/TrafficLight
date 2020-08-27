using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TrafficLightColor
{
    [Header("Цвет сигнала")]
    [SerializeField]
    public Color Color;

    [Header("Время действия сигнала")]
    [SerializeField]
    public int Timer;

    [Header("Описание сигнала")]
    [SerializeField]
    public string Description;

    [Header("Трафик разрешен")]
    [SerializeField]
    public bool AllowTraffic;
}
