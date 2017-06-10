using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState
{

    public abstract void EnterState(Poseidon character);

    public abstract void Update(Poseidon character);

    public abstract void ExitState(Poseidon character);
}
