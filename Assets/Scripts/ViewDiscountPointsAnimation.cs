using TMPro;
using UnityEngine;

namespace UI
{
    public class ViewDiscountPointsAnimation : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _printSoulsModification;

        public void AddRemoveSouls(int _soulsAmount)
        {
            LeanTween.moveLocalY(_printSoulsModification.gameObject, _printSoulsModification.gameObject.transform.position.y + 10, .2f);
        }

    }
}

