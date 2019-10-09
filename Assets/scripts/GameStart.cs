﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    [SerializeField]
    private string StartingSceneName;
    [SerializeField]
    private string TargetSpawnName;
    [SerializeField]
    private GameObject player;

    // Use this for initialization
    void Awake () {
        StartCoroutine(DoInitialTransition());
        GameData.addNewCharacter(PlayerCharacters.MainCharacter);
        GameData.addCharacterToParty(PlayerCharacters.MainCharacter);
        GameData.addNewCharacter(PlayerCharacters.Yurgurine);
        GameData.addCharacterToParty(PlayerCharacters.Yurgurine);

        Inventory.AddItemToInventory("00001", 1);
        Inventory.AddItemToInventory("00002", 1);
        Inventory.AddItemToInventory("00001", 1);
        Inventory.AddItemToInventory("00003", 1);
        Inventory.AddItemToInventory("00004", 1);
        Inventory.AddItemToInventory("00005", 1);
    }

    IEnumerator DoInitialTransition() {
        GameData.PlayerCanTransition = false;
        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(StartingSceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone) {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(StartingSceneName));
        GameObject spawn = GameObject.Find(TargetSpawnName);
        spawn.GetComponent<Spawn>().clearTransit = true;
        player.transform.position = spawn.transform.position;
        player.GetComponent<CharacterMover>().StopMoving();
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
