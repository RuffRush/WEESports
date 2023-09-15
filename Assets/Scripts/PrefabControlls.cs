using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabControlls : MonoBehaviour
{
    private GameObject prefab { get; set; }


    IEnumerator RespawnObject(GameObject prefab)
    {
        prefab = this.prefab;
        yield return new WaitForSeconds(1);
        GameObject objPrefab = Resources.Load(prefab.ToString()) as GameObject;
    }

    IEnumerator RemoveObject(GameObject prefab)
    {
        prefab = this.prefab;
        yield return new WaitForSeconds(1);
        Destroy(prefab);
    }
}
