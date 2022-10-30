using System.Xml.XPath;
using NFTValuations.Core.Interfaces;
using NFTValuations.Core.Models;

namespace NFTValuations.Console;

public class App
{
    private readonly IExtractNftMetaData _extractNftMetaData;

    public App(IExtractNftMetaData extractNftMetaData)
    {
        _extractNftMetaData = extractNftMetaData;
    }

    public async Task Run(string[] args)
    {
        string jsonInput = "";

        if (File.Exists("TestData.json"))
        {
            jsonInput = File.ReadAllText("TestData.json");
        }
        else
        {
            System.Console.Write("Can not find testdata file!!!");
        }
        
        var tokenData = TestData.FromJson(jsonInput);
        
        foreach (var token in tokenData.TokenData)
        {
            var result = await _extractNftMetaData.GetTokenMeta(token);
            System.Console.WriteLine(result.ToJson());
            
        }
        
        System.Console.ReadLine();
    }
}
