using UnityEngine;

public class Recorder : MonoBehaviour {
  // Declaración de una variable de tipo AudioSource
  AudioSource audioSource;
  [SerializeField, Range(1, 60)]
  private int recordingDuration = 20;

  // Start is called before the first frame update
  void Start() {
    // Recuperar el componente AudioSource que se agrega a los altavoces
    audioSource = GetComponent<AudioSource>();

    // Iniciar la recogida de audio por el micrófono
    // null = dispositivo por defecto
    // true = loop (grabación continua)
    // recordingDuration = duración del buffer en segundos
    // 44100 = frecuencia de muestreo (Hz)
    audioSource.clip = Microphone.Start(null, false, recordingDuration, 44100);
    Debug.Log("Recording started...");

    while (!(Microphone.GetPosition(null) > 0)) { }
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.R)) {
      audioSource.Play();
      Debug.Log("Recording playing...");
    }

    if (Input.GetKeyDown(KeyCode.S)) {
      Microphone.End(null);
      Debug.Log("Recording stopped.");
      audioSource.Stop();
      audioSource.clip = Microphone.Start(null, false, recordingDuration, 44100);
      Debug.Log("New recording started...");
    }
  }
}