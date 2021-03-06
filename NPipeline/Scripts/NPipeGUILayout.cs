﻿using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class NPipeGUILayout
{
    #if UNITY_EDITOR
    public static T Popup<T>(string[] labels, T[] values, T selectedValue, bool autoSelectFirst = false)
    {
        int selectedIndex = -1;
        for (int i = 0; i < labels.Length; i++)
        {
            if (values[i].Equals(selectedValue))
            {
                selectedIndex = i;
            }
        }

        int newIndex = EditorGUILayout.Popup(selectedIndex, labels);
        if (newIndex != selectedIndex)
        {
            return values[newIndex];
        }

        if (newIndex == -1 && autoSelectFirst && values.Length > 0)
        {
            return values[0];
        }

        return selectedValue;
    }

    public static T Toolbar<T>(string[] labels, T[] values, T selectedValue)
    {
        int selectedIndex = -1;
        for (int i = 0; i < labels.Length; i++)
        {
            if (values[i].Equals(selectedValue))
            {
                selectedIndex = i;
            }
        }

        int newIndex = GUILayout.Toolbar(selectedIndex, labels);
        if (newIndex != selectedIndex)
        {
            return values[newIndex];
        }

        if (newIndex == -1 && values.Length > 0)
        {
            return values[0];
        }

        return selectedValue;
    }
    #endif
}

