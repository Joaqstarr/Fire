using System;
using UnityEngine;

namespace VideoSystem
{
    [CreateAssetMenu(fileName = "VideoData", menuName = "VideoData", order = 0)]
    public class VideoMarkerData : ScriptableObject
    {
        [Serializable]
        public struct RectData
        {
            public Vector2 Pos;
            public Vector2 Size;
            public Sprite Image;
        }
        
        [field: SerializeField] public VideoEventTypes EventType { get; private set; }

        public enum InputType
        {
            None,
            ActionButton,
            ClickButton
        }
        
        [field: SerializeField] public InputType InputStyle { get; private set; } 
        
        [field: SerializeField] public RectData[] Buttons { get; private set; }
        
    }
}