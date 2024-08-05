using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : BasePlayerController, Controls.IPlayer2Actions
{
    protected override InputActionMap GetInputActionMap()
    {
        return controls.Player2.Get();
    }

    protected override void SetCallbacks()
    {
        controls.Player2.SetCallbacks(this);
    }

}
