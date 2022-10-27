using Nethereum.Contracts;

namespace NFTValuations.Core.Interfaces;

public interface IInfuraApi
{
    /// <summary>
    /// Get Contract for Abi and Address
    /// </summary>
    /// <param name="abi"></param>
    /// <param name="contractAddress"></param>
    /// <returns></returns>
    Contract GetContract(string abi, string contractAddress);
}