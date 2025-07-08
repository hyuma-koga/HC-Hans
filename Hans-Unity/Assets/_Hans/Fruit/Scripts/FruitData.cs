using UnityEngine;

[CreateAssetMenu(menuName = "Fruit/FruitData", fileName = "FruitData")]
public class FruitData : ScriptableObject
{
    public string fruitType;
    public GameObject prefab;
}
