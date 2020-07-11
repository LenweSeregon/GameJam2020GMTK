using UnityEditor;

namespace Equilibrium
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CustomEditor(typeof(IntVariable))]
    public class IntVariableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawPropertiesExcluding(serializedObject, "m_hasMinValue", "m_hasMaxValue", 
                "m_minValue", "m_maxValue");

            SerializedProperty hasMinValue = serializedObject.FindProperty("m_hasMinValue");
            SerializedProperty hasMaxValue = serializedObject.FindProperty("m_hasMaxValue");
            SerializedProperty minValue = serializedObject.FindProperty("m_minValue");
            SerializedProperty maxValue = serializedObject.FindProperty("m_maxValue");
            
            // MIN
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.PropertyField(hasMinValue, new GUIContent("Minimum value"));
                if (hasMinValue.boolValue)
                {
                    EditorGUILayout.PropertyField(minValue, GUIContent.none);
                }
            }
            EditorGUILayout.EndHorizontal();
            
            // MAX
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.PropertyField(hasMaxValue, new GUIContent("Maximum value"));
                if (hasMaxValue.boolValue)
                {
                    EditorGUILayout.PropertyField(maxValue, GUIContent.none);
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    } 
}

