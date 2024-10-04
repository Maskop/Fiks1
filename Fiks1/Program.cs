namespace Fiks1 {
    internal class Program {
        static void Main(string[] args) {
            // Initalizing variables
            byte numOfInstructions;
            short numOfPoints;
            // Speeds for direction of flight
            // 0 - upwards
            // 1 - horizontal
            // 2 - downwards
            int[] speeds = new int[3];
            float[] timeOfFlights;


            using (StreamReader sr = new StreamReader("input.txt")) {
                // Get the instriuctions
                numOfInstructions = byte.Parse(sr.ReadLine());
                timeOfFlights = new float[numOfInstructions];
                for (int i = 0; i < numOfInstructions; i++) {
                    // Initalizing variables for each instruction
                    var timeOfFlight = 0f;

                    // Get the number of points and speeds
                    var tmpArray = sr.ReadLine().Split(' ');
                    numOfPoints = short.Parse(tmpArray[0]);
                    for (int z = 0; z < 3; z++) {
                        speeds[z] = int.Parse(tmpArray[z + 1]);
                    }

                    // Get the first point
                    var lastPoint = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

                    // Calculate the time of flight
                    for (int j = 0; j < numOfPoints - 1; j++) {
                        var point1 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

                        // Calculate distance between two points
                        double tmpDouble = 0;
                        for (int z = 0; z < 3; z++) {
                            tmpDouble += Math.Pow(point1[z] - lastPoint[z], 2);
                        }
                        double distance = Math.Abs(Math.Sqrt(tmpDouble));

                        // Calculate time of flight
                        if (point1[2] > lastPoint[2])
                            timeOfFlight += (float)(distance / speeds[0]);
                        else if (point1[2] < lastPoint[2])
                            timeOfFlight += (float)(distance / speeds[2]);
                        else
                            timeOfFlight += (float)(distance / speeds[1]);

                        // Set the last point to the current point
                        lastPoint = point1;
                    }
                    timeOfFlights[i] = timeOfFlight;
                    Console.WriteLine(timeOfFlight);
                }
            };

            // Write result to file
            using (StreamWriter sw = new StreamWriter("output.txt")) {
                foreach (var time in timeOfFlights) {
                    sw.WriteLine(time);
                }
            };
        }
    }
}
