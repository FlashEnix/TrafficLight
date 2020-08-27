using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(TrafficLightController))]
public class TrafficLightControllerEditor : Editor
{
    private TrafficLightController _controller;
    private bool _showOptions;

    private void OnEnable()
    {
        _controller = (TrafficLightController)target;
    }

    public override void OnInspectorGUI()
    {
        if (_controller.Colors.Count > 0)
        {
            foreach (TrafficLightColor color in _controller.Colors)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("X",GUILayout.Width(20),GUILayout.Height(20)))
                {
                    _controller.Colors.Remove(color);
                    break;
                }
                EditorGUILayout.EndHorizontal();
                color.Color = EditorGUILayout.ColorField("Цвет сигнала", color.Color);
                color.Timer = EditorGUILayout.IntField("Время действия", color.Timer);
                color.Description = EditorGUILayout.TextField("Описание", color.Description);
                color.AllowTraffic = EditorGUILayout.Toggle("Трафик разрешен", color.AllowTraffic);
                EditorGUILayout.EndVertical();
            }   
        }
        else
        {
            EditorGUILayout.LabelField("Нет элементов в списке");
        }

        if (GUILayout.Button("Добавить"))
        {
            _controller.Colors.Add(new TrafficLightColor());
        }

        _showOptions = EditorGUILayout.Foldout(_showOptions, "Доп параметры");

        if (_showOptions)
        {
            _controller.TrafficLight = (MeshRenderer)EditorGUILayout.ObjectField("Префаб для покраски", _controller.TrafficLight, typeof(MeshRenderer), true);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(_controller);
            EditorSceneManager.MarkSceneDirty(_controller.gameObject.scene);
        }
    }
}
