namespace Day4
{
    public static class Functions
    {
        public static bool MeetCriterias(int password, bool mustHaveDouble = false)
        {
            string numberString = password.ToString();
            var currentNumber = 0;
            var doubleDigitCriteriaMet = false;
            var consecutiveNbrs = 1;

            for (var i = 0; i < numberString.Length; i++)
            {
                var previousNumber = currentNumber;
                currentNumber = int.Parse(numberString[i].ToString());
                if (i == 0) continue;

                if (previousNumber > currentNumber) return false;
                if (previousNumber == currentNumber)
                {
                    consecutiveNbrs++;
                }
                else
                {
                    doubleDigitCriteriaMet = doubleDigitsCriteriaMet(doubleDigitCriteriaMet, consecutiveNbrs, mustHaveDouble);
                    consecutiveNbrs = 1;
                }
            }
            doubleDigitCriteriaMet = doubleDigitsCriteriaMet(doubleDigitCriteriaMet, consecutiveNbrs, mustHaveDouble);
            return doubleDigitCriteriaMet;
        }

        private static bool doubleDigitsCriteriaMet(bool doubleDigitCriteriaMet, int consecutiveNbrs, bool mustHaveDouble = false)
        {
            return doubleDigitCriteriaMet || (mustHaveDouble ? consecutiveNbrs == 2 : consecutiveNbrs >= 2);
        }
    }
}
