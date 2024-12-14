using UnityEngine;
using Unity.Cinemachine;

public class CinemachineCamera : MonoBehaviour
{
    public CinemachineCamera cam;

    void Start()
    {
        CinemachineCore.CameraActivatedEvent.AddListener(OnCameraActivated);
        CinemachineCore.CameraUpdatedEvent.AddListener(OnBrainUpdated);
    }


    void OnCameraActivated (ICinemachineCamera.ActivationEventParams evt) {
        if (evt.IncomingCamera == (ICinemachineCamera) cam) {
            Debug.Log("Doing something");
        }
    }
    

    void OnBrainUpdated(CinemachineBrain brain) {
        // brain.   Do something with with the brain reference
    }

    void DoSomething (ICinemachineMixer origin, ICinemachineCamera incomingCamera){
        Debug.Log("This camera became active");
    }


    void Update()
    {
        
    }
}
