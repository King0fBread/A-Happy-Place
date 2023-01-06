using UnityEngine;
using UnityEngine.UI;

public class SceneLoadingBar : MonoBehaviour
{
    private Slider _sceneLoadingSlider;
    private void Awake()
    {
        _sceneLoadingSlider = GetComponent<Slider>();
    }
    private void Update()
    {
        _sceneLoadingSlider.value = SceneLoader.GetCurrentSceneLoadingProgress();
    }
}
