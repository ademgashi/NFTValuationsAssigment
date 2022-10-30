using FluentAssertions;
using Microsoft.Extensions.Logging;
using NFTValuations.Core.Services;
using NSubstitute;
using Microsoft.Extensions.Configuration;
using NFTValuations.Core.Models;
using Microsoft.Extensions.Configuration.Json;

namespace NFTValuations.Core.Tests.Services
{
    public class MetaDataExtractionServiceTests
    {
        private ILogger<MetaDataExtractionService> subLogger;

        public MetaDataExtractionServiceTests()
        {
            this.subLogger = Substitute.For<ILogger<MetaDataExtractionService>>();
        }

        private MetaDataExtractionService CreateService()
        {

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var apiKey = (config["MoralisClient:ApiKey"]);

            return new MetaDataExtractionService(
                this.subLogger, apiKey);
        }


        public class TestInput : TestInputBase
        {
            public Token Input { get; set; }
            public string ExpectedResult { get; set; }


        }

        public static TheoryData<TestInput> NftMetaDataTests = new TheoryData<TestInput>
        {
            new TestInput
            {
                Name = "First Token",
                Input = new Token()
                {
                    ContractAddress = "0x1a92f7381b9f03921564a437210bb9396471050c", TokenIndeX = 0,

                },
                ExpectedResult = "Cool Cat #0",
                ExpectSuccess = true,
            },

            new TestInput
            {
                Name = "Second Token",
                Input = new Token()
                {
                    ContractAddress = "0xbc4ca0eda7647a8ab7c2061c2e118a18a936f13d", TokenIndeX = 1234,

                },
                ExpectedResult = null,
                ExpectSuccess = true,
            },


            new TestInput
            {
                Name = "Third Token",
                Input = new Token()
                {
                    ContractAddress = "0xec9c519d49856fd2f8133a0741b4dbe002ce211b", TokenIndeX = 30,

                },
                ExpectedResult = "Bonsai #30",
                ExpectSuccess = true,
            },
            
           };

        [Theory]
        [MemberData(nameof(NftMetaDataTests))]
        public async Task GetTokenMeta_StateUnderTest_ExpectedBehavior(TestInput test)
        {
            // Arrange
            var service = this.CreateService();
            
            
            // Act
            var result = await service.GetTokenMeta(test.Input);

            // Assert

            if (test.ExpectSuccess)
            {
                test.ExpectedResult.Should().BeEquivalentTo(result.Name);
                
            }
            
        }
    }
}
