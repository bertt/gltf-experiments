using laszip.net;
using System.Collections.Generic;
using System.Numerics;

namespace GltfExperiments.Forms
{
    class LasReader
    {
        public static List<Vector3> Readlas(string lazfile)
        {
            // int classification = 0;
            var lazReader = new laszip_dll();
            var compressed = true;
            lazReader.laszip_open_reader(lazfile, ref compressed);
            var numberOfPoints = lazReader.header.number_of_point_records;
            var coordArray = new double[3];

            var points = new List<Vector3>();
            // Loop through number of points indicated
            for (int pointIndex = 0; pointIndex < numberOfPoints; pointIndex++)
            {
                var point = new Vector3();
                // Read the point
                lazReader.laszip_read_point();

                // Get precision coordinates
                lazReader.laszip_get_coordinates(coordArray);
                point.X = (float)coordArray[0];
                point.Y = (float)coordArray[1];
                point.Z = (float)coordArray[2];
                // point.W = lazReader.point.classification;

                points.Add(point);
                // Get classification value
            }

            lazReader.laszip_close_reader();
            return points;
        }
    }
}
