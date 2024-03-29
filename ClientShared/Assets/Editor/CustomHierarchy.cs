﻿using System.Linq;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[InitializeOnLoad]
public class CustomHierarchy : Editor
{
    static Vector2 offset = new Vector2(0, 0);

    static CustomHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
    }

    static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (gameObject == null)
            return;

        if (gameObject.name.Contains("---"))
        {
            Color fontColor = Color.white;
            Color backgroundColor = new Color(0.3f, 0.3f, 0.3f); //默认背景色

            var prefabType = PrefabUtility.GetPrefabAssetType(gameObject);
            if (prefabType == PrefabAssetType.NotAPrefab)
            {
                if (Selection.instanceIDs.Contains(instanceID))
                {
                    fontColor = new Color(1, 1, 1, 0);
                    backgroundColor = new Color(0, 0, 0, 0); //选中颜色
                }
                Rect offsetRect = new Rect(selectionRect.position + offset, selectionRect.size);
                EditorGUI.DrawRect(selectionRect, backgroundColor);

                var lb_name = gameObject.name.Substring(3, gameObject.name.Length - 3);
                EditorGUI.LabelField(offsetRect, lb_name, new GUIStyle()
                {
                    normal = new GUIStyleState() { textColor = fontColor },
                    fontStyle = FontStyle.Bold
                });
            }
        }

        #region 快捷灯光设置

        var light = gameObject.GetComponent<Light>();
        if (light != null)
        {
            var so = new SerializedObject(light);
            so.Update();

            // ライトの色のプロパティを描画
            selectionRect.xMin += selectionRect.width - 40;
            var colorProp = so.FindProperty("m_Color");
            EditorGUI.PropertyField(selectionRect, colorProp, GUIContent.none);

            so.ApplyModifiedProperties();
            so.Dispose();
        }

        #endregion
    }
}
#endif