using NasaServices.Contracts;
using NasaServices.MappingModelsApi;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace NasaServices
{
    public class ExcelService : IExcelService
    {

        public async Task<byte[]> CreateNasaFile(NeoBrowse asteroidsData)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();

            var neoSheet = CreateNeoSheet(excelPackage, asteroidsData);
            var closeApproachSheet = CreateCloseApproachSheet(excelPackage, asteroidsData);
            var orbitalDataSheet = CreateOrbitalDataSheet(excelPackage, asteroidsData);

            neoSheet.Cells.AutoFitColumns();
            closeApproachSheet.Cells.AutoFitColumns();
            orbitalDataSheet.Cells.AutoFitColumns();

            return await excelPackage.GetAsByteArrayAsync();
        }


        private ExcelWorksheet CreateNeoSheet(ExcelPackage package, NeoBrowse asteroidsData)
        {
            var sheet = package.Workbook.Worksheets.Add("Near_earth_objects");

            sheet.Cells[1, 1].Value = "Id";
            sheet.Cells[1, 2].Value = "Neo_reference_id";
            sheet.Cells[1, 3].Value = "Name";
            sheet.Cells[1, 4].Value = "Name_limited";
            sheet.Cells[1, 5].Value = "Designation";
            sheet.Cells[1, 6].Value = "Nasa_jpl_url";
            sheet.Cells[1, 7].Value = "Absolute_magnitude_h";
            sheet.Cells[1, 8].Value = "Estimated_diameter_kilometers_min";
            sheet.Cells[1, 9].Value = "Estimated_diameter_kilometers_max";
            sheet.Cells[1, 10].Value = "Estimated_diameter_meters_min";
            sheet.Cells[1, 11].Value = "Estimated_diameter_meters_max";
            sheet.Cells[1, 12].Value = "Estimated_diameter_miles_min";
            sheet.Cells[1, 13].Value = "Estimated_diameter_miles_max";
            sheet.Cells[1, 14].Value = "Estimated_diameter_feet_min";
            sheet.Cells[1, 15].Value = "Estimated_diameter_feet_max";
            sheet.Cells[1, 16].Value = "Is_potentially_hazardous_asteroid";
            sheet.Cells[1, 17].Value = "Is_sentry_object";

            if (asteroidsData.Asteroids is null)
            {
                return sheet;
            }

            for (int i = 0; i < asteroidsData.Asteroids.Count; i++)
            {
                sheet.Cells[i + 2, 1].Value = asteroidsData.Asteroids[i].Id;
                sheet.Cells[i + 2, 2].Value = asteroidsData.Asteroids[i].NeoReferenceId;
                sheet.Cells[i + 2, 3].Value = asteroidsData.Asteroids[i].Name;
                sheet.Cells[i + 2, 4].Value = asteroidsData.Asteroids[i].NameLimited;
                sheet.Cells[i + 2, 5].Value = asteroidsData.Asteroids[i].Designation;
                sheet.Cells[i + 2, 6].Value = asteroidsData.Asteroids[i].NasaJplUrl;
                sheet.Cells[i + 2, 7].Value = asteroidsData.Asteroids[i].AbsoluteMagnitudeH;
                sheet.Cells[i + 2, 8].Value = asteroidsData.Asteroids[i].EstimatedDiameter.Kilometers.EstimatedDiameterMin;
                sheet.Cells[i + 2, 9].Value = asteroidsData.Asteroids[i].EstimatedDiameter.Kilometers.EstimatedDiameterMax;
                sheet.Cells[i + 2, 10].Value = asteroidsData.Asteroids[i].EstimatedDiameter.Meters.EstimatedDiameterMin;
                sheet.Cells[i + 2, 11].Value = asteroidsData.Asteroids[i].EstimatedDiameter.Meters.EstimatedDiameterMax;
                sheet.Cells[i + 2, 12].Value = asteroidsData.Asteroids[i].EstimatedDiameter.Miles.EstimatedDiameterMin;
                sheet.Cells[i + 2, 13].Value = asteroidsData.Asteroids[i].EstimatedDiameter.Miles.EstimatedDiameterMax;
                sheet.Cells[i + 2, 14].Value = asteroidsData.Asteroids[i].EstimatedDiameter.Feet.EstimatedDiameterMin;
                sheet.Cells[i + 2, 15].Value = asteroidsData.Asteroids[i].EstimatedDiameter.Feet.EstimatedDiameterMax;
                sheet.Cells[i + 2, 16].Value = asteroidsData.Asteroids[i].IsPotentiallyHazardousAsteroid;
                sheet.Cells[i + 2, 17].Value = asteroidsData.Asteroids[i].IsSentryObject;
            }

            return sheet;
        }

        private ExcelWorksheet CreateCloseApproachSheet(ExcelPackage package, NeoBrowse asteroidsData)
        {
            var sheet = package.Workbook.Worksheets.Add("Close_approaches");

            sheet.Cells[1, 1].Value = "Asteroid_name";
            sheet.Cells[1, 2].Value = "Close_approach_date";
            sheet.Cells[1, 3].Value = "Close_approach_date_full";
            sheet.Cells[1, 4].Value = "Epoch_date_close_approach";
            sheet.Cells[1, 5].Value = "Relative_velocity_kilometers_per_second";
            sheet.Cells[1, 6].Value = "Relative_velocity_kilometers_per_hour";
            sheet.Cells[1, 7].Value = "Relative_velocity_miles_per_hour";
            sheet.Cells[1, 8].Value = "Miss_distance_astronomical";
            sheet.Cells[1, 9].Value = "Miss_distance_lunar";
            sheet.Cells[1, 10].Value = "Miss_distance_kilometers";
            sheet.Cells[1, 11].Value = "Miss_distance_miles";
            sheet.Cells[1, 12].Value = "orbiting_body";

            int row = 2;

            if (asteroidsData.Asteroids is null)
            {
                return sheet;
            }

            foreach (var asteroid in asteroidsData.Asteroids)
            {
                sheet.Cells[row, 1].Value = asteroid.Name;

                foreach (var closeApproach in asteroid.CloseApproachData)
                {
                    sheet.Cells[row, 2].Value = closeApproach.CloseApproachDate;
                    sheet.Cells[row, 3].Value = closeApproach.CloseApproachDateFull;
                    sheet.Cells[row, 4].Value = closeApproach.EpochDateCloseApproach;
                    sheet.Cells[row, 5].Value = closeApproach.RelativeVelocity.KilometersPerSecond;
                    sheet.Cells[row, 6].Value = closeApproach.RelativeVelocity.KilometersPerHour;
                    sheet.Cells[row, 7].Value = closeApproach.RelativeVelocity.MilesPerHour;
                    sheet.Cells[row, 8].Value = closeApproach.MissDistance.Astronomical;
                    sheet.Cells[row, 9].Value = closeApproach.MissDistance.Lunar;
                    sheet.Cells[row, 10].Value = closeApproach.MissDistance.Kilometers;
                    sheet.Cells[row, 11].Value = closeApproach.MissDistance.Miles;
                    sheet.Cells[row, 12].Value = closeApproach.OrbitingBody;

                    row++;
                }
                row++;
            }
            return sheet;
        }

        private ExcelWorksheet CreateOrbitalDataSheet(ExcelPackage package, NeoBrowse asteroidsData)
        {
            var sheet = package.Workbook.Worksheets.Add("Orbital_data");

            sheet.Cells[1, 1].Value = "Asteroid_name";
            sheet.Cells[1, 2].Value = "Orbit_id";
            sheet.Cells[1, 3].Value = "Orbit_determination_date";
            sheet.Cells[1, 4].Value = "First_observation_date";
            sheet.Cells[1, 5].Value = "Last_observation_date";
            sheet.Cells[1, 6].Value = "Data_arc_in_days";
            sheet.Cells[1, 7].Value = "Observations_used";
            sheet.Cells[1, 8].Value = "Orbit_uncertainty";
            sheet.Cells[1, 9].Value = "Minimum_orbit_intersection";
            sheet.Cells[1, 10].Value = "Jupiter_tisserand_invariant";
            sheet.Cells[1, 11].Value = "Epoch_osculation";
            sheet.Cells[1, 12].Value = "Eccentricity";
            sheet.Cells[1, 13].Value = "Semi_major_axis";
            sheet.Cells[1, 14].Value = "Inclination";
            sheet.Cells[1, 15].Value = "Ascending_node_longitude";
            sheet.Cells[1, 16].Value = "Orbital_period";
            sheet.Cells[1, 17].Value = "Perihelion_distance";
            sheet.Cells[1, 18].Value = "Perihelion_argument";
            sheet.Cells[1, 19].Value = "Aphelion_distance";
            sheet.Cells[1, 20].Value = "Perihelion_time";
            sheet.Cells[1, 21].Value = "Mean_anomaly";
            sheet.Cells[1, 22].Value = "Mean_motion";
            sheet.Cells[1, 23].Value = "Equinox";
            sheet.Cells[1, 24].Value = "Orbit_type";
            sheet.Cells[1, 25].Value = "Orbit_description";
            sheet.Cells[1, 26].Value = "Orbit_range";

            if (asteroidsData.Asteroids is null)
            {
                return sheet;
            }

            for (int i = 0; i < asteroidsData.Asteroids.Count; i++)
            {
                sheet.Cells[i + 2, 1].Value = asteroidsData.Asteroids[i].Name;
                sheet.Cells[i + 2, 2].Value = asteroidsData.Asteroids[i].OrbitalData.OrbitId;
                sheet.Cells[i + 2, 3].Value = asteroidsData.Asteroids[i].OrbitalData.OrbitDeterminationDate;
                sheet.Cells[i + 2, 4].Value = asteroidsData.Asteroids[i].OrbitalData.FirstObservationDate;
                sheet.Cells[i + 2, 5].Value = asteroidsData.Asteroids[i].OrbitalData.LastObservationDate;
                sheet.Cells[i + 2, 6].Value = asteroidsData.Asteroids[i].OrbitalData.DataArcInDays;
                sheet.Cells[i + 2, 7].Value = asteroidsData.Asteroids[i].OrbitalData.ObservationsUsed;
                sheet.Cells[i + 2, 8].Value = asteroidsData.Asteroids[i].OrbitalData.OrbitUncertainty;
                sheet.Cells[i + 2, 9].Value = asteroidsData.Asteroids[i].OrbitalData.MinimumOrbitIntersection;
                sheet.Cells[i + 2, 10].Value = asteroidsData.Asteroids[i].OrbitalData.JupiterTisserandInvariant;
                sheet.Cells[i + 2, 11].Value = asteroidsData.Asteroids[i].OrbitalData.EpochOsculation;
                sheet.Cells[i + 2, 12].Value = asteroidsData.Asteroids[i].OrbitalData.Eccentricity;
                sheet.Cells[i + 2, 13].Value = asteroidsData.Asteroids[i].OrbitalData.SemiMajorAxis;
                sheet.Cells[i + 2, 14].Value = asteroidsData.Asteroids[i].OrbitalData.Inclination;
                sheet.Cells[i + 2, 15].Value = asteroidsData.Asteroids[i].OrbitalData.AscendingNodeLongitude;
                sheet.Cells[i + 2, 16].Value = asteroidsData.Asteroids[i].OrbitalData.OrbitalPeriod;
                sheet.Cells[i + 2, 17].Value = asteroidsData.Asteroids[i].OrbitalData.PerihelionDistance;
                sheet.Cells[i + 2, 18].Value = asteroidsData.Asteroids[i].OrbitalData.PerihelionArgument;
                sheet.Cells[i + 2, 19].Value = asteroidsData.Asteroids[i].OrbitalData.AphelionDistance;
                sheet.Cells[i + 2, 20].Value = asteroidsData.Asteroids[i].OrbitalData.PerihelionTime;
                sheet.Cells[i + 2, 21].Value = asteroidsData.Asteroids[i].OrbitalData.MeanAnomaly;
                sheet.Cells[i + 2, 22].Value = asteroidsData.Asteroids[i].OrbitalData.MeanMotion;
                sheet.Cells[i + 2, 23].Value = asteroidsData.Asteroids[i].OrbitalData.Equinox;
                sheet.Cells[i + 2, 24].Value = asteroidsData.Asteroids[i].OrbitalData.Orbit.OrbitClassType;
                sheet.Cells[i + 2, 25].Value = asteroidsData.Asteroids[i].OrbitalData.Orbit.OrbitClassDescription;
                sheet.Cells[i + 2, 26].Value = asteroidsData.Asteroids[i].OrbitalData.Orbit.OrbitClassRange;
            }

            return sheet;
        }

    }
}
