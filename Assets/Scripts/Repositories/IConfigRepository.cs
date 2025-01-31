using System.Collections.Generic;

public interface IConfigRepository
{
    int GetPort();
    bool GetIncludeFps();
    bool GetIncludeHeight();
    bool GetIncludeWidth();
    bool FlipX();
    bool FlipY();
    List<int> GetLmList();
    bool GetIncludeBox();
    bool GetIncludeCenter();
    bool GetIncludeVisibility();
    string GetCoordinates();
    int GetRound();
}
