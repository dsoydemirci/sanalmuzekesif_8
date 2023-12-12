using UnityEngine;
using UnityEngine.InputSystem;

public class DetectPlayerVersion : MonoBehaviour
{
    [SerializeField] private InputActionReference _vrHeadsetTrackingState;
    [SerializeField] private GameObject _playerVR;
    [SerializeField] private GameObject[] _vrRayInteractors;

    private void Awake()
    {
        // Ba�lang��ta VR oyuncu versiyonunu etkinle�tir
        ActivateVR();
    }

    private void Update()
    {
        bool isTracked = _vrHeadsetTrackingState.action.ReadValue<int>() != 0;

        if (!isTracked)
        {
            // VR ba�l��� tak�l� de�ilse, VR oyuncu versiyonunu etkinle�tir
            ActivateVR();
        }
    }

    private void ActivateVR()
    {
        _playerVR.transform.localPosition = new Vector3(0f, -1f, 0f);
        _playerVR.SetActive(true);

        // VR ray interaktif nesneleri etkinle�tir
        foreach (GameObject interactor in _vrRayInteractors)
        {
            interactor.SetActive(true);
        }
    }
}

