using UnityEngine;

public class SceneLoaderCallback : MonoBehaviour
{
    private bool _firstUpdateFrameActive = true;
    private void Update()
    {
        //reutrns callback when the Loading Scene is active
        if (_firstUpdateFrameActive)
        {
            _firstUpdateFrameActive = false;
            SceneLoader.LoaderCallback();
        }
    }
}
