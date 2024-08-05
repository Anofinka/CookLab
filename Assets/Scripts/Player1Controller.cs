using UnityEngine.InputSystem;

public class Player1Controller : BasePlayerController, Controls.IPlayerActions
{
    protected override InputActionMap GetInputActionMap()
    {
        return controls.Player.Get();
    }

    protected override void SetCallbacks()
    {
        controls.Player.SetCallbacks(this);
    }

}
