using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoulsMarketItem : MonoBehaviour
{
    [SerializeField] private Image  _renderImage;
    [SerializeField] private Sprite _goodSprite;
    [SerializeField] private Sprite _badSprite;
    [SerializeField] private string _itemName;
    [SerializeField] private int    _soulsCost;
    [SerializeField] private TextMeshProUGUI _printText;
    [SerializeField] private Button _buyButton;
    private void Start()
    {
        _printText.SetText(string.Concat("Purge Cost : ",_soulsCost.ToString()));
    }
    public void BuyItem()
    {

    }
    public void InitItem() 
    {
        _buyButton.interactable = BetUtils.PlayerSoulsAmount >= _soulsCost;
    } 
    public void OnShowPreview()
    {

    }
    public void DisableBuyButtons()
    {

    }
}
