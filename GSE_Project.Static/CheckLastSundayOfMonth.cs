namespace GSE_Project.Static
{
    public static class CheckLastSundayOfMonth
    {
        public static int CheckLastSunday(DateTime date)
        {
            var lastSunday = 0;
            var month = date.Month;
            var year = date.Year;
            var lastDayOfMonth = DateTime.DaysInMonth(year, month);
            var datetime = new DateTime(year, month, lastDayOfMonth);

            for (int i = 0; i < lastDayOfMonth; i++)
            {
                if (datetime.DayOfWeek == DayOfWeek.Sunday)
                {
                    lastSunday = datetime.Day;
                    break;
                }

                datetime = datetime.AddDays(-1);
            }

            return lastSunday;
        }
    }
}