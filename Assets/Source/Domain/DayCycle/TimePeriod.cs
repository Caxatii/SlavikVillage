namespace Domain
{
    public readonly struct TimePeriod
    {
        public readonly DayTimeType Current;
        public readonly DayTimeType Next;
        public readonly float Time;

        public TimePeriod(DayTimeType current, DayTimeType next, float time)
        {
            Current = current;
            Next = next;
            Time = time;
        }
    }
}