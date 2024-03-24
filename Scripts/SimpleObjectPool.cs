using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Pool;

public class SimpleObjectPool : MonoBehaviour
{
    public GameObject prefab;       // answer button prefab olarak çalýþacak!!!objemi verdim prefab olarak bunu kaullanacaðým
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();      //soruda kaç tane þýk varsa ona göre prefab oluþturuyoruz

    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        if (inactiveInstances.Count > 0 )
        {
            spawnedGameObject = inactiveInstances.Pop();        // þýklar fazla ise sil diyorum
        }

        else
        {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);     // þýklarda eksik varsa ekleme yapýyor
            
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        spawnedGameObject.SetActive(true);
        return spawnedGameObject;

    }

    public void ReturnObject(GameObject toReturn)       // butonu tekrar havuza göndermek için yazýyoruz!!
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        if (pooledObject != null &&  pooledObject.pool == this )
        {
            toReturn.SetActive(false);

            inactiveInstances.Push(toReturn);

        }

        else                //bzie uyarý veriyor!!
        {
            Debug.LogWarning(toReturn.name + "sildim ");
            Destroy(toReturn);
        }
    }


 
}

public class PooledObject: MonoBehaviour       // sýnýf oluþturduk ve aþaðýdaki  
{
    public SimpleObjectPool pool; 
}
