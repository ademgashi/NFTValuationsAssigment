using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NFTValuations.Core.Services;
using NFTValuations.Core.Models;

namespace NFTValuations.Core.Tests.Services
{
    //public class InfuraApiServiceTests
    //{
    //    private ILogger<InfuraApiService> subLogger;


    //    public InfuraApiServiceTests()
    //    {
    //        subLogger = Substitute.For<ILogger<InfuraApiService>>();
    //    }

    //    private InfuraApiService CreatePalindromeChecker()
    //    {
    //        return new InfuraApiService("test","test");
    //    }

    //    //public class PalindromeTestInput : TestInputBase
    //    //{
    //    //    public string Input { get; set; }
    //    //    public List<PalindromeResult> ExpectedResult { get; set; }


    //    //}

    //    //public static TheoryData<PalindromeTestInput> PalindromeTests = new TheoryData<PalindromeTestInput>
    //    //{
    //    //    new PalindromeTestInput
    //    //    {
    //    //        Name = "Input is null",
    //    //        Input = "",
    //    //        ExpectedResult = new List<PalindromeResult>(),
    //    //        ExpectSuccess = false,
    //    //    },

    //    //    new PalindromeTestInput
    //    //    {
    //    //        Name = "Input is sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop",
    //    //        Input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop",
    //    //        ExpectedResult = new List<PalindromeResult>()
    //    //        {
    //    //            new PalindromeResult()
    //    //            {
    //    //                Text = "hijkllkjih",
    //    //                Index=23,
    //    //                Length= 10

    //    //            },
    //    //            new PalindromeResult()
    //    //            {
    //    //                Text = "defggfed",
    //    //                Index=13,
    //    //                Length= 8

    //    //            },
    //    //            new PalindromeResult()
    //    //            {
    //    //                Text = "abccba",
    //    //                Index=5,
    //    //                Length= 6

    //    //            }

    //    //        },
    //    //        ExpectSuccess = true,
    //    //    },

    //    //    new PalindromeTestInput
    //    //    {
    //    //        Name = "Input is aaa",
    //    //        Input = "aaa",
    //    //        ExpectedResult = new List<PalindromeResult>()
    //    //        {
    //    //            new PalindromeResult()
    //    //            {
    //    //                Text = "aaa",
    //    //                Index=0,
    //    //                Length= 3

    //    //            },
    //    //        },
    //    //        ExpectSuccess = true,


    //    //    },

    //    //   };

    //    //[Theory]
    //    //[MemberData(nameof(PalindromeTests))]
    //    //public void GetPalindromes_StateUnderTest_ExpectedBehavior(PalindromeTestInput test)
    //    //{

    //    //    // Arrange
    //    //    var palindromeChecker = CreatePalindromeChecker();

    //    //    // Act
    //    //    var result = palindromeChecker.GetPalindromes(test.Input);

    //    //    // Assert
    //    //    if (test.ExpectSuccess)
    //    //    {
    //    //        test.ExpectedResult.Should().BeEquivalentTo(result);
    //    //        test.ExpectedResult.Count.Should().Be(result.Count);
                
    //    //    }

    //    //}
    //}
}
