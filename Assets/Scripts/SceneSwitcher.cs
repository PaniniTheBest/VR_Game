using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SceneSwitching(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SceneSwitching(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
    public void SceneSwitching(Scene scene)
    {
        SceneManager.LoadSceneAsync(scene.buildIndex);
    }
}
