using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDSettings : MonoBehaviour
{
    //Aqui eu cuido do HUD e também carrego outras cenas

    private PlayerStats stats;
    public GameObject hud;
    public GameObject menu;
    public GameObject reset;
    public GameManager gm;

    public Text knifeTxt;
    public Text appleTxt;
    public Text stageTxt;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();

        Time.timeScale = 1;
        menu.SetActive(false);
        reset.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AttHud();
    }

    private void AttHud() //Atualizar o HUD com as variaveis corretas
    {
        knifeTxt.text = "Facas: " + stats.knifes.ToString();
        appleTxt.text = "Maçãs: " + stats.apples.ToString();
        stageTxt.text = "Estágio: " + stats.stage.ToString();
    }

    public void PauseGame() //Pausar o jogo
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void UnpauseGame() //Despausar o jogo
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void ResetQuestion() // Quando perder perguntar se quer reiniciar ou sair para a tela principal
    {
        Time.timeScale = 0;
        reset.SetActive(true);
    }


    public void NextStage() // quando as facas chegarem a zero reiniciar a fase
    {
        gm.stage++;
        gm.knifes = Random.Range(7, 10);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TitleScreen() //ir para a tela de titulo
    {
        SceneManager.LoadScene(1);
    }

    public void ResetScene() //Quando o jogador escolher reiniciar o jogo se recarrega as variáveis iniciais
    {
        gm.stage = 1;
        gm.apples = 0;
        gm.knifes = 7;
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
