using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace FormulaApp.UnitTests.Helpers
{
    public class MockHttpHandler<T>
    {
        internal static Mock<HttpMessageHandler> SetupGetRequest(List<T> response)
        {
            // Success
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(response))
            };
            mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;
        }

        //Not Found
        internal static Mock<HttpMessageHandler> SetupGetRequestNotFound()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Not Found")
            };
            mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;
        }

        //Bad Request
        internal static Mock<HttpMessageHandler> SetupGetRequestBadRequest()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("Bad Request")
            };
            mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;
        }

        // Internal Server Error
        internal static Mock<HttpMessageHandler> SetupGetRequestInternalServerError()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Internal Server Error")
            };
            mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;
        }

        // Unauthorized
        internal static Mock<HttpMessageHandler> SetupGetRequestUnauthorized()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent("Unauthorized")
            };
            mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;
        }

        // Forbidden
        internal static Mock<HttpMessageHandler> SetupGetRequestForbidden()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent("Forbidden")
            };
            mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;
        }

        // Not Implemented
        internal static Mock<HttpMessageHandler> SetupGetRequestNotImplemented()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.NotImplemented)
            {
                Content = new StringContent("Not Implemented")
            };
            mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;
        }

        // Service Unavailable
        
        internal static Mock<HttpMessageHandler> SetupGetRequestServiceUnavailable()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
            {
                Content = new StringContent("Service Unavailable")
            };
            mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return mockHandler;
        }
    }
}