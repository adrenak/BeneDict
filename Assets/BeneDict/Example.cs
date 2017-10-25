using System.Collections.Generic;
 
using UnityEngine;
 
public class Example : MonoBehaviour {
 
    [SerializeField]
    private StringIntDictionary stringIntegerStore = StringIntDictionary.New<StringIntDictionary>();
    private Dictionary<string, int> stringIntegers {
        get { return stringIntegerStore.dictionary; }
    }
 
    [SerializeField]
    private GameObjectFloatDictionary gameObjectFloatStore = GameObjectFloatDictionary.New<GameObjectFloatDictionary>();
    private Dictionary<GameObject, float> screenshots {
        get { return gameObjectFloatStore.dictionary; }
    }
}
