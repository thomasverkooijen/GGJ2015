using UnityEngine;
using System.Collections;

public class AudioFilterManager{
	
	private static AudioListener 			_audioListener;
	private static AudioEchoFilter			_echoFilter;
	private static AudioDistortionFilter	_distortionFilter;
	private static AudioChorusFilter		_chorusFilter;
	private static AudioReverbFilter		_reverbFilter;
	private static AudioLowPassFilter		_lowPassFilter;
	private static AudioHighPassFilter		_highPassFilter;

	public static void SetAudioListener(AudioListener p_audioListener){
		_audioListener = p_audioListener;
		if(_audioListener == null) Debug.LogError("[AudioFilterManager] -> GetAudioListener() : Cant find AudioListener");
	}

	public static void SetEchoFilter(float p_decayRatio , float p_delay , float p_originalvolume , float p_echoVolume){
		if(_audioListener == null){
			Debug.Log("[SetEchoFilter] : _audioListener is null so cant set Filter");
			return;
		}
		if(_echoFilter == null) _echoFilter = _audioListener.gameObject.AddComponent<AudioEchoFilter>();
		_echoFilter.decayRatio 	= p_decayRatio;
		_echoFilter.delay 		= p_delay;
		_echoFilter.dryMix		= p_originalvolume;
		_echoFilter.wetMix		= p_echoVolume;
	}

	public static void SetDistortionFilter(float p_distortionLevel){
		if(_audioListener == null){
			Debug.Log("[SetDistortionFilter] : _audioListener is null so cant set Filter");
			return;
		}
		if(_distortionFilter == null) _distortionFilter = _audioListener.gameObject.AddComponent<AudioDistortionFilter>();
		_distortionFilter.distortionLevel = p_distortionLevel;
	}
	public static void SetChorusFilter(float p_delay , float p_depth , float p_rate , float p_dryMix , float p_wetMix1, float p_wetMix2, float p_wetMix3){
		if(_audioListener == null){
			Debug.Log("[SetChorusFilter] : _audioListener is null so cant set Filter");
			return;
		}
		if(_chorusFilter == null) _chorusFilter = _audioListener.gameObject.AddComponent<AudioChorusFilter>();
		_chorusFilter.delay 	= p_delay;
		_chorusFilter.depth		= p_depth;
		_chorusFilter.dryMix	= p_dryMix;
		_chorusFilter.rate		= p_rate;
		_chorusFilter.wetMix1	= p_wetMix1;
		_chorusFilter.wetMix2	= p_wetMix2;
		_chorusFilter.wetMix3	= p_wetMix3;
	}
	public static void SetReverbFilter(AudioReverbPreset p_reverbPreset){
		if(_audioListener == null){
			Debug.Log("[SetReverbFilter] : _audioListener is null so cant set Filter");
			return;
		}
		if(_reverbFilter == null) _reverbFilter = _audioListener.gameObject.AddComponent<AudioReverbFilter>();
		_reverbFilter.reverbPreset = p_reverbPreset;
	}
	public static void SetLowPassFilter(float p_cuttOfFrequency , float p_lowPassResonanceQ){
		if(_audioListener == null){
			Debug.Log("[SetLowPassFilter] : _audioListener is null so cant set Filter");
			return;
		}
		if(_lowPassFilter == null) _lowPassFilter = _audioListener.gameObject.AddComponent<AudioLowPassFilter>();
		_lowPassFilter.cutoffFrequency = p_cuttOfFrequency;
		_lowPassFilter.lowpassResonaceQ = p_lowPassResonanceQ;
	}
	public static void SetHighPassFilter(float p_cuttOfFrequency , float p_highPassResonanceQ){
		if(_audioListener == null){
			Debug.Log("[SetHighPassFilter] : _audioListener is null so cant set Filter");
			return;
		}
		if(_highPassFilter == null) _highPassFilter = _audioListener.gameObject.AddComponent<AudioHighPassFilter>();
		_highPassFilter.cutoffFrequency = p_cuttOfFrequency;
		_highPassFilter.highpassResonaceQ = p_highPassResonanceQ;
	}

}
