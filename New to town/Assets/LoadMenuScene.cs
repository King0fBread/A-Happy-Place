using UnityEngine;

public class LoadMenuScene : MonoBehaviour
{
    public void LoadMenuSceneAsync()
    {
        SceneLoader.LoadScene(SceneLoader.Scenes.MenuScene);
    }
}
