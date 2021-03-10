using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int coins = 30;
    int anger = 0;
    int satisfaction = 0;

    public int response = 0;

    private int ticks = 0;

    [SerializeField] private TextMeshProUGUI coinText;
    public TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI option1Text;
    [SerializeField] private TextMeshProUGUI option2Text;
    [SerializeField] private TextMeshProUGUI option3Text;
    [SerializeField] private TextMeshProUGUI gameoverText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private Image grandmaImage;
    [SerializeField] private Sprite grandmaHappy;
    [SerializeField] private Sprite grandmaMiffed;
    [SerializeField] private Sprite grandmaAngry;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameStartPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    private enum Emotion
    {
        Happy, Miffed, Angry
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ticks < 50)
        {
            ticks++;
        } else
        {
            ticks = 0;
            coins--;
            coinText.text = coins.ToString();
        }

        if (coins <= 0)
        {
            SetEmotion(Emotion.Miffed);
            gameoverText.text = "Connection lost! You get cut off in the middle of your sentence";
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            scoreText.text = "Score: " + (20 + 3*coins + satisfaction - 2*anger).ToString();
        } else if (anger >= 10)
        {
            SetEmotion(Emotion.Angry);
            gameoverText.text = "Grandma hung up on you in a fit of rage!";
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            scoreText.text = "Score: " + (20 + coins + satisfaction - 2 * anger).ToString();
        }
        else if (satisfaction >= 10)
        {
            if (anger >= 5)
            {
                SetEmotion(Emotion.Miffed);
                gameoverText.text = "Grandma hangs up a bit miffed";
            }
            else
            {
                this.GetComponent<AudioSource>().Play();
                SetEmotion(Emotion.Happy);
                gameoverText.text = "You had a great phone call with grandma!";
                anger -= 2; 
            }
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            scoreText.text = "Score: " + (20 + coins + satisfaction - 2 * anger).ToString();
        }
    }

    public void LoseCoins(int coinsLost, int rudeness, int information)
    {
        coins -= coinsLost;
        anger += rudeness;
        satisfaction += information;
        response++;
        coinText.text = coins.ToString();
        nextDialogue();
    }

    public void Reset()
    {
        coins = 30;
        response = 0;
        anger = 0;
        satisfaction = 0;
        SetEmotion(Emotion.Happy);
        dialogueText.text = "Hi sweety, How have you been?";
        option1Text.text = "Fuck off Grandma.";
        option2Text.text = "I'm good grandma, how have you been?";
        option3Text.text = "I've been busy";
        coinText.text = coins.ToString();
        option3Text.transform.parent.gameObject.GetComponent<Buttons>().rudeness = 3;
        Time.timeScale = 1;
        //gameOverPanel.SetActive(false);
        //gameStartPanel.SetActive(false);
    }

    public void nextDialogue()
    {
        if (response == 1)
        {
            if (anger == 0)
            {
                dialogueText.text = "Oh that's great to hear! Did you find someone you fancy?";
                option1Text.text = "None of your business!";
                option2Text.text = "Not yet, not for lack of trying though...";
                option3Text.text = "No, and I'm not looking either";
                option3Text.transform.parent.gameObject.GetComponent<Buttons>().rudeness += 2;
            }
            else
            {
                SetEmotion(Emotion.Miffed);
                dialogueText.text = "Oh, you're busy? Do you want me to call back later?";
                option1Text.text = "No, don't call me";
                option2Text.text = "Please do! I have a lot to tell you";
                option3Text.text = "I'll call you when I'm done";
            }
        }
        if (response == 2)
        {
            if (anger == 0)
            {
                dialogueText.text = "I'm sure you'll find someone soon, who could resist my cinnabun";
                option1Text.text = "Don't call me cinnabun you old crone!";
                option2Text.text = "Aww, thank you grandma!";
                option3Text.text = "Don't lie. Anyway, got to go.";
            }
            else if (anger == 3)
            {
                SetEmotion(Emotion.Happy);
                dialogueText.text = "Okay sweety, call you soon!";
                option1Text.text = "Not if you die first";
                option2Text.text = "talk to you soon grandma, love you!";
                option3Text.text = "Yes.";
            }
            else if (anger == 5)
            {
                SetEmotion(Emotion.Miffed);
                dialogueText.text = "Why not? You're not getting any younger.";
                option1Text.text = "And you'd know that best old crone!";
                option2Text.text = "I'm focussing on work right now, I want to be in a good position before settling down";
                option3Text.text = "Don't lie. Anyway, got to go.";
            }
        }
    }

    private void SetEmotion(Emotion emotion)
    {
        switch (emotion)
        {
            case (Emotion.Happy):
                grandmaImage.sprite = grandmaHappy;
                //grandmaHappy.SetActive(true);
                //grandmaMiffed.SetActive(false);
                //grandmaAngry.SetActive(false);
                break;
            case (Emotion.Miffed):
                grandmaImage.sprite = grandmaMiffed;
                //grandmaHappy.SetActive(false);
                //grandmaMiffed.SetActive(true);
                //grandmaAngry.SetActive(false);
                break;
            case (Emotion.Angry):
                grandmaImage.sprite = grandmaAngry;
                //grandmaHappy.SetActive(false);
                //grandmaMiffed.SetActive(false);
                //grandmaAngry.SetActive(true);
                break; 
        }
    }

}
