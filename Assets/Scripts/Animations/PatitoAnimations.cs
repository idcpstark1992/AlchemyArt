
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class PatitoAnimations : MonoBehaviour
    {
        [SerializeField] private GameObject _a2;
        [SerializeField] private GameObject _b2;
        [SerializeField] private Image _a;
        [SerializeField] private Image _b;
        private Color _acolor;
        private Color _bcolor;
        private void OnEnable()
        {
            Animate();
        }
        public void Animate()
        {
            _acolor = Color.white;
            _bcolor = Color.white;
            _acolor.a = 0f;
            _bcolor.a = 0f;

            _a.color = _acolor;
            _b.color = _bcolor;

            _a2.transform.localScale = Vector3.one *3f;
            _b2.transform.localScale = Vector3.one * 3f;

            LeanTween.scale(_a2, Vector3.one, .3f).setEaseOutBounce();
            LeanTween.scale(_b2, Vector3.one, .3f).setEaseOutBounce().setDelay(.2f);

            LeanTween.value(0, 1,.2f).setOnUpdate(OnColor);
            LeanTween.value(0, 1,.2f).setOnUpdate(OnColorb);


        }

        public void OnColor(float _value)
        {
            _acolor.a = _value;
            _a.color = _acolor;
        }
        public void OnColorb(float _value) 
        {
            _bcolor.a = _value;
            _b.color = _bcolor;
        }

    }

}
