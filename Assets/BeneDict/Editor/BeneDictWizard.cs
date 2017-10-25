// Creates a simple wizard that lets you create a Light GameObject
// or if the user clicks in "Apply", it will set the color of the currently
// object selected to red

using System;
using UnityEditor;
using UnityEngine;

public class BeneDictWizard : ScriptableWizard {
    [Header("The Key type. Ex:GameObject")]
    public string keyType;
    [Header("The value type. Ex:Renderer")]
    public string valueType;
    [Header("Suggested name : KeyToValue. Ex : GameObjectToRenderer")]
    public string baseName;

    [MenuItem("Window/BeneDict")]
    static void CreateWizard() {
        ScriptableWizard.DisplayWizard<BeneDictWizard>("Generate Serializable Dictionary", "Generate");
    }

    private void Awake() {
        minSize = new Vector2(500, 250);
    }

    void OnWizardCreate() {

        string TEMPLATE = @"
// ---------------
//  {0} => {1}
// ---------------
[Serializable]
public class {2}Dictionary : SerializableDictionary<{3}, {4}> {{ }}

[UnityEditor.CustomPropertyDrawer(typeof({5}Dictionary))]
public class {6}DictionaryDrawer : SerializableDictionaryDrawer<{7}, {8}> {{
    protected override SerializableKeyValueTemplate<{9}, {10}> GetTemplate() {{
        return GetGenericTemplate<Serializable{11}Template>();
    }}
}}
internal class Serializable{12}Template : SerializableKeyValueTemplate<{13}, {14}> {{ }}";

        string op = String.Format(
            TEMPLATE,
            keyType,
            valueType,
            baseName,
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
        EditorUtility.DisplayDialog("BeneDict Message", "Copied to your clipboard. Go to SerializableDictionaryImplementations.cs and paste the generated code there to use the serialized dictionary in your code!", "OK");
    }

    void OnWizardUpdate() {
        helpString = "Please set the color of the light!";
    }

    // When the user presses the "Apply" button OnWizardOtherButton is called.
    void OnWizardOtherButton() {
    }
}