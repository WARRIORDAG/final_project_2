using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    
public class DataController :MonoBehaviour
{
    public RoundData [] allRoundData;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);      // sahneyi silmeden diðer sahneye getim
        //SceneManager.LoadScene("MenuScreen");
        SceneManager.LoadScene("MainScreen");

    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];

    }

 
}
