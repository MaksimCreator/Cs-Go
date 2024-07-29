using UnityEngine;

public class AnimatorConstant
{
    #region property
    public static int IdelWeapon => Animator.StringToHash(nameof(IdelWeapon));
    public static int Move => Animator.StringToHash(nameof(Move));
    public static int Attack => Animator.StringToHash(nameof(Attack));
    public static int Rollbeck => Animator.StringToHash(nameof(Rollbeck));
    public static int Jump => Animator.StringToHash(nameof(Jump));
    public static int Idel => Animator.StringToHash(nameof(Idel));
    public static int SwithGunEnter => Animator.StringToHash(nameof(SwithGunEnter));
    public static int SwithGunExit => Animator.StringToHash(nameof(SwithGunExit));
    #endregion
}
