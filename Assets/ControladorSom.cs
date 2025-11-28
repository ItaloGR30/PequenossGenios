using UnityEngine;
using UnityEngine.UI;

public class ControladorSom : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField] private AudioSource FundoMusical;
    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private Image MuteImage;
    public void LigarDesligarSom()
    {
        estadoSom = !estadoSom;
        FundoMusical.enabled = estadoSom;

        if (estadoSom)
        {
            MuteImage.sprite = somLigadoSprite;
        }
        else
        {
            MuteImage.sprite = somLigadoSprite;
        }
    }
    public void VolumeMusical(float value)
    {
        FundoMusical.volume = value;
    }
}
