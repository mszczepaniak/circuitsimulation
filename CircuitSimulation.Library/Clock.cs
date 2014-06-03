namespace CircuitSimulation.Library
{
    public class Clock
    {
        // obecny czas
        private int curentTime;
        public int CurrentTime
        {
            get { return curentTime; }
        }
        // zegar idzie do przodu
        public void MoveToNext()
        {
            curentTime ++;
        }
        // ta metoda sprawdza mi czy jestem w przeszlosci
        public bool IsInPast(int time)
        {
            return time < curentTime;
        }
    }
}
