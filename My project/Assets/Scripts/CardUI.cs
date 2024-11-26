using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public DrawCardPool cardPool;  // 引用卡池
    public Image cardImage;      // UI显示的卡牌图片
    public TextMeshProUGUI cardName;   // UI显示的卡牌名称

    public void OnDrawButtonClicked()
    {
        Card drawnCard = cardPool.DrawCard();
        if (drawnCard != null)
        {
            cardImage.sprite = drawnCard.image;
            cardName.text = drawnCard.name;
        }
    }

}
