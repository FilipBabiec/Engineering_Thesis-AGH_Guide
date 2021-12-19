using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowScript : MonoBehaviour
{
    bool toggled;
    public GameObject Camera;
    public GameObject Player;
    public Button FollowButton;
    public Sprite Image;
    public Sprite ImageAlt;

    void Awake()
    {
        toggled = false;
    }
    public void OnClickFollow()
    {
        toggled = !toggled;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggled == true)
        {
            GetComponent<CameraControl>().enabled = false;
            FollowButton.image.sprite = ImageAlt;

            Camera.transform.position = new Vector3(Player.transform.position.x, 180, Player.transform.position.z - 100);
            Camera.transform.rotation = Quaternion.Euler(60, Player.transform.rotation.y, Player.transform.rotation.z);
        }
        else if (toggled == false)
        {
            GetComponent<CameraControl>().enabled = true;
            FollowButton.image.sprite = Image;
        }


    }
}