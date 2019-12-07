using UnityEngine;
using System.Collections;
using HTC.UnityPlugin.Multimedia;

public class stopVideo : MonoBehaviour {
    MediaDecoder.DecoderState state = MediaDecoder.DecoderState.HOLDER;
    public GameObject mediaDecoder;
    private MediaDecoder media;
    Renderer render;
    // Use this for initialization
    void Start () {
        render = GetComponent<Renderer>();
        render.material.shader = Shader.Find("Specular");
        media = mediaDecoder.GetComponent<MediaDecoder>();
    }	
	// Update is called once per frame
	void Update () {

    }
    void OnCollisionEnter(Collision collision) {
        if (state != MediaDecoder.DecoderState.PAUSE) {
            state = MediaDecoder.DecoderState.PAUSE;
            render.material.SetColor("_SpecColor", Color.green);
        }
        media.setDecoderState(state);
    }
}
