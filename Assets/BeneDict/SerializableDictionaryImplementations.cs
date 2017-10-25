using System;
using UnityEngine;
using UnityEditor;

// ---------------
//  String => Int
// ---------------
[Serializable]
public class StringIntDictionary : SerializableDictionary<string, int> { }

[UnityEditor.CustomPropertyDrawer(typeof(StringIntDictionary))]
public class StringIntDictionaryDrawer : SerializableDictionaryDrawer<string, int> {
    protected override SerializableKeyValueTemplate<string, int> GetTemplate() {
        return GetGenericTemplate<SerializableStringIntTemplate>();
    }
}
internal class SerializableStringIntTemplate : SerializableKeyValueTemplate<string, int> { }

// ---------------
//  GameObject => Float
// ---------------
[Serializable]
public class GameObjectFloatDictionary : SerializableDictionary<GameObject, float> { }

[UnityEditor.CustomPropertyDrawer(typeof(GameObjectFloatDictionary))]
public class GameObjectFloatDictionaryDrawer : SerializableDictionaryDrawer<GameObject, float> {
    protected override SerializableKeyValueTemplate<GameObject, float> GetTemplate() {
        return GetGenericTemplate<SerializableGameObjectFloatTemplate>();
    }
}
internal class SerializableGameObjectFloatTemplate : SerializableKeyValueTemplate<GameObject, float> { }


// ---------------
//  string => string
// ---------------
[Serializable]
public class StringToStringDictionary : SerializableDictionary<string, string> { }

[UnityEditor.CustomPropertyDrawer(typeof(StringToStringDictionary))]
public class StringToStringDictionaryDrawer : SerializableDictionaryDrawer<string, string> {
    protected override SerializableKeyValueTemplate<string, string> GetTemplate() {
        return GetGenericTemplate<SerializableStringToStringTemplate>();
    }
}
internal class SerializableStringToStringTemplate : SerializableKeyValueTemplate<string, string> { }