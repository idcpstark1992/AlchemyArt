using UnityEngine;

public class RelancinaAnimations : MonoBehaviour
{
    [SerializeField] GameObject _imgAs;
    [SerializeField] GameObject _imgKing;
    private void OnEnable()
    {
        Animate();
    }
    public void Animate()
    {
        LeanTween.rotateLocal(_imgAs, Vector3.forward * 15, .3f).setEaseInBounce();
        LeanTween.rotateLocal(_imgKing, Vector3.forward * -15, .3f).setEaseInBounce();
    }
}
