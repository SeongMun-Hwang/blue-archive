using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveMapActive : MonoBehaviour
{
    public string sceneName;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            SceneManagerSystem.Instance.ChangeScene(sceneName);
        }
    }
}
