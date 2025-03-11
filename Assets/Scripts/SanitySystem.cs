using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SanitySystem : MonoBehaviour
{

    public float currentSanity;
    private GameObject _player;
    [SerializeField] private Image sanityBar;
    [SerializeField] private TextMeshProUGUI sanityText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSanity = (100f * 60);
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player.GetComponent<Inventory>().hasPlush == true /*heeft plush*/ && _player.transform.GetChild(0).GetComponent<CandleBehaviour>().currentCandleState == 3 /*is uit*/)
        { 
            currentSanity = currentSanity - 0.33f;
            sanityBar.rectTransform.sizeDelta = new Vector2(120, (currentSanity / 60));
            sanityText.text = (Mathf.Round(currentSanity / 60)).ToString();
            Debug.Log("wel plush, geen licht");
        }
        if (_player.GetComponent<Inventory>().hasPlush == false /*heeft plush niet */ && _player.transform.GetChild(0).GetComponent<CandleBehaviour>().currentCandleState < 3 /*staat aan*/)
        {
            currentSanity = currentSanity - 0.5f;
            sanityBar.rectTransform.sizeDelta = new Vector2(120, (currentSanity / 60));
            sanityText.text = (Mathf.Round(currentSanity / 60)).ToString();
            Debug.Log("geen plush, wel licht");
        }
        if(_player.transform.GetChild(0).GetComponent<CandleBehaviour>().currentCandleState == 3 /*staat aan*/ && _player.GetComponent<Inventory>().hasPlush == false /*geen plush*/)
        {
            currentSanity = currentSanity - 2;
            sanityBar.rectTransform.sizeDelta = new Vector2(120, (currentSanity / 60));
            sanityText.text = (Mathf.Round(currentSanity / 60)).ToString();
            Debug.Log("beide niet");
        }
        else
        {
            Debug.Log("idk");
        }
    }
}
