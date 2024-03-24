using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour   //inheritance to class to class
{
   

    // private variables!!  ilk başta ayarlamaları yapmak için public yapmıştım
    private float speed = 20.0f;     // aracın ileri doğru hareketi için değişken tanımladım!!       // I defined public variable to modify to access speed variable in UNITY!!
    private float turnSpeed = 25.0f;        // sağ sol için değişken
    private float horizontalInput;   // sağ sol yapmak için tanımladım
    private float forwardInput;      // ileri geri hareketi için değişken tanımladım
    // Start is called before the first frame update
    
    void Start()        // start and update is a method
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        // this is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");      // sol sağ yapmak için yazdım!!
        forwardInput = Input.GetAxis("Vertical");           //ileri geri yapmak için yazdım!!

        // we'll move the vehicle forward based on vertical input
        //transform.Translate(0,0,0.3f);                   // 1. option I use lower case transform because of it's just my vehicle 0.3 is speed means
        //transform.Translate(Vector3.forward);               // 2. option
        //transform.Translate(Vector3.forward * Time.deltaTime * 15);         // I'm arranging / adding speed!!  1 saniyede 15 unit mesafe kat ediyor!!!
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);      // I use speed variable that I access in unity
        
        // we'll turn the vehicle based on horizontal input
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);      // 1 . options sağ sol yapmak için kullanıyorum
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);         // araç sağ sol mantıklı yapsın diye yazdım


    }

   
    public void ReuturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void fortuneWheel()
    {
        SceneManager.LoadScene("zCark");
    }


   

}
