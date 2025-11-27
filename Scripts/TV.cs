using UnityEngine;
using System.IO;

public class TV : MonoBehaviour {
  private Material tvMaterial;
  private WebCamTexture webcamTexture;
  private string savePath;
  private int captureCounter = 1;

  void Start() {
    savePath = Application.dataPath + "/Scripts/pr9-Microfonos-Camara-IIII/Resources/";

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
      Debug.Log("Camera stopped.");
    }

    if (Input.GetKey("x")) {
      TakePhoto();
    }
  }

  void TakePhoto() {
    Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
    snapshot.SetPixels(webcamTexture.GetPixels());
    snapshot.Apply();
    string outputPath = savePath + "capture_" + captureCounter.ToString() + ".png";
    System.IO.File.WriteAllBytes(outputPath, snapshot.EncodeToPNG());
    Debug.Log("Photo saved at: " + outputPath);
    captureCounter++;
  }
}