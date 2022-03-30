﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace TheBigImdbQuest
{
    class Scraper
    {
        private const int MaximumAllowedSize = 250;
        private const string ImdbBaseUrl = @"https://www.imdb.com";
        private const string TopListUrl = @"https://www.imdb.com/chart/top";

        private Movie[] movies;
        private readonly IWebPageGetter webPageDownloader;
        private readonly IHtmlDocument htmlDoc;

        private readonly Dictionary<string, string> XPaths = new Dictionary<string, string>()
        {
            ["selectTitles"] = "//tbody//tr//td[@class='titleColumn']//a",
            ["selectLinks"] = "//tbody//tr//td[@class='titleColumn']//a",
            ["selectRate"] = "//tbody//tr//td[@class='posterColumn']//span[@name='ir']",
            ["selectVotes"] = "//tbody//tr//td[@class='posterColumn']//span[@name='nv']",
            ["selectOscars"] = "//li[@data-testid='award_information']//a",
        };

        public Scraper(IWebPageGetter webPageDownloader, IHtmlDocument htmlDoc)
        {
            this.webPageDownloader = webPageDownloader;
            this.htmlDoc = htmlDoc;
        }

        public void ScrappingImdb(int nrOfMovies)
        {
            nrOfMovies = Math.Min(nrOfMovies, MaximumAllowedSize);
            movies = new Movie[nrOfMovies];

            string TopListPageHtml = webPageDownloader.GetWebPageAsync(TopListUrl).Result;

            ExtractTopListHtml(TopListPageHtml);
        }

        public Movie[] Movies { get => movies; }

        private void ExtractTopListHtml(string html)
        {
            htmlDoc.LoadHtml(html);

            string[] titleTopMovies = GetTitles();
            string[] linkTopMovies = GetLinks();
            double[] rate = GetRates();
            int[] nrOfVotes = GetNrOfVotes();

            int[] oscarList = GetOscars(linkTopMovies);

            Parallel.For(0, movies.Length, i =>
            {
                movies[i] = new Movie
                {
                    Title = titleTopMovies[i],
                    OriginalRating = rate[i],
                    NrOfRatings = nrOfVotes[i],
                    NrOfOscars = oscarList[i],
                };
            });
        }

        private string[] GetTitles()
        {
            return htmlDoc.DocumentNode.SelectNodes(XPaths["selectTitles"])
                .Select(n => n.InnerText)
                .Take(movies.Length).ToArray();
        }

        private string[] GetLinks()
        {
            return htmlDoc.DocumentNode.SelectNodes(XPaths["selectLinks"])
                .Select(n => ImdbBaseUrl + n.Attributes["href"].Value)
                .Take(movies.Length).ToArray();
        }

        private double[] GetRates()
        {
            return htmlDoc.DocumentNode.SelectNodes(XPaths["selectRate"])
                .Select(n => double.TryParse(n.Attributes["data-value"].Value.Substring(0, 3),
                                             NumberStyles.Number,
                                             CultureInfo.InvariantCulture,
                                             out double tmp) ? tmp : 0)
                .Take(movies.Length).ToArray();
        }

        private int[] GetNrOfVotes()
        {
            return htmlDoc.DocumentNode.SelectNodes(XPaths["selectVotes"])
                .Select(n => int.TryParse(n.Attributes["data-value"].Value,
                                          out int tmp) ? tmp : 0)
                .Take(movies.Length).ToArray();
        }

        private int[] GetOscars(string[] linkTopMovies)
        {
            return webPageDownloader.GetWebPageAsync(linkTopMovies).Result
                .Where(n => n != null)
                .Select(n => GetOscars(n)).ToArray();
        }

        private int GetOscars(string html)
        {
            htmlDoc.LoadHtml(html);
            int result = 0;

            var titlesTop = htmlDoc.DocumentNode
                .SelectNodes(XPaths["selectOscars"])
                .Select(n => n.InnerText);

            if (titlesTop.FirstOrDefault().Contains("Won"))
            {
                Regex reg = new Regex(@"(\d+)");
                string oscarNumber = reg.Match(titlesTop.FirstOrDefault()).Groups[0].Value;
                int.TryParse(oscarNumber, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
            }

            return result;
        }
    }
}
