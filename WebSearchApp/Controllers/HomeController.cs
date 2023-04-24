using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebSearch.Models;
using Nest;

namespace WebSearch.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ElasticClient _client;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        var cloudId = "https://t1-013eaf.es.us-central1.gcp.cloud.es.io";
        var username = "elastic";
        var password = "M1ebhIUbFZYojr6jKFIj1Y68";
        var indexName = "index5";
        
        var settings = new ConnectionSettings(new Uri(cloudId))
            .DefaultIndex(indexName)
            .BasicAuthentication(username, password);

        _client = new ElasticClient(settings);
    }

    // https://www.elastic.co/guide/en/elasticsearch/reference/8.7/query-dsl-fuzzy-query.html
    // https://www.elastic.co/guide/en/elasticsearch/reference/current/analysis-snowball-tokenfilter.html

    public IActionResult Index(string searchText, int pageNumber = 1, int pageSize = 10)
        {
            var searchResults = _client.Search<Details>(s => s
                .Query(q => q
                    .MultiMatch(m => m
                        .Query(searchText)
                        .Fields("*")
                        .Fuzziness(Fuzziness.Auto)
                    )
                )
                .From((pageNumber - 1) * pageSize)
                .Size(pageSize)
            );

            var viewModel = new SearchResultsModel
            {
                SearchText = searchText,
                Results = searchResults.Documents.ToList(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)searchResults.Total/pageSize)
            };

            return View(viewModel);
        }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
