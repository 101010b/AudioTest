using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace audio_test
{
    class AudioSrc
    {

        enum AudioDeviceType { Windows, WASAPI, WASAPILoop }

        private int _sampleRate;
        public int sampleRate
        {
            set { if (online) throw new Exception("audioSrc: Cannot chaneg Samplerate on open device"); _sampleRate = value; }
            get { return _sampleRate; }
        }
        
        private class AudioDevice
        {
            public AudioDeviceType audioDeviceType;
            public int index;
            public string name;
            public int channels;

            public AudioDevice(AudioDeviceType _audioDeviceType, int _index, string _name, int _channels)
            {
                name = _name;
                index = _index;
                audioDeviceType = _audioDeviceType;
                channels = _channels;
            }

            public override string ToString()
            {
                return String.Format("{0}:{1} ({2} ch)",audioDeviceType.ToString(), name, channels);
            }

        }

        private List<AudioDevice> audioDevices;
        private WaveIn waveIn;
        private IWaveIn WASAPIwaveIn;
        private WaveFormatEncoding WASAPIDataFormat;
        private AudioDevice openDev;
        private bool _online;
        public bool online
        {
            get { return _online; }
        }

        public List<string> getDeviceList()
        {
            List<string> devnames = new List<string>();
            foreach (AudioDevice ad in audioDevices)
            {
                devnames.Add(ad.ToString());
            }
            return devnames;
        }
        
        public void rescan()
        {
            if (_online) throw new Exception("Cannot rescan device as long as one is open");

            audioDevices = new List<AudioDevice>();

            // Standard Windows Input Devices
            int wid = WaveIn.DeviceCount;
            for (int i = 0; i < wid; i++)
            {
                WaveInCapabilities devinf = WaveIn.GetCapabilities(i);
                audioDevices.Add(new AudioDevice(AudioDeviceType.Windows, i, devinf.ProductName, devinf.Channels));
            }

            // WASAPI Audio Sources
            List<MMDevice> WASAPIDevices;
            MMDeviceEnumerator deviceEnum = new MMDeviceEnumerator();
            WASAPIDevices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();
            for (int i = 0; i < WASAPIDevices.Count; i++)
            {
                audioDevices.Add(new AudioDevice(AudioDeviceType.WASAPI, i, WASAPIDevices[i].FriendlyName, 2));
            }

            // WASAPI LoopBack Sources
            WASAPIDevices = deviceEnum.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active).ToList();
            for (int i = 0; i < WASAPIDevices.Count; i++)
            {
                audioDevices.Add(new AudioDevice(AudioDeviceType.WASAPILoop, i, WASAPIDevices[i].FriendlyName, 2));
            }
        }

        public AudioSrc()
        {
            _online = false;
            rescan();
        }

        double[] tempBuf1;
        double[] tempBuf2;

        public class NewDataAvailableArgs: EventArgs
        {
            public double[] L;
            public double[] R;
        }

        // public delegate void NewDataAvailableEventHandler(object sender, NewDataAvailableArgs e);
        public event EventHandler newDataAvailableEventHandler;

        void newDataSet(double[] L, double[] R)
        {
            NewDataAvailableArgs a = new NewDataAvailableArgs();
            a.L = L;
            a.R = R;
            newDataAvailableEventHandler?.Invoke(this, a);
        }

        void WASAPI_DataAvailable(object sender, WaveInEventArgs e)
        {
            int samples = 0;
            switch (WASAPIDataFormat)
            {
                case WaveFormatEncoding.IeeeFloat:
                    samples = e.BytesRecorded / 8;
                    break;
                case WaveFormatEncoding.Pcm:
                    samples = e.BytesRecorded / 4;
                    break;
            }
            if (samples == 0)
                return;

            if ((tempBuf1 == null) || (tempBuf1.Length != samples))
            {
                tempBuf1 = new double[samples];
                tempBuf2 = new double[samples];
            }

            switch (WASAPIDataFormat)
            {
                case WaveFormatEncoding.IeeeFloat:
                    for (int i = 0; i < samples; i++)
                        tempBuf1[i] = (double)BitConverter.ToSingle(e.Buffer, i * 8) * 32767.0;
                    for (int i = 0; i < samples; i++)
                        tempBuf2[i] = (double)BitConverter.ToSingle(e.Buffer, i * 8 + 4) *32767.0;
                    newDataSet(tempBuf1, tempBuf2);
                    break;
                case WaveFormatEncoding.Pcm:
                    for (int i = 0; i < samples; i++)
                        tempBuf1[i] = (double)BitConverter.ToInt16(e.Buffer, i * 4);
                    for (int i = 0; i < samples; i++)
                        tempBuf2[i] = (double)BitConverter.ToInt16(e.Buffer, i * 4 + 2);
                    newDataSet(tempBuf1, tempBuf2);
                    break;
            }
        }

        void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            int smps = e.BytesRecorded / 2 / 2;
            if (smps == 0)
                return;

            if ((tempBuf1 == null) || (tempBuf1.Length != smps))
            {
                tempBuf1 = new double[smps];
                tempBuf2 = new double[smps];
            }

            for (int i = 0; i < smps; i++)
                tempBuf1[i] = (double)BitConverter.ToInt16(e.Buffer, i * 2 * 2);
            for (int i = 0; i < smps; i++)
                tempBuf2[i] = (double)BitConverter.ToInt16(e.Buffer, i * 2 * 2 + 2);
            newDataSet(tempBuf1, tempBuf2);
        }
        
        private void openWindowsDevice(AudioDevice a)
        {
            try
            {
                waveIn = new WaveIn(WaveCallbackInfo.FunctionCallback());
                waveIn.WaveFormat = new WaveFormat(_sampleRate, 16, 2);
                waveIn.DeviceNumber = a.index;
                waveIn.DataAvailable += WaveIn_DataAvailable;
                waveIn.BufferMilliseconds = 25; // 1200 samples at 48 kHz
                waveIn.StartRecording();
                _online = true;
                openDev = a;
            }
            catch (Exception E)
            {
                throw new Exception(String.Format("audioSrc: Cannot open Audio Device {0}", a.ToString()));
            }
        }

        private void openWASAPIDevice(AudioDevice a)
        {
            try
            {
                List<MMDevice> WASAPIDevices;
                MMDeviceEnumerator deviceEnum = new MMDeviceEnumerator();
                if (a.audioDeviceType == AudioDeviceType.WASAPI)
                    WASAPIDevices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();
                else
                    WASAPIDevices = deviceEnum.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active).ToList();

                // WASAPIwaveIn = new WasapiLoopbackCapture(WASAPIDevices[devid[s]]);
                if (a.audioDeviceType == AudioDeviceType.WASAPI)
                    WASAPIwaveIn = new WasapiCapture(WASAPIDevices[a.index]);
                else
                    WASAPIwaveIn = new WasapiLoopbackCapture(WASAPIDevices[a.index]);
                WASAPIDataFormat = WASAPIwaveIn.WaveFormat.Encoding;
                _sampleRate = WASAPIwaveIn.WaveFormat.SampleRate;
                if ((WASAPIDataFormat != WaveFormatEncoding.Pcm) && (WASAPIDataFormat != WaveFormatEncoding.IeeeFloat))
                {
                    throw new Exception(
                        String.Format(
                            "audioSrc: WASAPI Device {0} cannot be used - bad data format", 
                            a.ToString()));
                }
                WASAPIwaveIn.DataAvailable += WASAPI_DataAvailable;
                WASAPIwaveIn.StartRecording();
                _online = true;
                openDev = a; 
            }
            catch (Exception E)
            {
                throw new Exception(String.Format("audioSrc: Cannot open Audio Device {0}", a.ToString()));
            }
        }

        public void open(int index)
        {
            if ((index < 0) || (index >= audioDevices.Count))
                throw new Exception("audioSrc: Bad Device Index");
            if (_online)
                throw new Exception("audioSrc: Device already Open");

            if (audioDevices[index].audioDeviceType == AudioDeviceType.Windows)
                openWindowsDevice(audioDevices[index]);
            else
                openWASAPIDevice(audioDevices[index]);
            
        }

        public void close()
        {
            if (!_online) return;
            // Close Device
            if (openDev.audioDeviceType == AudioDeviceType.Windows)
            {
                try
                {
                    waveIn.StopRecording();
                    waveIn.Dispose();
                }
                catch (Exception E)
                {
                }
                waveIn = null;
                openDev = null;
            } else { // WASAPI Device
                try
                {
                    WASAPIwaveIn.StopRecording();
                    WASAPIwaveIn.Dispose();
                }
                catch (Exception E)
                {
                }
                WASAPIwaveIn = null;
                openDev = null;
            }
            _online = false;
        }


    }
}
