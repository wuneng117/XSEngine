using UnityEngine;
using UnityEngine.UI;
using XSEngine.Core;

public class CardNode : MonoBehaviour
{
    public Text nameText;
    
    private CorePlayer Player {get; set;}
    private CoreCardBase Card { get; set; }

    public void Init(CoreCardBase card, CorePlayer player)
    {
        this.nameText.text = card.Name;
        this.Card = card;
        this.Player = player;
    }

    public void OnBtnClick() => this.Player?.UseCard(this.Card);
}
