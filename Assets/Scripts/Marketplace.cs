using Commons;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class Marketplace : MonoBehaviour
{
    [SerializeField] private List<SoulsMarketItem> _marketItemsList;
    [SerializeField] private CanvasGroup _canvas;
    [SerializeField] private TextMeshProUGUI _printSoulsAmount;
    [SerializeField] private UIButtonsController _buttonsController;
    [SerializeField] private Button _btnCloseMarketPlace;
    private void Awake()
    {
        _canvas.alpha           = 0f;
        _canvas.blocksRaycasts  = false;
        _canvas.interactable    = false;
    }
    public void OpenMarketPlace()
    {
        LeanTween.alphaCanvas(_canvas, 1, .5f);
        _canvas.interactable = true;
        _canvas.blocksRaycasts = true;
    }
    public void SetSoulsCounter (int _amount)
    {
        _printSoulsAmount.SetText(string.Concat("your souls :  ", _amount.ToString()));
    }
    public void CloseCanvas()
    {
        LeanTween.alphaCanvas(_canvas, 0f, .5f);
        _canvas.interactable    = false;
        _canvas.blocksRaycasts  = false;
        EventsListener.TriggerListener(E_ListenerID.ON_GAME_PHASE.ToString(),E_GamePhase.GAME_RESTARTED);
    }

}
