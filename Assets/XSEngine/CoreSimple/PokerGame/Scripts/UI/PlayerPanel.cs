using UnityEngine;
using UnityEngine.UI;
using XSEngine.Core;

public class PlayerPanel : MonoBehaviour
{
    public Text nameText;
    public Text handCardNumText;
    public GameObject panelHand;
    public GameObject useCardTips;
    public GameObject cardPrefab;

    private CorePlayer Player { get; set; }

    public static string UI_PLAYER_TURNBEGIN = "UI_PLAYER_TURNBEGIN";
    public static string UI_PLAYER_TURNEND = "UI_PLAYER_TURNEND";

    /************************* 牌变动 begin ***********************/
    public static string UI_DECK_CHANGED = "UI_DECK_CHANGED";
    public static string UI_PUBLICDECK_CHANGED = "UI_PUBLICDECK_CHANGED";
    public static string UI_HANDCARDS_CHANGED = "UI_HANDCARDS_CHANGED";
    public static string UI_PLAYAREACARDS_CHANGED = "UI_PLAYAREACARDS_CHANGED";
    public static string UI_DISCARDS_CHANGED = "UI_DISCARDS_CHANGED";
    /************************* 牌变动  end  ***********************/
    // Start is called before the first frame update
    private void Awake()
    {
        CoreUIEmitter.Instance.On(CoreUIEmitter.UI_PLAYER_GAMESTART, (data) => this.useCardTips.SetActive(this.Player.Index == data.PlayerIndex), 0, this);
        CoreUIEmitter.Instance.On(CoreUIEmitter.UI_PLAYER_TURNBEGIN, (data) => this.useCardTips.SetActive(this.Player.Index == data.PlayerIndex), 0, this);
        CoreUIEmitter.Instance.On(CoreUIEmitter.UI_PLAYER_TURNEND, (data) => this.useCardTips.SetActive(this.Player.Index == data.PlayerIndex), 0, this);
        CoreUIEmitter.Instance.On(CoreUIEmitter.UI_HANDCARDS_CHANGED, (data) => { if (this.Player.Index == data.PlayerIndex) this.RefreshPlayerHand(); }, 0, this);
    }

    private void OnDestroy()
    {
        CoreUIEmitter.Instance.Off(CoreUIEmitter.UI_PLAYER_GAMESTART, this);
        CoreUIEmitter.Instance.Off(CoreUIEmitter.UI_PLAYER_TURNBEGIN, this);
        CoreUIEmitter.Instance.Off(CoreUIEmitter.UI_PLAYER_TURNEND, this);
        CoreUIEmitter.Instance.Off(CoreUIEmitter.UI_HANDCARDS_CHANGED, this);
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
