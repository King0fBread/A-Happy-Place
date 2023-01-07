using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivator : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private GameObject _playerUI;
    [SerializeField] private FlashlightLogic _playerFlashlight;

    [SerializeField] private GameObject _finalStaticBlackScreen;
    private PlayableDirector _director;
    private BoxCollider _thisCoxCollider;
    private void Awake()
    {
        _thisCoxCollider = GetComponent<BoxCollider>();
        _director = GetComponent<PlayableDirector>();
        _director.stopped += Director_Stopped;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _thisCoxCollider.enabled = false;
            _playerAnimator.enabled = true;
            _director.Play();

            _playerFlashlight.TryForceToogleFlashlight(true);
            _playerFlashlight.ToggleFlashlightPermisson(false);
            _playerUI.SetActive(false);
        }
    }
    private void Director_Stopped(PlayableDirector obj)
    {
        StartCoroutine(TransitionToMenuCoroutine());
    }
    private IEnumerator TransitionToMenuCoroutine()
    {
        _finalStaticBlackScreen.SetActive(true);
        SoundsManager.instance.PlaySound(SoundsManager.Sounds.EnvironmentWindbells);
        yield return new WaitForSeconds(5f);
        Cursor.lockState = CursorLockMode.None;
        SceneLoader.LoadScene(SceneLoader.Scenes.MenuScene);
    }

}
