using System;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivator : MonoBehaviour
{
    [SerializeField] private GameObject _playerUI;
    private PlayableDirector _director;
    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();
        _director.stopped += Director_Stopped;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _director.Play();
            _playerUI.SetActive(false);
        }
    }
    private void Director_Stopped(PlayableDirector obj)
    {
        Debug.Log("ye");
    }

}
