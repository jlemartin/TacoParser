using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing a line");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogWarning($"Problem processing {line}");
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            // You are going to need to parse your string as a `double`

            double latitude = 0;
            if (Double.TryParse(cells[0], out latitude) == false)
            {
                logger.LogError($"{cells[0]} Bad data: Couldn't parse latitude");
            }
            //var latitude = Double.Parse(cells[0]);

            // grab the longitude from your array at index 1
            double longitude = 0;
            if (Double.TryParse(cells[1], out longitude) == false)
            {
                logger.LogError($"{cells[1]} Bad data: Couldn't parse longitude");
            }
            // var longitude = Double.Parse(cells[1]);

            // grab the name from your array at index 2
            var name = cells[2];

            if (name == null || name.Length == 0)
            {
                logger.LogError("No location");
            }


            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // TacoBell class has a Location property which is a struct Point
            // Thus, a point object is needed
            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            // Instantiating TacoBell class and supplying property values
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;        

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell;
        }
    }
}