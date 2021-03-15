using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualChangeAnimationButton : MonoBehaviour
{
    [SerializeField] VirtualButtonBehaviour virtualButton;
    // Start is called before the first frame update
    void Start()
    {
        virtualButton.RegisterOnButtonPressed(OnVirtualButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnVirtualButtonPressed(VirtualButtonBehaviour virtualButton)
    {
        AnimationControl.Instance.PlayNextAnimation();
        print("Play next animation");
    }
}
