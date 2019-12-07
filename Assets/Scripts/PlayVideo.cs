using UnityEngine;
using System.Collections;
using HTC.UnityPlugin.Multimedia;

public class PlayVideo : MonoBehaviour {
    MediaDecoder.DecoderState state = MediaDecoder.DecoderState.HOLDER;
    public GameObject mediaDecoder;
    private MediaDecoder media;
    Renderer render;
    // Use this for initialization
    void Start() {
        //render = GetComponent<Renderer>();
        //render.material.shader = Shader.Find("Color");
        media = mediaDecoder.GetComponent<MediaDecoder>();
    }

    // Update is called once per frame
    void Update() {
    }

    void OnCollisionEnter(Collision collision) {
        if (state != MediaDecoder.DecoderState.START) {
            state = MediaDecoder.DecoderState.START;
            //render.material.SetColor("_EmissionColor", Color.red);
        }
        media.setDecoderState(state);
    }
}
