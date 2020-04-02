using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
 
public static class AudioFadeOut {
 
    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
}