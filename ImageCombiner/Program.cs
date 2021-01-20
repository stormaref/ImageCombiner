using System.Collections.Generic;
using System.Net;

namespace ImageCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            List<string> vs = new List<string> {
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
            };
            ProfileHeaderImageService profileHeaderImageService = new();
            profileHeaderImageService.GenerateHeaderImage(wc, vs, "mammad.jpeg");
        }
    }
}
