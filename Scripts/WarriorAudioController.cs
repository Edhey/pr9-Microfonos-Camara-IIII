using UnityEngine;

public class WarriorAudioController : MonoBehaviour {
  public AudioSource audioSource;
  public AudioClip victorySound;

  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Objetivo")) {
      PlayGoalSound();
    }
  }

  private void PlayGoalSound() {
    if (audioSource != null && victorySound != null) {
      audioSource.PlayOneShot(victorySound);
    }
    else {
      Debug.LogWarning("Falta asignar el AudioSource o el AudioClip en el inspector.");
    }
  }
}