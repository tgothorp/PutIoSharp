using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using PutIo.Sharp.Clients;
using PutIo.Sharp.Configuration;

namespace PutIo.Sharp.Tests.Unit
{
    public class BaseTest : IDisposable
    {
        protected readonly PutIoApiClient PutioApiClient;
        protected readonly PutioConfiguration PutioConfiguration;
        
        private readonly Mock<HttpMessageHandler> _handlerMock;

        protected BaseTest()
        {
            _handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            
            PutioConfiguration = new PutioConfiguration
            {
                 Token = "TEST_TOKEN",
                 ApiHttpClient = new HttpClient(_handlerMock.Object),
                 UploadHttpClient = new HttpClient(_handlerMock.Object)
            };
            
            PutioApiClient = new PutIoApiClient(PutioConfiguration);
        }

        protected void OverrideApiResponse(HttpStatusCode statusCode, string responseBody)
        {
            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = statusCode,
                    Content = new StringContent(responseBody),
                })
                .Verifiable();
        }

        public void Dispose()
        {
            
        }
    }
}