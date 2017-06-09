using FilmLibrary.InternetMovieDB;
using FilmLibrary.InternetMovieDB.TheMovieDatabase;
using FilmLibrary.InternetMovieDB.TheMovieDatabase.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FilmLibrary.Test
{
    public class InternetMovieDBTest
    {
        //[Fact]
        //public async void Test()
        //{
        //    IHttpClient httpClient;
        //    if (!string.IsNullOrEmpty(InternetMovieDBSettings.Settings.ConfigItems.Proxy.Url) &&
        //        !string.IsNullOrEmpty(InternetMovieDBSettings.Settings.ConfigItems.Proxy.Username) &&
        //        !string.IsNullOrEmpty(InternetMovieDBSettings.Settings.ConfigItems.Proxy.Password))
        //    {
        //        httpClient = new TheMovieDBHttpClient(
        //            InternetMovieDBSettings.Settings.ConfigItems.Proxy.Url,
        //            InternetMovieDBSettings.Settings.ConfigItems.Proxy.Username,
        //            InternetMovieDBSettings.Settings.ConfigItems.Proxy.Password);
        //    }
        //    else
        //    {
        //        httpClient = new TheMovieDBHttpClient();
        //    }

        //    IMovieService<MovieSearchResult, MovieResult> movieService = new TheMovieDB<MovieSearchResult, MovieResult>(
        //        httpClient,
        //        InternetMovieDBSettings.Settings.ConfigItems.Themoviedb_apikey,
        //        InternetMovieDBSettings.Settings.ConfigItems.BaseUrl,
        //        InternetMovieDBSettings.Settings.ConfigItems.SearchMovieUrl,
        //        InternetMovieDBSettings.Settings.ConfigItems.GetMovieUrl);

        //    MovieSearchResult msr = await movieService.MovieSearchAsync("Fight Club");
        //    MovieResult mr = await movieService.GetMovieAsync("1");
        //}

        [Theory(DisplayName = "Search for movie")]
        [InlineData("Fight Club", 14)]
        [InlineData("xxxxxxxxxxxxxxxxxxxxx", 0)]
        public async void MovieSearchAsync(string query, int expectedNumber)
        {
            // Arrange
            IMovieService<MovieSearchResult, MovieResult> movieService = new TheMovieDB<MovieSearchResult, MovieResult>(
                new HttpClient(),
                "DummyAPI",
                "https://api.themoviedb.org",
                "3/search/movie",
                "3/movie");

            // Act
            var actual = await movieService.MovieSearchAsync(query);

            // Assert
            Assert.IsType(typeof(MovieSearchResult), actual);
            Assert.Equal(expectedNumber, actual.total_results);
        }

        [Theory(DisplayName = "Get Movie")]
        [InlineData("550", "Fight Club")]
        [InlineData("1", null)]
        public async void GetMovieAsync(string query, string expected)
        {
            // Arrange
            IMovieService<MovieSearchResult, MovieResult> movieService = new TheMovieDB<MovieSearchResult, MovieResult>(
                new HttpClient(),
                "DummyAPI",
                "https://api.themoviedb.org",
                "3/search/movie",
                "3/movie");

            // Act
            var actual = await movieService.GetMovieAsync(query);

            // Assert
            if (actual == null)
            {
                Assert.Equal(expected, null);
            }
            else
            {
                Assert.IsType(typeof(MovieResult), actual);
                Assert.Equal(expected, actual.title);

            }
            
        }
    }

    public class HttpClient : IHttpClient
    {
        public Task<string> MakeRequest(Uri address)
        {
            switch (address.AbsoluteUri)
            {
                case "https://api.themoviedb.org/3/search/movie?api_key=DummyAPI&language=en-US&page=1&include_adult=false&query=Fight+Club":
                    return Task<string>.Factory.StartNew(() => { return "{\"page\":1,\"total_results\":14,\"total_pages\":1,\"results\":[{\"vote_count\":7902,\"id\":550,\"video\":false,\"vote_average\":8.2,\"title\":\"Fight Club\",\"popularity\":8.71538,\"poster_path\":\"\\/adw6Lq9FiC9zjYEpOqfq03ituwp.jpg\",\"original_language\":\"en\",\"original_title\":\"Fight Club\",\"genre_ids\":[18],\"backdrop_path\":\"\\/87hTDiay2N2qWyX4Ds7ybXi9h8I.jpg\",\"adult\":false,\"overview\":\"A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy. Their concept catches on, with underground \\\"fight clubs\\\" forming in every town, until an eccentric gets in the way and ignites an out-of-control spiral toward oblivion.\",\"release_date\":\"1999-10-15\"},{\"vote_count\":9,\"id\":289732,\"video\":false,\"vote_average\":3.7,\"title\":\"Zombie Fight Club\",\"popularity\":1.46368,\"poster_path\":\"\\/7k9db7pJyTaVbz3G4eshGltivR1.jpg\",\"original_language\":\"zh\",\"original_title\":\"Zombie Fight Club\",\"genre_ids\":[28,27],\"backdrop_path\":\"\\/qrZssI8koUdRxkYnrOKMRY3m5Fq.jpg\",\"adult\":false,\"overview\":\"It's the end of the century at a corner of the city in a building riddled with crime - Everyone in the building has turned into zombies. After Jenny's boyfriend is killed in a zombie attack, she faces the challenge of surviving in the face of adversity. In order to stay alive, she struggles with Andy to flee danger.\",\"release_date\":\"2014-10-23\"},{\"vote_count\":1,\"id\":347807,\"video\":false,\"vote_average\":1,\"title\":\"Fight Club: Members Only\",\"popularity\":1.004892,\"poster_path\":\"\\/94ke4oJVXxM6zuTdZktV7SPCSUy.jpg\",\"original_language\":\"hi\",\"original_title\":\"Fight Club: Members Only\",\"genre_ids\":[28],\"backdrop_path\":null,\"adult\":false,\"overview\":\"Four friends head off to Bombay and get involved in the mother and father of all gang wars.\",\"release_date\":\"2006-02-17\"},{\"vote_count\":2,\"id\":440777,\"video\":false,\"vote_average\":9.5,\"title\":\"Female Fight Club\",\"popularity\":1.237698,\"poster_path\":\"\\/o6Sa24tGF9va8FnMtR5Uj7Icx8H.jpg\",\"original_language\":\"en\",\"original_title\":\"Female Fight Club\",\"genre_ids\":[28],\"backdrop_path\":null,\"adult\":false,\"overview\":\"A former fighter reluctantly returns to the life she abandoned in order to help her sister survive the sadistic world of illegal fighting and the maniac who runs it.\",\"release_date\":\"2017-03-16\"},{\"vote_count\":22,\"id\":14476,\"video\":false,\"vote_average\":7.3,\"title\":\"Clubbed\",\"popularity\":1.601286,\"poster_path\":\"\\/65fZKoJCxmAlazv9MucFq1GTrPl.jpg\",\"original_language\":\"en\",\"original_title\":\"Clubbed\",\"genre_ids\":[18,28,53,80],\"backdrop_path\":\"\\/uywB4ZS6iCuc4aCIsAOyhW4sFZJ.jpg\",\"adult\":false,\"overview\":\"An underworld drama set in the early 1980s, about a lonely factory worker whose life is transformed when he becomes a nightclub doorman.\",\"release_date\":\"2008-10-02\"},{\"vote_count\":5,\"id\":51021,\"video\":false,\"vote_average\":3,\"title\":\"Lure: Teen Fight Club\",\"popularity\":1.020796,\"poster_path\":\"\\/aRTX5Y52yGbVL6TGnyI4E8jjtz4.jpg\",\"original_language\":\"en\",\"original_title\":\"Lure: Teen Fight Club\",\"genre_ids\":[28,18,80],\"backdrop_path\":\"\\/5sWZRCsjzH1Dxo6gSBeX4RpAQ4p.jpg\",\"adult\":false,\"overview\":\"A community is under siege as three Belmont Highschool coed students go missing with no trace of their whereabouts. The pressure is on the police to capture the culprits responsible. Scouring the school hallways in search of clues, undercover female detective Maggie Rawdon (Jessica Sonnerborn) enters Belmont High as a transfer student in an attempt to solve the hideous disappearance of the students. Maggie makes a few new friends, and gets invited to a private rave in the country. Just as the group begins to suspect that they've taken a wrong turn, however, the trap is sprung and Maggie finds out firsthand what fate has befallen the missing girls.\",\"release_date\":\"2010-11-16\"},{\"vote_count\":0,\"id\":295477,\"video\":false,\"vote_average\":0,\"title\":\"Fight club camp kusse\",\"popularity\":1.00482,\"poster_path\":\"\\/5itVi2OcKAkTUK0xtVxueKURb1W.jpg\",\"original_language\":\"da\",\"original_title\":\"Fight club camp kusse\",\"genre_ids\":[],\"backdrop_path\":null,\"adult\":false,\"overview\":\"\",\"release_date\":\"2005-08-12\"},{\"vote_count\":0,\"id\":289100,\"video\":false,\"vote_average\":0,\"title\":\"Girls Fight Club\",\"popularity\":1.002219,\"poster_path\":null,\"original_language\":\"en\",\"original_title\":\"Girls Fight Club\",\"genre_ids\":[],\"backdrop_path\":null,\"adult\":false,\"overview\":\"The best women's wrestling competition of all time...and if you think it's fake you're in for a big surprise See LEGENDARY Mixed Martial Arts fighters coach their teams to victory in the cage! aka Chuck Lidell's Girl's Fight Club\",\"release_date\":\"2009-06-18\"},{\"vote_count\":0,\"id\":259016,\"video\":false,\"vote_average\":0,\"title\":\"Insane Fight Club\",\"popularity\":1.001881,\"poster_path\":\"\\/mLhwBQPV3iATe3L61kbpmxANwL8.jpg\",\"original_language\":\"en\",\"original_title\":\"Insane Fight Club\",\"genre_ids\":[99],\"backdrop_path\":null,\"adult\":false,\"overview\":\"A group of friends have created a brand new subculture that is taking over the streets of Glasgow. They've established their very own fight club, but this is no ordinary wrestling event - this is brutal, riotous chaos. Fights don't always stay inside the ring, people are bounced off the side of buses and thrown off balconies in pubs. They now plan the biggest show of their lives. The stakes are high, will it bring them the fame and recognition they need to survive?\",\"release_date\":\"2014-03-11\"},{\"vote_count\":1,\"id\":209599,\"video\":false,\"vote_average\":7,\"title\":\"Brooklyn Girls Fight Club\",\"popularity\":1.000935,\"poster_path\":\"\\/luWpP5WSw9JjbWS1J4BMnjkkJCX.jpg\",\"original_language\":\"en\",\"original_title\":\"Brooklyn Girls Fight Club\",\"genre_ids\":[99],\"backdrop_path\":null,\"adult\":false,\"overview\":\"From the birthplace of boxing legend Mike Tyson, young women brawl in secret fight clubs to win $1000 and invaluable street cred.\",\"release_date\":\"\"},{\"vote_count\":1,\"id\":151912,\"video\":false,\"vote_average\":7,\"title\":\"Jurassic Fight Club\",\"popularity\":1.000834,\"poster_path\":\"\\/AwECEjjen4eYSDZ3AETXnFG6dgu.jpg\",\"original_language\":\"de\",\"original_title\":\"Jurassic Fight Club\",\"genre_ids\":[99],\"backdrop_path\":null,\"adult\":false,\"overview\":\"Jurassic Fight Club, a paleontology-based miniseries that ran for 12 episodes, depicts how prehistoric beasts hunted their prey, dissecting these battles and uncovering a predatory world far more calculated and complex than originally thought. It was hosted by George Blasing, a self-taught paleontologist.\",\"release_date\":\"2008-10-22\"},{\"vote_count\":0,\"id\":104782,\"video\":false,\"vote_average\":0,\"title\":\"Florence Fight Club\",\"popularity\":1.000733,\"poster_path\":\"\\/eQqqu0srTYcclWqylvgpLyU87hV.jpg\",\"original_language\":\"en\",\"original_title\":\"Florence Fight Club\",\"genre_ids\":[28,53],\"backdrop_path\":\"\\/tcoAGvTo96R7Y9ZGVCCz7BZvrvb.jpg\",\"adult\":false,\"overview\":\"Four men decided to enter in the oldest Fight Club of the History, The Florentine Football tournament. A father and son, a black guy, an old champion and outsider clerk will enter in an arena of the time to win their fears, to go over their limits, to be heroes for a day.\",\"release_date\":\"2010-01-01\"},{\"vote_count\":4,\"id\":219897,\"video\":false,\"vote_average\":4,\"title\":\"Barrio Brawler\",\"popularity\":1.007633,\"poster_path\":\"\\/emSt011zMTnIAo1h7zviQHB55Yb.jpg\",\"original_language\":\"de\",\"original_title\":\"Barrio Brawler\",\"genre_ids\":[28,18,80],\"backdrop_path\":\"\\/slDvBs3jn0C08vuyvLJkikUN6qu.jpg\",\"adult\":false,\"overview\":\"A martial arts instructor must enter the world of illegal pit fighting in order to save his family and his dojo.\",\"release_date\":\"2013-08-27\"},{\"vote_count\":0,\"id\":322772,\"video\":false,\"vote_average\":0,\"title\":\"Insane Fight Club II - This Time It’s Personal\",\"popularity\":1.009162,\"poster_path\":\"\\/84mcV9ky4TSpD7dpHnsx7yBVs64.jpg\",\"original_language\":\"en\",\"original_title\":\"Insane Fight Club II - This Time It’s Personal\",\"genre_ids\":[99],\"backdrop_path\":null,\"adult\":false,\"overview\":\"Insane Fight Club is back. This year the boys are taking their unique form of entertainment to England as they stage fight nights in Birmingham, Leeds, Liverpool and Newcastle.\",\"release_date\":\"2015-01-21\"}]}"; });
                case "https://api.themoviedb.org/3/search/movie?api_key=DummyAPI&language=en-US&page=1&include_adult=false&query=xxxxxxxxxxxxxxxxxxxxx":
                    return Task<string>.Factory.StartNew(() => { return "{\"page\":1,\"total_results\":0,\"total_pages\":1,\"results\":[]}"; });
                case "https://api.themoviedb.org/3/movie/550?api_key=DummyAPI&language=en-US":
                    return Task<string>.Factory.StartNew(() => { return "{\"adult\":false,\"backdrop_path\":\"/87hTDiay2N2qWyX4Ds7ybXi9h8I.jpg\",\"belongs_to_collection\":null,\"budget\":63000000,\"genres\":[{\"id\":18,\"name\":\"Drama\"}],\"homepage\":\"http://www.foxmovies.com/movies/fight-club\",\"id\":550,\"imdb_id\":\"tt0137523\",\"original_language\":\"en\",\"original_title\":\"Fight Club\",\"overview\":\"A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy. Their concept catches on, with underground \\\"fight clubs\\\" forming in every town, until an eccentric gets in the way and ignites an out-of-control spiral toward oblivion.\",\"popularity\":7.71538,\"poster_path\":\"/adw6Lq9FiC9zjYEpOqfq03ituwp.jpg\",\"production_companies\":[{\"name\":\"Regency Enterprises\",\"id\":508},{\"name\":\"Fox 2000 Pictures\",\"id\":711},{\"name\":\"Taurus Film\",\"id\":20555},{\"name\":\"Linson Films\",\"id\":54050},{\"name\":\"Atman Entertainment\",\"id\":54051},{\"name\":\"Knickerbocker Films\",\"id\":54052}],\"production_countries\":[{\"iso_3166_1\":\"DE\",\"name\":\"Germany\"},{\"iso_3166_1\":\"US\",\"name\":\"United States of America\"}],\"release_date\":\"1999-10-15\",\"revenue\":100853753,\"runtime\":139,\"spoken_languages\":[{\"iso_639_1\":\"en\",\"name\":\"English\"}],\"status\":\"Released\",\"tagline\":\"How much can you know about yourself if you've never been in a fight?\",\"title\":\"Fight Club\",\"video\":false,\"vote_average\":8.199999999999999,\"vote_count\":7905}"; });
                case "https://api.themoviedb.org/3/movie/1?api_key=DummyAPI&language=en-US":
                    return Task<string>.Factory.StartNew(() => { return ""; });
                default:
                    throw new Exception("Address not found");
            }
        }
    }
}
