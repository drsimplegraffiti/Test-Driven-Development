using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FormulaApp.Api.Configuration;
using FormulaApp.Api.Models;
using FormulaApp.Api.Services;
using FormulaApp.UnitTests.Fixtures;
using FormulaApp.UnitTests.Helpers;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace FormulaApp.UnitTests.Systems.Services
{
    public class TestFanService
    {
        [Fact]
        public async Task GetAllFans_OnInvoked_HttpGet()
        {
            // Arrange
            var Url = "https://mywebsite.com/api/v1/fans";
            var response = FanFixtures.GetFans();
            var moqHandler =MockHttpHandler<Fan>.SetupGetRequest(response);
            var httpClient = new HttpClient(moqHandler.Object);
            var config = Options.Create(new ApiServiceConfig(){Url = Url});
            
            var fanService = new FanService(httpClient, config);

            // Act
            await fanService.GetAllFans();

            // Assert
            moqHandler.Protected().Verify("SendAsync", Times.Once(), 
                ItExpr.Is<HttpRequestMessage>(r => 
                r.Method == HttpMethod.Get && r.RequestUri.ToString() == Url),
                ItExpr.IsAny<CancellationToken>());
        }



        [Fact]
        public async Task GetAllFans_OnInvoked_ListOfFans()
        {
            // Arrange
            var Url = "https://mywebsite.com/api/v1/fans";
            var response = FanFixtures.GetFans();
            var moqHandler =MockHttpHandler<Fan>.SetupGetRequest(response);
            var httpClient = new HttpClient(moqHandler.Object);
            var config = Options.Create(new ApiServiceConfig(){Url = Url});
            
            var fanService = new FanService(httpClient, config);

            // Act
            var result = await fanService.GetAllFans();

            // Assert
            result.Should().BeOfType<List<Fan>>();
        }

          [Fact]
        public async Task GetAllFans_OnInvoked_ReturnEmpty()
        {
            // Arrange
            var Url = "https://mywebsite.com/api/v1/fans";
            var moqHandler =MockHttpHandler<Fan>.SetupGetRequestNotFound();
            var httpClient = new HttpClient(moqHandler.Object);
            var config = Options.Create(new ApiServiceConfig(){Url = Url});
            
            var fanService = new FanService(httpClient, config);

            // Act
            var result = await fanService.GetAllFans();

            // Assert
            result.Should().BeOfType<List<Fan>>();
        }
    }
}