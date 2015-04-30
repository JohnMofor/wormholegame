﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LevelSelectionManager : MonoBehaviour {

	public int numberOfLevels;

	private static Dictionary<string,int> nextLevelOf = new Dictionary<string,int >()
	{
		{"tutorial2d",2},
		{"level_solarSystem",4},
		{"level_wormholes",-1}
	};

	void Awake (){

		int[] unlockedLevels = PlayerPrefsX.GetIntArray ("unlockedLevels",1,1);

		for (int i = 1; i <= numberOfLevels; i++) {


			string buttonName = string.Format("/Canvas/Level{0}Button",i);
			string lockedButtonName = buttonName+"Locked";

			GameObject levelButton = GameObject.Find(buttonName);
			GameObject lockedLevelButton = GameObject.Find(lockedButtonName);

			if (Array.IndexOf(unlockedLevels,i)!=-1){
				levelButton.gameObject.SetActive(true);
				lockedLevelButton.gameObject.SetActive(false);
			}
			else
			{
				levelButton.gameObject.SetActive(false);
				lockedLevelButton.gameObject.SetActive(true);
			}

		}
	}


	public static void UnlockNextLevel(int nextLevelNumber)
	{
		int[] unlockedLevels = PlayerPrefsX.GetIntArray ("unlockedLevels",1,1);

		Array.Resize<int> (ref unlockedLevels,unlockedLevels.Length+1);
		unlockedLevels [unlockedLevels.Length-1] = nextLevelNumber;
		PlayerPrefsX.SetIntArray ("unlockedLevels",unlockedLevels);
	}

	public static void LockAllLevels()
	{
		PlayerPrefsX.SetIntArray ("unlockedLevels",new int[]{1});
	}

	public void LoadScene(string level)
	{
		Application.LoadLevel (level);
	}

	public int GetNextLevel(string currentLevel) {
		return 0;
	}

	public static int NextLevelOf(string level)
	{
		return nextLevelOf [level];
	}
}
