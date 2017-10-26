using System;
using UnityEditor;
using UnityEngine;

public class BeneDictWindow : EditorWindow {
    public string keyType = "";
    public string valueType = "";
    public string baseName = "";

    [MenuItem("Window/BeneDict")]
    static void Init() {
        BeneDictWindow window = (BeneDictWindow)EditorWindow.GetWindow(typeof(BeneDictWindow));
        window.title = "Generate SerializableDictionary code";
    }

    private void OnGUI() {
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("The Key Type", new GUILayoutOption[] { GUILayout.Width(155) });
        keyType = GUILayout.TextField(keyType, new GUILayoutOption[] { GUILayout.Width(200) });
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("The Value Type", new GUILayoutOption[] { GUILayout.Width(155) });
        valueType = GUILayout.TextField(valueType, new GUILayoutOption[] { GUILayout.Width(200) });
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Base Name", new GUILayoutOption[] { GUILayout.Width(155) });
        baseName = GUILayout.TextField(baseName, new GUILayoutOption[] { GUILayout.Width(200) });
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        GUILayout.Space(15);

        if (GUILayout.Button("Get DictionaryImplementation code", new[] { GUILayout.Width(300) })) {
            string TEMPLATE = @"
// ---------------
//  {0} => {1}
// ---------------
[Serializable]
public class {2}Dictionary : SerializableDictionary<{3}, {4}> {{ }}

";
            string op = String.Format(
                TEMPLATE,
                keyType,
                valueType,
                baseName,
                keyType,
                valueType
            );
            EditorGUIUtility.systemCopyBuffer = op;
            EditorUtility.DisplayDialog("BeneDict Message", "Copied to your clipboard. Go to SerializableDictionaryImplementations.cs and paste the generated code!", "OK");
        }

        if (GUILayout.Button("Get DrawerImplementation code", new[] { GUILayout.Width(300) })) {
            string TEMPLATE = @"
// ---------------
//  {0} => {1}
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof({2}Dictionary))]
public class {3}DictionaryDrawer : SerializableDictionaryDrawer<{4}, {5}> {{
    protected override SerializableKeyValueTemplate<{6}, {7}> GetTemplate() {{
        return GetGenericTemplate<Serializable{8}Template>();
    }}
}}
internal class Serializable{9}Template : SerializableKeyValueTemplate<{10}, {11}> {{ }}";

            string op = String.Format(
                TEMPLATE,
                keyType,
                valueType,
                baseName,
                baseName,
                keyType,
                valueType,
                keyType,
                valueType,
                baseName,
                baseName,
                keyType,
                valueType
            );
            EditorGUIUtility.systemCopyBuffer = op;
            EditorUtility.DisplayDialog("BeneDict Message", "Copied to your clipboard. Go to SerializableDictionaryDrawerImplementations.cs and paste the generated code!", "OK");
        }
    }

    private void Awake() {
        minSize = new Vector2(500, 250);
    }
}