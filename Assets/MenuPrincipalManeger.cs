using UnityEngine;
using UnityEngine.SceneManagement;
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private string NomeDoLevelDoJogo; 
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelModulos;
    [SerializeField] private GameObject painelModulo1;
    [SerializeField] private GameObject painelModulo2;
    [SerializeField] private GameObject painelModulo3;
    [SerializeField] private GameObject começarCores;
    [SerializeField] private GameObject começarLetras;
    [SerializeField] private GameObject começarNumeros;
    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
    }
    public void abrirModulos()
    {
        painelMenuInicial.SetActive(false);
        painelModulos.SetActive(true);
        painelModulo1.SetActive(false);
        painelModulo2.SetActive(false);
        painelModulo3.SetActive(false);
    }

    public void abrirOpcoes()
    {
        painelModulos.SetActive(false);
        painelModulo1.SetActive(false);
        painelModulo2.SetActive(false);
        painelModulo3.SetActive(false);
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void Modulo1()
    {
        painelOpcoes.SetActive(false);
        painelModulo1.SetActive(true);
        começarCores.SetActive(false);
    }

    public void Modulo2()
    {
        painelOpcoes.SetActive(false);
        painelModulo2.SetActive(true);
        começarLetras.SetActive(false);
    }
    
    public void Modulo3()
    {
        painelOpcoes.SetActive(false);
        painelModulo3.SetActive(true);
        começarNumeros.SetActive(false);
    }
    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelModulos.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void VoltarModulo1()
    {
        painelModulo1.SetActive(true);
        painelOpcoes.SetActive(false);
    }
    public void VoltarModulo2()
    {
        painelModulo2.SetActive(true);
        painelOpcoes.SetActive(false);
    }
        public void VoltarModulo3()
    {
        painelModulo3.SetActive(true);
        painelOpcoes.SetActive(false);
    }
    public void ComecarModuloCores()
    {
        começarCores.SetActive(true);
        painelModulo3.SetActive(false);
    }
    public void ComecarModulosLetras()
    {
        começarLetras.SetActive(true);
        painelModulo2.SetActive(false);
        painelModulos.SetActive(false);
        painelMenuInicial.SetActive(false);
    }

public void ComecarModulosNumeros()
    {
        começarNumeros.SetActive(true);
        painelModulo1.SetActive(false);
        
    }
    public void SairdoJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
