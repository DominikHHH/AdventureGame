using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    //      For changing between and updating the player's current state

    public PlayerState CurrentState;

    private List<PlayerState> allStates = new List<PlayerState>();

    public void ChangeState(System.Type newState)
    {
        CurrentState.ExitState();
        if (CurrentState = allStates.Find(x => x.GetType() == newState))
        {
            CurrentState.StartState();
        }
        else
        {
            Debug.Log("State transmission unsuccessful!");
        }
        
    }

    public void ExecuteState()
    {
        CurrentState.UpdateState();
    }


    private void Awake()
    {
        allStates.AddRange(GetComponents<PlayerState>());
    }

    private void Start()
    {
        CurrentState = allStates[0];
        CurrentState.StartState();
    }

    private void Update()
    {
        ExecuteState();
    }
}
