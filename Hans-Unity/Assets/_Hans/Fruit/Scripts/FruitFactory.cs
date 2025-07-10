using UnityEngine;

[CreateAssetMenu(menuName = "Fruit/FruitFactory", fileName = "FruitFactory")]
public class FruitFactory : ScriptableObject
{
    public FruitData[] fruitDatas;

    public FruitBase CreateFruit(string fruitType, Vector3 spawnPosition)
    {
        foreach (var data in fruitDatas)
        {
            if (data.fruitType == fruitType)
            {
                GameObject obj = Instantiate(data.prefab, spawnPosition, Quaternion.identity);
                return obj.GetComponent<FruitBase>();
            }
        }
        return null;
    }
}