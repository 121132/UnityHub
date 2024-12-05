using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Card
{
    public string name;      // 卡牌名称
    public Sprite image;     // 卡牌图像
    public int rarity;       // 稀有度（1-5星）
    public float dropRate;   // 掉率
    public Card(string name, Sprite image)
    {
        this.name = name;
        this.image = image;
    }
    public Card(string name, Sprite image, int rarity, float dropRate)
    {
        this.name = name;
        this.image = image;
        this.rarity = rarity;
        this.dropRate = dropRate;
    }
}
public class DrawCardPool : MonoBehaviour
{
    public List<Card> cards;  // 卡池中的所有卡牌
    public Sprite nullImage;
    public Card DrawCard()
    {
        // 将卡池中的卡牌按掉率升序排序
        List<Card> sortedCards = new List<Card>(cards);
        sortedCards.Sort((a, b) => a.dropRate.CompareTo(b.dropRate)); // 按照掉率从小到大排序

        // 随机生成一个数
        float randomPoint = Random.value;

        // 从掉率最小的卡牌开始遍历，找到对应的卡牌
        foreach (var card in sortedCards)
        {
            if (randomPoint < card.dropRate)
            {
                return card; // 抽中这张卡
            }
        }

        Card nullCard = new Card("非酋没抽到", nullImage);
        return nullCard;
    }
}
