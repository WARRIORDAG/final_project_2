using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScreenController : MonoBehaviour
{
    public void startGame1()
    {
        SceneManager.LoadScene("TriviaGame");       // 1. oyunun start bas�nca trivias oyunu ba�l�yor!!  5 soru var 
    }

    public void startGame2()
    {
        SceneManager.LoadScene("secondGame");       // 1. oyunun start bas�nca trivias oyunu ba�l�yor!!  5 soru var 
    }
    public void startGame3()
    {
        SceneManager.LoadScene("thirdGame");       // 1. oyunun start bas�nca trivias oyunu ba�l�yor!!  5 soru var 
    }


    public void endGame()       // ��k��a bas�nca ana men�ye d�n�yor!!
    {
        SceneManager.LoadScene("mainScreen");

    }
}
