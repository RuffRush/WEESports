using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToScene : MonoBehaviour
    {
    public void MoveToScene(int sceneID)
        {
        SceneManager.LoadScene(sceneID);
        }
    }
