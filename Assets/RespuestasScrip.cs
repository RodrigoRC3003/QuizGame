using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespuestasScrip : MonoBehaviour
{
	public bool isCorrect = false;
	public Preguntas preguntasManager;
	
	public void Respuestas()
	{
		if(isCorrect)
		{
			preguntasManager.Correct();
		}
		else
		{
			preguntasManager.Wrong();
		}
	}

}
