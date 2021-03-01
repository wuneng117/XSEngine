using UnityEngine;
using UnityEngine.UI;
using XSEngine;
using XSEngine.Core;

public class PlayerPanel : MonoBehaviour
{
    public Text nameText;
    public Text handCardNumText;
    public GameObject panelHand;
    public GameObject useCardTips;
    public GameObject cardPrefab;

    private CorePlayer Player { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {
        UIEmitter.Instance.On(UIEmitter.UI_PLAYER_GAME_START, (data) => this.useCardTips.SetActive(this.Player.Index == data.PlayerIndex), 0, this);
        UIEmitter.Instance.On(UIEmitter.UI_PLAYER_TURN_BEGIN, (data) => this.useCardTips.SetActive(this.Player.Index == data.PlayerIndex), 0, this);
        UIEmitter.Instance.On(UIEmitter.UI_PLAYER_TURN_END, (data) => this.useCardTips.SetActive(this.Player.Index == data.PlayerIndex), 0, this);
        UIEmitter.Instance.On(UIEmitter.UI_HANDCARDS_CHANGED, (data) => { if (this.Player.Index == data.PlayerIndex) this.RefreshPlayerHand(); }, 0, this);
    }

    private void OnDestroy()
    {
        UIEmitter.Instance.Off(UIEmitter.UI_PLAYER_GAME_START, this);
        UIEmitter.Instance.Off(UIEmitter.UI_PLAYER_TURN_BEGIN, this);
        UIEmitter.Instance.Off(UIEmitter.UI_PLAYER_TURN_END, this);
        UIEmitter.Instance.Off(UIEmitter.UI_HANDCARDS_CHANGED, this);
    }

    private void RefreshPlayerHand()
    {
        this.handCardNumText.text = this.Player.HandCards.Count.ToString();
        this.ClearPanel();

        if (this.panelHand != null)
        {
            this.Player.HandCards.ForEach(card =>
            {
                var cardNode = GameObject.Instantiate(this.cardPrefab);
                cardNode.transform.SetParent(this.panelHand.transform);
                var cpt = cardNode.GetComponent<CardNode>();
                cpt.Init(card as CoreCard, this.Player);
            });
        }
    }

    private void ClearPanel()
    {
        if (this.panelHand != null)
        {
            for (var i = this.panelHand.transform.childCount - 1; i >= 0; i--)
                Destroy(this.panelHand.transform.GetChild(i).gameObject);
        }
    }

    public void Init(CorePlayer player)
    {
        Debug.Assert(player != null);
        this.Player = player;
        this.nameText.text = player.Name;
        this.handCardNumText.text = player.HandCards.Count.ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
