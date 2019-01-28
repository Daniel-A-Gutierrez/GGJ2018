using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string startScene;
    public string activeScene;
    // Start is called before the first frame update
    public void changeScene(string toPlay)
    {
        if(toPlay == "" )
        return;
        transform.Find(activeScene).gameObject.SetActive(false);
        transform.Find(toPlay).gameObject.SetActive(true);
        activeScene=toPlay;
    }
}
