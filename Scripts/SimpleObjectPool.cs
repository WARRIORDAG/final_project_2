using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Pool;

public class SimpleObjectPool : MonoBehaviour
{
    public GameObject prefab;       // answer button prefab olarak �al��acak!!!objemi verdim prefab olarak bunu kaullanaca��m
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();      //soruda ka� tane ��k varsa ona g�re prefab olu�turuyoruz

    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        if (inactiveInstances.Count > 0 )
        {
            spawnedGameObject = inactiveInstances.Pop();        // ��klar fazla ise sil diyorum
        }

        else
        {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);     // ��klarda eksik varsa ekleme yap�yor
            
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        spawnedGameObject.SetActive(true);
        return spawnedGameObject;

    }

    public void ReturnObject(GameObject toReturn)       // butonu tekrar havuza g�ndermek i�in yaz�yoruz!!
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        if (pooledObject != null &&  pooledObject.pool == this )
        {
            toReturn.SetActive(false);

            inactiveInstances.Push(toReturn);

        }

        else                //bzie uyar� veriyor!!
        {
            Debug.LogWarning(toReturn.name + "sildim ");
            Destroy(toReturn);
        }
    }


 
}

public class PooledObject: MonoBehaviour       // s�n�f olu�turduk ve a�a��daki  
{
    public SimpleObjectPool pool; 
}
