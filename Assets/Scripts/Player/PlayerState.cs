using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    //      Template class for all of the different states the player can be in

    protected PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    public abstract void StartState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
