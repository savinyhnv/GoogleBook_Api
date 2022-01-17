using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestTask.Creatio.Inegration.Dto.GoogleBooks
{
    public class GoogleBooksClientResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }
        [JsonProperty("items")]
        public List<GoogleBook> Items { get; set; }
    }

    public class GoogleBook
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("etag")]
        public string Etag { get; set; }
        [JsonProperty("selfLink")]
        public string SelfLink { get; set; }
        [JsonProperty("volumeInfo")]
        public GoogleBookVolumeInfo VolumeInfo { get; set; }
        [JsonProperty("saleInfo")]
        public GoogleBookSaleInfo SaleInfo { get; set; }
    }

    public class GoogleBookVolumeInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }
        [JsonProperty("authors")]
        public List<string> Authors { get; set; }
        [JsonProperty("publisher")]
        public string Publisher { get; set; }
        [JsonProperty("publishedDate")]
        public string PublishedDate { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("industryIdentifiers")]
        public List<GoogleBookIndustryIdentifiers> IndustryIdentifiers { get; set; }

    }

    public class GoogleBookIndustryIdentifiers
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }

    public class GoogleBookSaleInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("saleability")]
        public string Saleability { get; set; }
        [JsonProperty("isEbook")]
        public bool isEbook { get; set; }
    }

    public class GoogleBookAccessInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("viewability")]
        public string Viewability { get; set; }
        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }
        [JsonProperty("publicDomain")]
        public bool PublicDomain { get; set; }
        [JsonProperty("textToSpeechPermission")]
        public string TextToSpeechPermission { get; set; }
        [JsonProperty("epub")]
        public GoogleBookEpub Epub { get; set; }
        [JsonProperty("pdf")]
        public GoogleBookPdf Pdf { get; set; }
        [JsonProperty("webReaderLink")]
        public string WebReaderLink { get; set; }
        [JsonProperty("accessViewStatus")]
        public string AccessViewStatus { get; set; }
        [JsonProperty("quoteSharingAllowed")]
        public bool QuoteSharingAllowed { get; set; }

    }

    public class GoogleBookEpub
    {
        [JsonProperty("isAvailable")]
        public bool isAvailable { get; set; }
    }

    public class GoogleBookPdf
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
        [JsonProperty("acsTokenLink")]
        public string AcsTokenLink { get; set; }
    }
}
