using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    PlayerBaseState currentState;
    public PlayerMovingState MovingState = new PlayerMovingState();
    public PlayerCastingState CastingState = new PlayerCastingState();
    public PlayerHookingState HookingState = new PlayerHookingState();

    public Transform reticleStartPoint;
    public Transform reticleEndPoint;

    public GameObject reticlePrefab;
    public GameObject bobberPrefab;

    public GameObject currentBobber;


    // Start is called before the first frame update
    void Start()
    {
        currentState = MovingState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
