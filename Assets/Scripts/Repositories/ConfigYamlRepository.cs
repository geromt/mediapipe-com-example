using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class ConfigYamlRepository : IConfigRepository
{
    private readonly ConfigModel _configModel;
    
    public ConfigYamlRepository(string fileName)
    {
        _configModel = Deserialize(LoadFile(fileName));
    }

    public int GetPort() => _configModel.Config.Port;
    public bool GetIncludeFps() => _configModel.Output.IncludeFps;
    public bool GetIncludeHeight() => _configModel.Output.IncludeHeight;
    public bool GetIncludeWidth() => _configModel.Output.IncludeWidth;
    public bool FlipX() => _configModel.Output.FlipX;
    public bool FlipY() => _configModel.Output.FlipY;
    public List<int> GetLmList() => _configModel.Output.LmList;
    public bool GetIncludeBox() => _configModel.Output.IncludeBox;
    public bool GetIncludeCenter() => _configModel.Output.IncludeCenter;
    public bool GetIncludeVisibility() => _configModel.Output.IncludeVisibility;
    public string GetCoordinates() => _configModel.Output.Coordinates;
    public int GetRound() => _configModel.Output.Round;
    
    private string LoadFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"File not found: {fileName}");
        }
        
        var yaml = File.ReadAllText(fileName);
        return yaml;
    }
    
    private ConfigModel Deserialize(string yaml)
    {
        var deserialize = new DeserializerBuilder()
            .WithNamingConvention(new UnderscoredNamingConvention())
            .Build();
        var configModel = deserialize.Deserialize<ConfigModel>(yaml);
        return configModel;
    }
}