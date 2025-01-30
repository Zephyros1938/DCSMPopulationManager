namespace Zephyros1938.DCSM.Political
{
    public class Political
    {

        public static HashSet<Party> Parties = new()
        {
            new("Socialist"),
            new("Democratic"),
            new("Communist"),
            new("Monarch"),
            new("Fascist")
        };


    }

    public struct Party(string name)
    {
        public string name = name;
        public uint population;

        public readonly string GetName() => name;
        public readonly uint GetPopulation() => population;

        public void SetPopulation(uint newPopulation) => population = newPopulation;
        public void Rename(string newName) => name = newName;
    }

    public struct JointParty
    {

    }
}