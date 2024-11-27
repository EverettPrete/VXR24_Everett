using UnityEngine;

public class DoughAnimation : MonoBehaviour
{
    [SerializeField] private Animator Cell = null;
    [SerializeField] private string chooseanimation1 = "animationName";
   

    public void PlayAnimationOnLayer()
    {
        Cell.Play(chooseanimation1, 0, 0.0f);
    }
}
