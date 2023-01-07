using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameToMenu : MonoBehaviour
{
    [SerializeField] private GameObject _playerUI;
    [SerializeField] private GameObject _blackScreen;
    private void OnEnable()
    {
        StartCoroutine(MenuTransitionCoroutine());
    }
    private IEnumerator MenuTransitionCoroutine()
    {
        _playerUI.SetActive(true);
        _blackScreen.SetActive(true);
        SoundsManager.instance.PlaySound(SoundsManager.Sounds.EnvironmentMetalDoorOpens);
        yield return new WaitForSeconds(1);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}
