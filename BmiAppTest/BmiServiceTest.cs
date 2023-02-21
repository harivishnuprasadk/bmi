namespace BmiAppTest;
using BmiApp.Services;
using Moq;
using BmiApp.DataAccess;
using BmiApp.Models;
using BmiApp.Utilities;
using BmiApp.Models.DTO;
using BmiApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using System.Collections.Generic;

public class BmiServiceTest
{
    public Mock<IBmiService> mock = new Mock<IBmiService>();
    public Mock<IBmiUserService> mock2 = new Mock<IBmiUserService>();
    public Mock<IBmiUserHealthService> mock3 = new Mock<IBmiUserHealthService>();

    [Fact]
    public async Task GetHealthSUmmary()
    {

        BmiUserHealthDataSummaryDto bmiHealthInput = new BmiUserHealthDataSummaryDto()
        {
            Id = 1,
            age=54,
            Bmi=22.22m,
            Weight=70,
            Height=170,
            WeightStatus="NormalWeight",
            email="test@gmail.com",
            DocUrl="test.blob.azure.com"
        };
         mock3.Setup(p=>p.GetUserHealthDataSummary("test@gmail.com")).ReturnsAsync(bmiHealthInput);

        BmiUserHealthController bmiUserHealthController = new BmiUserHealthController(mock3.Object);
        IActionResult result = await bmiUserHealthController.GetUserHealthDataSummary("test@gmail.com");
        var okObjectResult = result as OkObjectResult;
        BmiUserHealthDataSummaryDto bmiHealthDataExpected = okObjectResult?.Value as BmiUserHealthDataSummaryDto;

        Assert.Equal(bmiHealthInput.Id, bmiHealthDataExpected.Id);
        Assert.Equal(bmiHealthInput.age, bmiHealthDataExpected.age);
        Assert.Equal(bmiHealthInput.Bmi, bmiHealthDataExpected.Bmi);
        Assert.Equal(bmiHealthInput.Weight, bmiHealthDataExpected.Weight);
        Assert.Equal(bmiHealthInput.Height, bmiHealthDataExpected.Height);
        Assert.Equal(bmiHealthInput.WeightStatus, bmiHealthDataExpected.WeightStatus);
        Assert.Equal(bmiHealthInput.email, bmiHealthDataExpected.email);
        Assert.Equal(bmiHealthInput.DocUrl, bmiHealthDataExpected.DocUrl);
    }

    [Fact]
    public async Task GetUserInfo()
    {
        BmiUserDataDto bmiUserDataDto = new BmiUserDataDto()
        {

            DateOfBirth = DateTime.Now.AddYears(-10).ToString(),
            Email = "test@gmail.com",
            PhoneNumber = "12345"
        };
        mock2.Setup(p => p.GetUserDataDto("test@gmail.com")).ReturnsAsync(bmiUserDataDto);
        BmiUserController bmiUserController = new BmiUserController(mock2.Object);

        IActionResult result = await bmiUserController.GetUserInfo("test@gmail.com");
        var okObjectResult = result as OkObjectResult;
        BmiUserDataDto bmi = okObjectResult?.Value as BmiUserDataDto;

        Assert.Equal(bmiUserDataDto, okObjectResult?.Value);
        Assert.Equal(bmiUserDataDto.DateOfBirth, bmi?.DateOfBirth);
        Assert.Equal(bmiUserDataDto.Email, bmi?.Email);
        Assert.Equal(bmiUserDataDto.PhoneNumber, bmi?.PhoneNumber);
    }

    [Fact]
    public async Task GetBmiMetrics()
    {
        List<BmiMetricsDto> bmiMetricsDtoInput = new List<BmiMetricsDto>();
        bmiMetricsDtoInput.Add(new BmiMetricsDto() { Bmi=22.22m,WeightStatus=WeightStatus.Obese});

        mock.Setup(p=>p.GetAllBmiMetrics()).ReturnsAsync(bmiMetricsDtoInput);
        BmiController bmiController = new BmiController(mock.Object);

        IActionResult result = await bmiController.GetAllBmiMetrics();
        var okObjectResult = result as OkObjectResult;
        List<BmiMetricsDto> bmiMetricsDtoResult = okObjectResult?.Value as List<BmiMetricsDto>;
        Assert.Equal(bmiMetricsDtoInput[0].Bmi, bmiMetricsDtoResult?[0].Bmi);
        Assert.Equal(bmiMetricsDtoInput[0].WeightStatus, bmiMetricsDtoResult?[0].WeightStatus);
    }
}
