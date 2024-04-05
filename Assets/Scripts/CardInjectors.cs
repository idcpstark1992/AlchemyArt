using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CardInjectors:MonoBehaviour
    {
        [SerializeField] private List<CardConfigDataItem> _inputFiles;

        private void Awake()
        {
            for (int i = 0; i < _inputFiles.Count; i++)
            {
                CardDataStorage m_ToAddData = new()
                {
                    CardValue = _inputFiles[i].Cardvalue,
                    CardSprite = _inputFiles[i].CardSprite
                };
                CardsSpritesUtils.Init(m_ToAddData);
            }
                
        }
    }

}
