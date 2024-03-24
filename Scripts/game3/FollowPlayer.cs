using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);     // kamera pozisyonunu ayarlamak için değişken oluşturdum bu değişkeni aşağıda kullandım

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    void LateUpdate()       // update yerine kamera daha akıcı olsun diye late update kullandım!!
    {
        // kamera pozisyonunu player güncel pozisyonuna eşitledim yazdığım scripti kameraya ekledim!!
        //transform.position = player.transform.position;     // 1. option current camera position I equalize player/vehicle current position!!
        // offset the camera behind the player/ vehicle by adding to the players position
        //transform.position = player.transform.position + new Vector3(0, 5, -7)  // // I have added to fix camera position vector 3
        transform.position = player.transform.position + offset;     // 3. option

    }
}
