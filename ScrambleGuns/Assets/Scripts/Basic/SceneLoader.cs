using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
