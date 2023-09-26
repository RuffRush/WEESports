using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PrefabControlls : MonoBehaviour
{
    private static GameObject gameObjectPrefab { get; set; }


   public static IEnumerator RespawnObject(GameObject prefab)
    {
        gameObjectPrefab = prefab;
        yield return new WaitForSeconds(1);
        GameObject objPrefab = Resources.Load(prefab.ToString()) as GameObject;
        GameObject obj = Instantiate(objPrefab) as GameObject;
    }

   public static IEnumerator RemoveObject(GameObject prefab)
    {
        gameObjectPrefab = prefab;
        yield return new WaitForSeconds(1);
        Destroy(prefab);
    }
}
