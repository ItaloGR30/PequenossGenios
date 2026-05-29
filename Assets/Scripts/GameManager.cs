using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image questionImage;

    public Sprite[] images;

    public string[] answers;

    private int currentQuestion = 0;

    public DropZone dropZone;

    void Start()
    {
        LoadQuestion();
    }

    public void CorrectAnswer()
    {
        currentQuestion++;

        if(currentQuestion < images.Length)
        {
            LoadQuestion();
        }
        else
        {
            Debug.Log("Fim do jogo!");
        }
    }

    void LoadQuestion()
    {
        questionImage.sprite = images[currentQuestion];

        dropZone.correctLetter = answers[currentQuestion];
    }
}
