using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VideoSystem
{
    public enum VideoEventTypes
    {
        Pause,
        AcceptInput,
        StopAcceptingInput,
        EndVideo,
        Max
    }

    public class VideoMarkerListener : MonoBehaviour
    {
        public delegate void VideoEvent(VideoMarkerData data);


        private VideoEvent[] _eventsArray;


        private void Awake()
        {
            _eventsArray = new VideoEvent[(int)VideoEventTypes.Max];
        }

        public void SendEvent(VideoMarkerData data)
        {
            VideoEvent eventToSend = _eventsArray[(int)data.EventType];

            eventToSend?.Invoke(data);
        }


        public void Subscribe(VideoEventTypes type, VideoEvent method)
        {
            VideoEvent eventToSubTo = _eventsArray[(int)type];

            eventToSubTo += method;

            _eventsArray[(int)type] = eventToSubTo;
        }

        public void Unsubscribe(VideoEventTypes type, VideoEvent method)
        {
            VideoEvent eventToSubTo = _eventsArray[(int)type];

            eventToSubTo -= method;

            _eventsArray[(int)type] = eventToSubTo;
        }

    }
}
