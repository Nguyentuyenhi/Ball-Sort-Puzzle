﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
   public List<string> tubeData = new List<string>();
   public void CreateLevel(ref List<Tube> tubes)
   {

		for (int i = 0; i< 4; i++)
		{
			Tube tube = Instantiate(GameManager.instance.prefabTube, GameManager.instance.ListTubeGO.transform).GetComponent<Tube>();
			tubes.Add(tube);
			int[] idBalls = Array.ConvertAll(tubeData[i].Split(','),int.Parse);

			// create ball
			for (int j = 0; j < idBalls.Length; j++)
			{
				if (idBalls[j] == -1) continue;
				// tạo bóng
				Instantiate(GameManager.instance.prefabBall, tube.listPosGO.transform.GetChild(j).position,Quaternion.identity,tube.listBallGO.transform).GetComponent<Image>().sprite = GameManager.instance.spriteBalls[idBalls[j]] ;

			}
			tube.InitTube();
		}
   }
    public void CreateLevell(ref List<Tube> tubes2)
    {

        for (int i =4 ; i < tubeData.Count; i++)
        {
            Tube tubee = Instantiate(GameManager.instance.prefabTube, GameManager.instance.ListTubeGO2.transform).GetComponent<Tube>();
            tubes2.Add(tubee);
            int[] idBalls = Array.ConvertAll(tubeData[i].Split(','), int.Parse);

            // create ball
            for (int j = 0; j < idBalls.Length; j++)
            {
                if (idBalls[j] == -1) continue;
                // tạo bóng
                Instantiate(GameManager.instance.prefabBall, tubee.listPosGO.transform.GetChild(j).position, Quaternion.identity, tubee.listBallGO.transform).GetComponent<Image>().sprite = GameManager.instance.spriteBalls[idBalls[j]];

            }
            tubee.InitTube();
        }
    }
}
