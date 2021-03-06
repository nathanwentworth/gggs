﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionSoundTrigger : MonoBehaviour {

  private AudioSource audio;
  [SerializeField]
  private AudioClip[] clips;

  private void Start() {
    audio = GetComponent<AudioSource>();
  }

  private void OnCollisionEnter(Collision other) {
    if (other.gameObject.tag == "Player") {
      StartCoroutine(PlayAudio());
    }
  }

  private IEnumerator PlayAudio() {
    if (clips.Length > 0) {
      audio.clip = clips[Random.Range(0, clips.Length)];
    }

    audio.Play();
    Debug.Log("Audio clip " + audio.clip.name + " played");
    yield return null;
  }

}
