
using System;

public interface IPlayer
{
    public bool SwitchMap { get; set; }
    public event Action GetPoint;
    public event Action GameOver;
    public void Move(float movePressed);
    public void Jump(bool jumpPressed);
    public void StairsUp(bool StairsUpPressed);
    public void CrouchAndStairsDown(bool crouchPressed);
    public void Attack(bool attackPressed);
    public void SetJumpValue();
     public void SetDamage(float NewDamage);

}
