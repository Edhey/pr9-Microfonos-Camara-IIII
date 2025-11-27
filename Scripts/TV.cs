using UnityEngine;
using System.IO;

public class TV : MonoBehaviour {
  private Material tvMaterial;
  private WebCamTexture webcamTexture;
  private string savePath;
  private int captureCounter = 1;

  void Start() {
    savePath = Application.dataPath + "/Capturas/";

    if (!Directory.Exists(savePath)) {
      Directory.CreateDirectory(savePath);
    }

    Renderer rend = GetComponent<Renderer>();
    tvMaterial = rend.material;
    webcamTexture = new WebCamTexture();
  }

  void Update() {
    if (Input.GetKey("s")) {
      tvMaterial.mainTexture = webcamTexture;
      webcamTexture.Play();
      Debug.Log("Active camera: " + webcamTexture.deviceName);
    }

    if (Input.GetKey("p")) {
      webcamTexture.Stop();
    }

    if (Input.GetKey("x")) {
      TakePhoto();
    }
  }

  void TakePhoto() {
    Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
    snapshot.SetPixels(webcamTexture.GetPixels());
    snapshot.Apply();
    System.IO.File.WriteAllBytes(savePath + "capture_" + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
    Debug.Log("Photo saved at: " + savePath + "capture_" + captureCounter.ToString() + ".png");
    captureCounter++;
  }
}