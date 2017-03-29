#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MenuItems : MonoBehaviour {

  [MenuItem ("Kaiju/Make Destructible")]
  static void MakeObjectDestructible () {
    for (int i = 0; i < Selection.gameObjects.Length; i++) {
      GameObject go = Selection.gameObjects[i];

      if (go.GetComponent<BoxCollider>() == null && go.GetComponent<MeshCollider>() == null && go.GetComponent<SphereCollider>() == null && go.GetComponent<CapsuleCollider>() == null) {
        go.AddComponent<BoxCollider>();
      }
      if (go.GetComponent<Rigidbody>() == null) {
        go.AddComponent<Rigidbody>();
      }
      if (go.GetComponent<RigidbodySleepCheck>() == null) {
        go.AddComponent<RigidbodySleepCheck>();
      }
      if (go.GetComponent<ObjectDataContainer>() == null) {
        go.AddComponent<ObjectDataContainer>();
      }
      if (go.GetComponent<ObjectBehaviors>() == null) {
        go.AddComponent<ObjectBehaviors>();
      }

    }
  }

  [MenuItem ("Kaiju/Add ObjectBehaviors")]
  static void AddObjectBehaviors() {
    for (int i = 0; i < Selection.gameObjects.Length; i++) {
      GameObject go = Selection.gameObjects[i];
      
      if (go.GetComponent<ObjectBehaviors>() == null) {
        go.AddComponent<ObjectBehaviors>();
      }

    }
  }

  
  [MenuItem ("Kaiju/Initialize Scene")]
  static void InitializeScene () {
    // delete default main camera
    if (GameObject.Find("Main Camera") != null) {
      Object.DestroyImmediate(GameObject.Find("Main Camera"));
    }

    // add the smooth camera follow
    if (GameObject.Find("CameraFollow") == null) {
      Object cameraFollow = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Utility/CameraFollow.prefab", typeof(GameObject));
      GameObject _cameraFollow = PrefabUtility.InstantiatePrefab(cameraFollow) as GameObject;
      _cameraFollow.name = "CameraFollow";
    }

    // add the main hud
    if (GameObject.Find("MainHUD") == null) {
      Object hud = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Utility/MainHUD.prefab", typeof(GameObject));
      GameObject _hud = PrefabUtility.InstantiatePrefab(hud) as GameObject;
      _hud.name = "MainHUD";
    }

    // add the ball
    if (GameObject.Find("Ball") == null) {
      Object ball = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Ball.prefab", typeof(GameObject));
      GameObject _ball = PrefabUtility.InstantiatePrefab(ball) as GameObject;
      _ball.name = "Ball";
    }

    // add the game manager
    if (GameObject.Find("GameManagerSingleton") == null) {
      Object gameManager = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Utility/GameManagerSingleton.prefab", typeof(GameObject));
      GameObject _gameManager = PrefabUtility.InstantiatePrefab(gameManager) as GameObject;
      _gameManager.name = "GameManagerSingleton";
    }

    // add incontrol
    if (GameObject.Find("InControl") == null) {
      Object inControl = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Utility/InControl.prefab", typeof(GameObject));
      GameObject _inControl = PrefabUtility.InstantiatePrefab(inControl) as GameObject;
      _inControl.name = "InControl";
    }

    if (GameObject.Find("Floor") == null) {
      GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
      floor.name = "Floor";
      floor.transform.localScale = new Vector3(200f, 1f, 200f);
      floor.transform.position = new Vector3(0f, -0.5f, 0f);
    }


  }

}


#endif