using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NudgeDigital.Api.Controllers;
using NudgeDigital.Application.Features.Configuration.Command;
using NudgeDigital.Application.Features.Configuration.Query;
using System;
using Xunit;

namespace NudgeDigital.Tests
{
    public class ConfigurationsControllerTest
    {
        ConfigurationsController _controller;
        private IMediator _mediator;
        public ConfigurationsControllerTest()
        {
            _mediator = A.Fake<IMediator>(); ;
            _controller = new ConfigurationsController();
        }
        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange  
            var fakeIMediator = A.Fake<IMediator>();
            var controller = new ConfigurationsController();
            var conFig = new CreateConfigurationCommand { ComponentType = "Test", Price = 40.56M, };
            var send = await fakeIMediator.Send(conFig);
            A.CallTo(() => send);

            //Act  
            var data = await controller.Post(conFig);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_All_Configuration_Data_Return_OkResult()
        {
            //Arrange  
            var controller = new ConfigurationsController();
            var query = new GetConfigurationQuery();

            //Act  
            var data = await controller.GetList();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

    }
}
