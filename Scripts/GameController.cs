using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class GameController : MonoBehaviour
{

    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    // daha önce yazdýðýmýz scriptlere buran ulaþacaðýz!!
    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    // sorumuzda kaç tane þýk varsa liste olarak çekeceðiz!!
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();  
     

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        playerScore = 0;
        questionIndex = Random.Range(0,4);          // 5 soru sorduðumu farz ediyorum ve sorular karýþýk geliyor

        ShowQuestion();         // aþaðýda metot oluþturduk burada çaðýrýyorum!!
        isRoundActive = true;
    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i ++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedCorrectAnswer;   
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        }

        if (questionPool.Length > questionIndex +1)     // soru havuzumuzda bir sonraki soruyu so
        {
            questionIndex++;
            ShowQuestion();
        }

        else
        {
            EndRound();         // oyunu bitir diye metot oluþturduk
        }
    }

    public void EndRound()
    {
        isRoundActive = false;

        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReuturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void fortuneWheel()
    {
        SceneManager.LoadScene("zCark");
    }


    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();

    }
    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0)
            {
                EndRound() ;
            }
        }
        
    }
}
