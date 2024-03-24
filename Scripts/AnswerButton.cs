using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    private AnswerData answerData;

    private GameController gameController;

    private Button btn;    //??  bu kýsýmlarý sonradan ekledim!!

    // Start is called before the first frame update
    void Start()
    {
        btn = gameObject.GetComponent<Button>();        //???  sonradan ekledim!!!
        btn.onClick.AddListener(HandleClicked);         // ??? 

        gameController = FindObjectOfType<GameController>();
          
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    public void HandleClicked()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }


}
