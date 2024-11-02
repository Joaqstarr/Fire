using UnityEngine;

namespace VideoSystem
{
    [CreateAssetMenu(fileName = "VideoData", menuName = "VideoData", order = 0)]
    public class VideoMarkerData : ScriptableObject
    {
        [field: SerializeField] public VideoEventTypes EventType { get; private set; }
        
    }
}