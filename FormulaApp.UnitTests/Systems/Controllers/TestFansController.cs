using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FormulaApp.Api.Controllers;
using FormulaApp.Api.Models;
using FormulaApp.Api.Services.Interfaces;
using FormulaApp.UnitTests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FormulaApp.UnitTests.Systems.Controllers
{
    public class TestFansController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200(){
            var moqFanService= new Mock<IFanService>();
            moqFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(FanFixtures.GetFans());
                
            // Arrange: setting up the test
            var controller = new FansController(moqFanService.Object);
            // Act: Executing the action
            var result =(OkObjectResult) await controller.Get();
            // Assert: Verifying the result
            // Assert.Equal(200, result.StatusCode); // xUnit-- this is the old way
            result.StatusCode.Should().Be(200); // FluentAssertions
        }

        [Fact]
        public async Task Get_OnSuccess_InvokeService()
        {   
                // Arrange
                var moqFanService= new Mock<IFanService>();
                moqFanService.Setup(service => service.GetAllFans())
                    .ReturnsAsync(FanFixtures.GetFans());

                var controller = new FansController(moqFanService.Object);

                // Act
                var result =(OkObjectResult) await controller.Get();

                // Assert
                moqFanService.Verify(service => service.GetAllFans(), Times.Once);  
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfFans()
        {   
                // Arrange
                var moqFanService= new Mock<IFanService>();
                moqFanService.Setup(service => service.GetAllFans())
                    .ReturnsAsync(FanFixtures.GetFans());

                var controller = new FansController(moqFanService.Object);

                // Act
                var result =(OkObjectResult) await controller.Get();

                // Assert
                result.Should().BeOfType<OkObjectResult>();
                result.Value.Should().BeOfType<List<Fan>>();
    }

        [Fact]
        public async Task Get_OnNoFans_ReturnNotfound()
        {
            
            // Arrange
            var moqFanService= new Mock<IFanService>();
            moqFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(new List<Fan>());

            var controller = new FansController(moqFanService.Object);

            // Act
            var result =(NotFoundResult) await controller.Get();
            
            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }
}
}