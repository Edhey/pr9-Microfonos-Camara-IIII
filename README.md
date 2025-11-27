# Práctica 9 Interfaces Inteligentes. Micrófonos y Cámara

- **Author**: Himar Edhey Hernández Alonso
- **Subject**: Interfaces Inteligentes

## Introducction

In this exercise you will learn how to use the microphone and webcam in Unity. You will learn how to capture audio and video from these devices and integrate the resulting streams into a Unity application.

## Tasks

### Microphone

First, we will work with the microphone to capture audio input and play it back.

#### Exercise 1: Audio

First of all, I used the Warriors scene used in previous practices. I added a AudioSource component to the scene, deactivating the "Play on Awake" option.

Then, I added some Tiger prefabs to the scene and I tagged them with the "Objective" tag, providing a collider with "Is Trigger" enabled to each of them.

Finally, I created a new C# script called "WarriorAudioController" and attached it to the Player. The script plays an audio clip when the player collides with an object tagged as "Objective".

[WarriorAudioController.cs](WarriorAudioController.cs)

![Warrior Audio Controller](WarriorAudioController.png)

#### Exercise 2: Microphone Recording

In this exercise, I created a new empty scene in Unity. I added from the Asset Store a free package called "Computer Devices" that I used to get models of a Computer, Keyboard and Speakers.

I created a new C# script called "Recorder" and attached it to the Computer in the scene. The script captures audio from the microphone and plays it back when the "R" key is pressed. If the "S" key is pressed, the recording stops and a new recording starts.

Using the `Microphone.Start` method, I set the following parameters:

- `deviceName`: Passing `null` uses the operating system’s default microphone.
- `loop`: `true` is required here. If `false`, the recording stops when the buffer fills (10 seconds). With `true`, the AudioClip behaves as a circular buffer and older audio is overwritten.
- `lengthSec`: `10` — the size of the recording buffer in seconds.
- `frequency`: `44100` Hz (CD quality). If the hardware doesn’t support a requested rate, Unity typically resamples; prefer standard rates like `44100` or `48000`.

[Recorder.cs](Recorder.cs)

![Recorder Setup](RecorderSetup.png)

### Camera

#### Exercise 3: Webcam Capture

In this exercise, I created a new C# script called "WebcamController" and attached it to the Computer in the scene. The script captures video from the webcam and displays it on the computer screen when the "C" key is pressed. If the "D" key is pressed, the webcam feed stops.