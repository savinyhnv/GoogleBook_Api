﻿using EdenLab.FluentApi;
using EdenLab.FluentApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestTask.Creatio.Core.Abstractions.Integration;
using TestTask.Creatio.Inegration.Dto;
using TestTask.Creatio.Inegration.Dto.GoogleBooks;

namespace TestTask.Creatio.Integration.GoogleBooksCLient
{
    public class GoogleBooksClient : IGoogleBooksClient
    {
        private readonly ILogger<GoogleBooksClient> _logger;

        public GoogleBooksClient(ILogger<GoogleBooksClient> logger)
        {
            this._logger = logger;
        }

        public async Task<IHttpResponse<GoogleBooksClientResponse>> GetBooks(string searchKeyWord)
        {
            var request = new HttpRequestMessage();
            var result = await WebServiceInfoConstants.GoogleBooksApi.GetBooks
                .Configure(opt => opt.Logger = _logger)
                .SetRouteParameter("keyword", searchKeyWord)
                .Get()
                .AsJsonAsync<GoogleBooksClientResponse>();

            return result;
        }
    }
}
