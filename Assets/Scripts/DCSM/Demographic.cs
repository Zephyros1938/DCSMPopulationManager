using System;
using Zephyros1938.DCSM.Political;
namespace Zephyros1938.DCSM.Demographics
{
    public class Population
    {
        public UInt64 count;
        public Single birthRate;
        public Single deathRate;
        public Single replacementRate;

        public void SetCount(UInt64 newCount) => count = newCount;
        public void SetBirthRate(Single newBirthRate) => birthRate = newBirthRate;
        public void SetDeathRate(Single newDeathRate) => deathRate = newDeathRate;
        private void UpdateReplacementRate() => replacementRate = birthRate/deathRate;

        public UInt64 GetPopulation() => count;
        public Single GetBirthRate() => birthRate;
        public Single GetDeathRate() => deathRate;
        public Single GetReplacementRate() => replacementRate;
    }

    public class Demographic
    {

    }

    public struct Person
    {
        public Party politicalAffiliation;
        public float politicalCertainty;
        public uint daysAlive = 0;

        public Person()
        {
        }
    }
}