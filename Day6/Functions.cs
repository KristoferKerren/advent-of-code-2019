namespace Day6
{
    public static class Functions
    {
        public static List<Object> GetObjectsFromFile(string filePath)
        {
            var objects = new List<Object>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var test = line.Split(")");
                        objects.Add(new Object(line.Split(")").ElementAt(1), line.Split(")").ElementAt(0)));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            objects.ForEach(o =>
            {
                var connected = objects.SingleOrDefault(oo => oo.Name == o.OrbitsObjectName);
                if (connected == null)
                {
                    connected = new Object(o.OrbitsObjectName, null);
                } 
                else
                {
                    connected.ConnectedObjects.Add(o);
                }
                o.ConnectedObjects.Add(connected);
            });
            return objects;
        }

        public static string? GetOrbitNameOrDefault(string name, List<Object> objects)
        {
            return objects.SingleOrDefault(o => o.Name == name)?.OrbitsObjectName;
        }

        public static int GetOrbitsCount(string name, List<Object> objects)
        {
            var count = 0;
            var currentName = GetOrbitNameOrDefault(name, objects);
            while (currentName != null)
            {
                count++;
                currentName = GetOrbitNameOrDefault(currentName, objects);
            }
            return count;
        }

        public static int GetTotalOrbits(List<Object> objects)
        {
            return objects.Sum(o => GetOrbitsCount(o.Name, objects));
        }

        public static int? GetStepsBetweenRecursive(Object object1, Object object2, HashSet<string> visited, int steps = 0)
        {
            if (object1.Name == object2.Name) return steps;
            visited.Add(object1.Name);
            var connected = object1.ConnectedObjects.Where(c => !visited.Contains(c.Name)).ToList();
            if (connected.Count == 0) return null;
            foreach (var c in connected)
            {
                var calculatedSteps = GetStepsBetweenRecursive(c, object2, visited, steps + 1);
                if (calculatedSteps != null)
                {
                    return calculatedSteps;
                }
            }

            return null;
        }
    }
}
