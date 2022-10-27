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

        foreach (var t in args)
        {
            if (t.ToLower().StartsWith("input="))
            {
                jsonInput = t.Substring(6);
                break;
            }
        }

        var inputModel = Input.FromJson(jsonInput);

        var result = await _extractNftMetaData.GetTokenMeta(inputModel);


        var output = new OutPut();
        output.Properties = new List<Property>();
        

        foreach (var prop in result.Attributes)
        {
            output.Properties.Add(new Property()
            {
                Category = prop.TraitType,
                PropertyProperty = prop.Value
            });
        }
        System.Console.WriteLine(output.ToJson());
        //{
        //    "Name": "Happy Ape #234", 
        //    "Description": "An example description for a token", 
        //    "ExternalUrl": "Example.com/tokens/1234", 
        //    "Media": "example.com/image.jpg",  
        //    "Properties": [
        //    { "Category": "Eyes", "Property": "Sleepy" }, 
        //    { "Category": "Background", "Property": "Army Green" }, 
        //    { "Category": "Clothes", "Property": "Leather Jacket" }, 
        //    { "Category": "Fur", "Property": "Blue" }, 
        //    { "Category": "Mouth", "Property": "Bored Bubblegum" }, 
        //    { "Category": "Hat", "Property": "Fisherman's Hat"} 
        //    ] 
        //}

        System.Console.ReadLine();
    }
}
