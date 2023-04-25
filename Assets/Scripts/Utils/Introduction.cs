using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Introduction : MonoBehaviour
{
    string[] textos = new string[10];
    public TextMeshProUGUI texto;

    void Start()
    {
        StartCoroutine(routine());
        textos[0] = "Nosso her�i � um astronauta experiente que recebe uma importante miss�o: explorar uma s�rie de planetas inexplorados. Armado com um traje especial e uma nave espacial, ele parte em sua miss�o com grande expectativa...";
        textos[1] = "No entanto, ao chegar no primeiro planeta, ele se depara com uma surpresa desagrad�vel. O planeta j� � habitado por criaturas hostis, chamadas /Slimes/. Esses seres estranhos come�am a atacar sua nave, fazendo com que ela caia no planeta...";
        textos[2] = "Agora, o jogador deve explorar o planeta e encontrar uma chave que abre a porta de sua nave, que est� trancada. Enquanto isso, ele deve lutar contra as criaturas, que est�o por toda parte e s�o altamente perigosos..";
        textos[3] = "� medida que ele viaja por todo o planeta, ele descobre pistas e segredos que o ajudar�o a sobreviver e a alcan�ar seu objetivo. Ele tamb�m encontra outros sobreviventes que est�o tentando sobreviver aos ataques dos slimes e podem fornecer informa��es valiosas...";
        textos[4] = "No final, o jogador deve encontrar a chave e escapar do planeta, a fim de continuar sua miss�o de explorar outros planetas. Mas a pergunta �: ser� que ele sobreviver� tempo suficiente para escapar dos ataques dos slimes e encontrar a chave?...";

        texto = GameObject.Find("texto").GetComponent<TextMeshProUGUI>();
        texto.SetText(textos[0]);
    }

    int cont = 0;

    public IEnumerator routine()
    {
        if (cont < textos.Length) // Verifica se o �ndice � v�lido
        {
            GameObject img = GameObject.Find("img" + cont);
            img.GetComponent<Image>().enabled = true;
            texto.GetComponent<TextMeshProUGUI>().text = textos[cont];

            // Desativa a imagem anterior
            if (cont > 0)
            {
                GameObject lastImg = GameObject.Find("img" + (cont - 1));
                lastImg.GetComponent<Image>().enabled = false;
            }

            if (cont == 3)
            {
                GameObject img3 = GameObject.FindWithTag("img3");
                if (img3 != null)
                {
                    img3.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                }
                else
                {
                    Debug.LogWarning("Objeto img3 n�o encontrado!");
                }
            }

            cont++;
        }

        if (cont < textos.Length) // Verifica se o �ndice � v�lido
        {
            yield return new WaitForSeconds(9);

            if (cont == 4)
            {
                GameObject img3 = GameObject.FindWithTag("img3");
                if (img3 != null)
                {
                    img3.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
                }
            }

            StartCoroutine(routine());
        }
        else
        {
            SceneManager.LoadScene("SCN_Level01");
        }
    }
}
