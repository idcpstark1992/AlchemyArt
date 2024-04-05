using UnityEngine;

public class SelectionValueAnimations : MonoBehaviour
{
    [SerializeField] private GameObject _buttonNormalValue;
    [SerializeField] private GameObject _buttonBoostedValue;
    private void OnEnable()
    {
        Animate();
    }
    public void Animate()
    {
        _buttonNormalValue.transform.localScale = Vector3.zero;
        _buttonBoostedValue.transform.localScale = Vector3.zero;

        LeanTween.scale(_buttonNormalValue, Vector3.one, .3f).setEaseOutBounce();
        LeanTween.scale(_buttonBoostedValue, Vector3.one, .3f).setEaseOutBounce().setDelay(.1f);
    }
}
