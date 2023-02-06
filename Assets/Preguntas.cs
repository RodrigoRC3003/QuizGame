using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Preguntas : MonoBehaviour
{
	public List<PreguntasyRespuestas> QnA;
	public GameObject[] opc;
	public int preguntaActual;
	int totalPreguntas = 0;
	public int marcador;
	
	public GameObject panelPrincipal;
	public GameObject panelJuego;
	public GameObject panelFinal;
	
	public TextMeshProUGUI preguntasTxt;
	public TextMeshProUGUI scoreTxt;
	
	void Start()
	{
		panelPrincipal.SetActive(true);
		totalPreguntas = QnA.Count;
		panelFinal.SetActive(false);
		GeneradorPreguntas();
	}
	
	public void Inicio()
	{
		panelPrincipal.SetActive(false);
		scoreTxt.text = marcador + "/" + totalPreguntas;
		panelJuego.SetActive(true);
	}
	
	public void Reintentar()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	void GameOver()
	{
		panelJuego.SetActive(false);
		panelFinal.SetActive(true);
		scoreTxt.text = marcador + "/" + totalPreguntas + "0"; 
	}
	//Por si estas bien
	public void Correct()
	{
		marcador =+ 100;
		QnA.RemoveAt(preguntaActual);
		GeneradorPreguntas();
	}
	//Por si estas mal
	public void Wrong()
	{
		QnA.RemoveAt(preguntaActual);
		GeneradorPreguntas();
	}
	
	void Respuestas()
	{
		for(int i = 0; i < opc.Length; i++)
		{
			opc[i].GetComponent<RespuestasScrip>().isCorrect = false;
			opc[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[preguntaActual].respuestas[i];
			
			if(QnA[preguntaActual].respuestasCorrectas == i+1)
			{
				opc[i].GetComponent<RespuestasScrip>().isCorrect = true;
			}
		}
	}
	
	void GeneradorPreguntas()
	{
		if(QnA.Count > 0)
		{
		preguntaActual = Random.Range(0, QnA.Count);
		
			preguntasTxt.text = QnA[preguntaActual].pregunta;
			scoreTxt.text = marcador + "/" + totalPreguntas + "0";
			Respuestas();
		}
		else
		{
			GameOver();
		}
	}
}
