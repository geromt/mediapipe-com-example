using System.Collections.Generic;

public class ConfigModel
{
    public Config Config { get; set; }
    public Output Output { get; set; }
}

public class Config
{
    public int CameraIndex { get; set; }
    public int Port { get; set; }
    public bool ConfigFrame { get; set; }
    public int FrameHeight { get; set; }
    public int FrameWidth { get; set; }
    public bool DisplayVideo { get; set; }
    public int DisplayVideoSize { get; set; }
    public bool DrawPose { get; set; }
    public bool StaticMode { get; set; }
    public int MaxHands { get; set; }
    public int ModelComplexity { get; set; }
    public bool SmoothLandmarks { get; set; }
    public bool EnableSegmentation { get; set; }
    public bool SmoothSegmentation { get; set; }
    public double MinDetectionConfidence { get; set; }
    public double MinTrackingConfidence { get; set; }
}

public class Output
{
    public bool IncludeFps { get; set; }
    public bool IncludeHeight { get; set; }
    public bool IncludeWidth { get; set; }
    public bool FlipX { get; set; }
    public bool FlipY { get; set; }
    public List<int> LmList { get; set; }
    public bool IncludeBox { get; set; }
    public bool IncludeCenter { get; set; }
    public bool IncludeVisibility { get; set; }
    public string Coordinates { get; set; }
    public int Round { get; set; }
    public bool PrintData { get; set; }
}
