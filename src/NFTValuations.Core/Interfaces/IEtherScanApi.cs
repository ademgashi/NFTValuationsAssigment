namespace NFTValuations.Core.Interfaces;

public interface IGetAbi
{
    /// <summary>
    /// Get Abi for given contractAddress
    /// </summary>
    /// <param name="contractAddress"></param>
    /// <returns></returns>
    Task<string> GetAbi(string contractAddress);
}