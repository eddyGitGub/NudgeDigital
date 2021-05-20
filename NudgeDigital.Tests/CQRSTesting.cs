using AutoMapper;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using NudgeDigital.Application.Contracts.Persistence;
using NudgeDigital.Application.Features.Configurations.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NudgeDigital.Tests
{
    public class CQRSTesting
    {
        [Fact]
        public async Task HandlerReturnsCorrectUserViewModel()
        {
            var cancelationToken = new CancellationToken();
            var fakeDataStore = A.Fake<INudgeDigitalDbContext>();
            var fakeMapper = A.Fake<IMapper>();
            var model = new CreateConfigurationCommand { ComponentType = "Test", Price = 40.56M, };
            
            // fakeDataStore.Configurations.AsNoTracking().AnyAsync(c => c.Name.ToLower().Equals(model.Name.ToLower(), new CancellationToken());

            var fake = await fakeDataStore.Configurations.AsNoTracking().AnyAsync(c => c.ComponentType.ToLower().Equals(model.ComponentType.ToLower()), cancelationToken);
            A.CallTo(() => fake).Returns(false);
            A.CallTo(fake);
            var sut = new CreateConfigurationCommandHandler(fakeDataStore,fakeMapper);
            //sut.Handle.
            var result = await sut.Handle(model, cancelationToken);
            
            

            Assert.NotNull(result);
            Assert.True(result.Status);
        }
    }
}
