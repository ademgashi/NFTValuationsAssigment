using NFTValuations.Core.Models;

namespace NFTValuations.Core.Interfaces;

public interface IExtractNftMetaData
{
    /// <summary>
    /// Given input as <see cref="Input"/> extract metadata.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<IpfsResponse> GetTokenMeta(Input input);
}