using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenController : MonoBehaviour
{
    public void startFirstGame()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void startSecondGame()   // 2 oyun �ehirler sava��
    {
        SceneManager.LoadScene("MenuScreen2");
    }

    public void startThirdGame()        // 3 oyun ��lg�n kamyonet
    {
        SceneManager.LoadScene("MenuScreen3");      
    }
}


